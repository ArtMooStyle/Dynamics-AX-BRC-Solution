using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using fdAsp.Web;

public partial class _PalletMove : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
            tPalletID.Focus();
    }

    protected void AdjustPalletId()
    {
        tPalletID.Text = tPalletID.Text.Trim();
        if ((lOldPalletID.Text != "") && (tPalletID.Text.Length > lOldPalletID.Text.Length) && (tPalletID.Text.EndsWith(lOldPalletID.Text)))
            tPalletID.Text = tPalletID.Text.Substring(0, tPalletID.Text.Length - lOldPalletID.Text.Length);
        lOldPalletID.Text = tPalletID.Text;
    }

    protected void bPalletInfo_Click(object sender, EventArgs e)
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            AdjustPalletId();
            string result = svc.PalletInfo(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tPalletID.Text))[0];
            string[] r = result.Split(';');

            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                r = new string[10];
                r[3] = "OK";
                r[4] = "1";
                r[5] = "2";
                r[6] = "3";
                r[7] = "4";
                r[8] = "5";
            }

            if ((r.Length >= 9) && (r[3] == "OK"))
            {
                lInfo.Text = String.Format(GetLocalResourceObject("res_MSG_Info_format").ToString(), r[4], r[5], r[6], r[7], r[8]);
                lInfo.ForeColor = Color.Black;
                tStock.Focus();
            }
            else
            {
                if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                lInfo.ForeColor = Color.Red;
                tPalletID.Focus();
            }
        }
        finally
        {
            //svc.Close();
        }
    }

    protected void bStock_Click(object sender, EventArgs e)
    {
        FormatStockLocation();
    }

    protected void FormatStockLocation()
    {
        string stock = tStock.Text;
        int idx = stock.IndexOf('/');
        if (idx > 0)
        {
            tStock.Text = stock.Substring(0, idx);
            tLocation.Text = stock.Substring(idx + 1);
            bConfirm.Focus();
        }
        else
        {
            tLocation.Focus();
        }
        tStock.Text = tStock.Text.Trim().ToUpper();
        tLocation.Text = tLocation.Text.Trim().ToUpper();
    }

    protected string GetLocationWithStock(string stock, string location)
    {
        if ((location.Contains("/")) && (location.StartsWith(stock + "/")))
            return location;
        else
            return stock + "/" + location;
    }

    protected void bLocation_Click(object sender, EventArgs e)
    {
        bConfirm.Focus();
    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            //FormatStockLocation();
            AdjustPalletId();
            string result = svc.PalletMove(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tPalletID.Text.Trim()), Server.HtmlEncode(tStock.Text.Trim().ToUpper()), Server.HtmlEncode(GetLocationWithStock(tStock.Text.Trim(), tLocation.Text.Trim())))[0];
            string[] r = result.Split(';');

            if ((r.Length >= 4) && (r[3] == "OK"))
            {
                Response.Redirect("PalletMove.aspx");
            }
            else
            {
                if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                lInfo.ForeColor = Color.Red;
                bConfirm.Focus();
            }

        }
        finally
        {
            //svc.Close();
        }
    }
}

