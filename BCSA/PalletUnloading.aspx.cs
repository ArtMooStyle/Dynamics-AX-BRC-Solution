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

public partial class _PalletUnloading : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
			tStock.Focus();
        }
    }

    protected void bStock_Click(object sender, EventArgs e)
    {
        FormatStockLocation();
    }

    protected void AdjustPalletId()
    {
        tPalletID.Text = tPalletID.Text.Trim();
        if ((lOldPalletID.Text != "") && (tPalletID.Text.Length > lOldPalletID.Text.Length) && (tPalletID.Text.EndsWith(lOldPalletID.Text)))
            tPalletID.Text = tPalletID.Text.Substring(0, tPalletID.Text.Length - lOldPalletID.Text.Length);
        lOldPalletID.Text = tPalletID.Text;
    }

    protected void FormatStockLocation()
    {
        string stock = tStock.Text;
        int idx = stock.IndexOf('/');
        if (idx > 0)
        {
            tStock.Text = stock.Substring(0, idx);
            tLocation.Text = stock.Substring(idx + 1);
			tPalletID.Focus();
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

    protected void bPalletInfo_Click(object sender, EventArgs e)
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
            string result = svc.PalletUnload(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tStock.Text.Trim().ToUpper()), Server.HtmlEncode(GetLocationWithStock(tStock.Text.Trim(), tLocation.Text.Trim())), Server.HtmlEncode(tPalletID.Text.Trim()))[0];
            string[] r = result.Split(';');

            if ((r.Length >= 3) && (r[3] == "OK"))
            {
                Response.Redirect("PalletUnloading.aspx");
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


