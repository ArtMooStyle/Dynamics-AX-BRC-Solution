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

public partial class _PalletLoading : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            string ShowPopup = Common.NullToStr(Request.QueryString["ShowPopup"]);
            string PalletID = Common.NullToStr(Request.QueryString["PalletID"]);
            if (ShowPopup == "1")
            {
                transportCount.Text = "1";
                transportComplete.Visible = true;
            }

            if (PalletID != "")
            {
                bConfirm_Click(null, null);

                BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
                try
                {
                    string result = svc.PalletInfo(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(PalletID))[0];
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

                    tPalletID.Focus();
                }
                finally
                {
                    //svc.Close();
                }
            }
            else
            {
                if (tPalletID.Visible)
                {
                    ReLoadTable();
                    tPalletID.Focus();
                }
                else
                    tStock.Focus();
            }
        }
    }

    protected void ReLoadTable()
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            string result = svc.PalletLoadList(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tStock.Text.Trim().ToUpper()), Server.HtmlEncode(GetLocationWithStock(tStock.Text.Trim(), tLocation.Text.Trim())))[0];
            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                result = "PalletLoadList;term11;15.8.2016 12:58:39;OK;085956116001532673;085956116001534868";
            }
            string[] r = result.Split(';');
            lTable.Text = "";

            if ((r.Length >= 5) && (r[3] == "OK"))
            {
                lInfo.Text = "";
                lInfo.ForeColor = Color.Black;

                lTable.Text = "<table><tbody>"; 
                int row = 0;
                for (int i = 4; i < r.Length; i++)
                {
                    row++;
                    string url = "PalletLoading.aspx?PalletID=" + r[i];
                    if (row % 2 == 0)
                        lTable.Text += "<tr><td class='tabcell' style='width: 230px; line-height: 13pt;padding: 2px'>";
                    else
                        lTable.Text += "<tr><td class='tabcell' style='width: 230px; line-height: 13pt;padding: 2px;background-color: #E0E0E0'>";
                    lTable.Text += "<span style='font-size: 13pt'><a href='" + url + "'>" + r[i] + "</a></span><br/>";

                    lTable.Text += "</td></tr>";
                }
                lTable.Text += "</tbody></table>";

                lTable.Text += "<img onclick='javascript:window.scrollTo(0, 280)' style='position: absolute; left: 205px; top: 250px' src='images/arrowd.jpg'/>";
                for (int i = 1; i < 20; i++)
                {
                    lTable.Text += "<img onclick='javascript:window.scrollTo(0, " + (280 * (i - 2)).ToString() + ")' style='position: absolute; left: 205px; top: " + (280 * (i + 1) - 32 - 30).ToString() + "px' src='images/arrowu.jpg'/>";
                    lTable.Text += "<img onclick='javascript:window.scrollTo(0, " + (280 * (i + 1)).ToString() + ")' style='position: absolute; left: 205px; top: " + (280 * (i + 1) - 30).ToString() + "px' src='images/arrowd.jpg'/>";
                }
            }
            else
            {
                lInfo.Text = result;
                lInfo.ForeColor = Color.Red;
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
        bConfirm_Click(null, null);
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

    protected void bPalletInfo_Click(object sender, EventArgs e)
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            string result = svc.PalletLoad(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tStock.Text.Trim().ToUpper()), Server.HtmlEncode(GetLocationWithStock(tStock.Text.Trim(), tLocation.Text.Trim())), Server.HtmlEncode(tPalletID.Text))[0];
            tPalletID.Text = "";
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

            string saveError = "";

            if ((r.Length >= 3) && (r[3] == "OK"))
            {
                transportCount.Text = "2";
                transportCompleteText.BackColor = Color.GreenYellow;
                transportComplete.Visible = true;
            }
            else
            {
                if (r.Length >= 5) saveError = r[4]; else saveError = r[0];

                transportCount.Text = "2";
                transportCompleteText.BackColor = Color.Red;
                transportComplete.Visible = true;
            }

            ReLoadTable();
            tPalletID.Focus();

            if (saveError != "")
            {
                lInfo.Text = saveError;
                lInfo.ForeColor = Color.Red;
            }
        }
        finally
        {
            //svc.Close();
        }

    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        if (!tPalletID.Visible)
        {
            tPalletID.Visible = true;
            lStock.Visible = false;
            tStock.Visible = false;
            lLocation.Visible = false;
            tLocation.Visible = false;
            bConfirm.Visible = false;
            ReLoadTable();
            tPalletID.Focus();
        }
    }
}


