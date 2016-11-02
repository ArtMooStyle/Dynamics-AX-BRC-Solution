using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using fdAsp.Web;
using BCSWSReference;

public partial class _Login : fdAsp.Web.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        string tid = Common.NullToStr(Request.QueryString["TermID"]);
        string lid = Common.NullToStr(Request.QueryString["LangID"]);
        if (tid != "") TermID = tid;
        if (lid != "") LangID = lid;

        if (Common.NullToStr(Request.QueryString["logout"]) == "1")
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            PIN = "";
            Common.SaveCookieInfo(Response, TermID, LangID, CompanyID, PIN, Rights);
            Response.Redirect("Login.aspx?TermID=" + TermID);
            return;
        }

        if (TermID == "")
        {
            lResult.Text = GetLocalResourceObject("res_MSG_Configuration_error").ToString();  // "Nesprávná konfigurace aplikace, je tøeba nastavit TermID!";
            lPIN.Visible = false;
            tPIN.Visible = false;
            bLogin.Visible = false;
        }

        Common.SaveCookieInfo(Response, TermID, LangID, CompanyID, PIN, Rights);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        tPIN.Focus();
    }

    protected void bLogin_Click(object sender, EventArgs e)
    {
        string pin = Common.NullToStr(tPIN.Text);

        if (pin == "")
        {
            lResult.Text = GetLocalResourceObject("res_MSG_PIN_required").ToString(); // "Je tøeba zadat PIN!";
        }
        else
        {
            pin = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(pin));

            Common.SaveCookieInfo(Response, TermID, LangID, CompanyID, pin, Rights);

            BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
            try
            {
                string result = svc.Login(TermID, DateTime.Now, LangID, pin)[0];
                string[] r = result.Split(';');

                // OFFLINE DEBUGGING
                if (ConfigurationManager.AppSettings.Get("offline") == "true")
                {
                    r = new string[9];
                    r[3] = "OK";
                    r[4] = "dcz";

                    r[5] = "0";
                    r[6] = "1";

                    r[7] = "1";
                    r[8] = "1";
                }

                if ((r.Length >= 5) && (r[3] == "OK"))
                {
                    CompanyID = r[4];

                    // Load rights
                    Rights = "";
                    for (int i = 5; i < r.Length; i += 2)
                    {
                        if (r[i + 1] != "0") Rights += String.Format("[{0}]{1}", r[i], r[i + 1]);
                    }

                    Common.SaveCookieInfo(Response, TermID, LangID, CompanyID, pin, Rights);
                    FormsAuthentication.RedirectFromLoginPage(pin, false);
                }
                else if (r.Length >= 5)
                {
                    lResult.Text = r[4];
                }
                else
                {
                    lResult.Text = r[0];
                }
            }
            finally
            {
                //svc.Close();
            }
        }
    }

}
