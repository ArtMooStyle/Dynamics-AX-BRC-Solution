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

public partial class _PalletUnblock : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
		{
            tPalletID.Focus();

            BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
            try
            {
                AdjustPalletId();
                string result = svc.BlockingCodeList(TermID, DateTime.Now, LangID, PIN)[0];
                string[] r = result.Split(';');
                ddlBlocking.Items.Clear();
                ddlBlocking.Items.Add("");

                if ((r.Length >= 4) && (r[3] == "OK"))
                {
                    for (int i = 4; i < r.Length; i += 4)
                        ddlBlocking.Items.Add(r[i]);
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

    protected void AdjustPalletId()
    {
        tPalletID.Text = tPalletID.Text.Trim();
        if ((lOldPalletID.Text != "") && (tPalletID.Text.Length > lOldPalletID.Text.Length) && (tPalletID.Text.EndsWith(lOldPalletID.Text)))
            tPalletID.Text = tPalletID.Text.Substring(0, tPalletID.Text.Length - lOldPalletID.Text.Length);
        lOldPalletID.Text = tPalletID.Text;
    }

    protected void bPalletInfo_Click(object sender, EventArgs e)
    {
        ddlBlocking.Focus();
    }

    protected void bBlocking_Click(object sender, EventArgs e)
    {
        bConfirm.Focus();
    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            AdjustPalletId();
            string result = svc.UnBlockPallet(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tPalletID.Text.Trim()), Server.HtmlEncode(ddlBlocking.SelectedValue.Trim()))[0];
            string[] r = result.Split(';');

            if ((r.Length >= 4) && (r[3] == "OK"))
            {
                Response.Redirect("PalletUnblock.aspx");
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

