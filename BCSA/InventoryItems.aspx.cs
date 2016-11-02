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

public partial class _InventoryItems : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            tStock.Focus();
            ddlUnit.SelectedValue = "pcs";
        }
    }

    protected void ShowInfo()
    {
        lInfo.Text = String.Format(GetLocalResourceObject("res_MSG_Info_format").ToString(), tStock.Text, lJournalID.Text, "");
        lInfo.ForeColor = Color.Black;
    }

    protected void bStock_Click(object sender, EventArgs e)
    {
        FormatStock();
        bConfirm.Focus();
    }

    protected void FormatStock()
    {
        string stock = tStock.Text;
        int idx = stock.IndexOf('/');
        if (idx > 0) tStock.Text = stock.Substring(0, idx);
        tStock.Text = tStock.Text.Trim().ToUpper();
    }

    protected void bItem_Click(object sender, EventArgs e)
    {
        tLocation.Focus();
    }

    protected void FormatLocation()
    {
        string location = tLocation.Text;
        int idx = location.IndexOf('/');
        if (idx > 0) tLocation.Text = location.Substring(idx + 1);
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
        FormatLocation();
        ShowInfo();
        tQuantity.Focus();
    }

    protected void bQuantity_Click(object sender, EventArgs e)
    {
        ddlUnit.Focus();
    }

    protected void bUnit_Click(object sender, EventArgs e)
    {
        bConfirm.Focus();
    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        if (lStock.Visible)
        {
            FormatStock();

            BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
            try
            {
                string result = svc.InventCountingFindOrCreateJournal(TermID, DateTime.Now, LangID, PIN,
                    Server.HtmlEncode(tStock.Text.Trim()))[0];
                string[] r = result.Split(';');

                // OFFLINE DEBUGGING
                if (ConfigurationManager.AppSettings.Get("offline") == "true")
                {
                    r = new string[5];
                    r[3] = "OK";
                    r[4] = "017890";
                }

                if ((r.Length >= 5) && (r[3] == "OK"))
                {
                    lStock.Visible = false;
                    panStock.Visible = false;
                    panForm.Visible = true;
                    lJournalID.Text = r[4];
                    ShowInfo();
                    tItemID.Focus();
                }
                else
                {
                    if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                    lInfo.ForeColor = Color.Red;
                    tStock.Focus();
                }
            }
            finally
            {
                //svc.Close();
            }
        }
        else
        {
            BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
            try
            {
                //FormatStock();
                //FormatLocation();

                string result = svc.InventCountingCreateLine(TermID, DateTime.Now, LangID, PIN,
                    Server.HtmlEncode(lJournalID.Text.Trim()), Server.HtmlEncode(tItemID.Text.Trim()),
                    "", "",
                    Server.HtmlEncode(tStock.Text.Trim()),
                    Server.HtmlEncode(GetLocationWithStock(tStock.Text.Trim(), tLocation.Text.Trim())),
                    Common.StringToDecimal(tQuantity.Text), 
                    ddlUnit.SelectedValue,
                    "",
                    "0")[0];
                string[] r = result.Split(';');

                // OFFLINE DEBUGGING
                if (ConfigurationManager.AppSettings.Get("offline") == "true")
                {
                    r = new string[4];
                    r[3] = "OK";
                    //r[4] = "1";
                }

                if ((r.Length >= 4) && (r[3] == "OK"))
                {
                    /*if (r[4] == "1")
                    {
                        // need to overwrite
                        tItemID.Enabled = false;
                        tLocation.Enabled = false;
                        tQuantity.Enabled = false;
                        ddlUnit.Enabled = false;
                        bConfirm.Visible = false;
                        bOverwrite.Visible = true;
                        bCancel.Visible = true;
                    }
                    else
                    {*/
                        tItemID.Text = "";
                        tLocation.Text = "";
                        tQuantity.Text = "";
                        tItemID.Focus();
                        ShowInfo();
                    //}
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

    protected void bCancel_Click(object sender, EventArgs e)
    {
        tItemID.Enabled = true;
        tLocation.Enabled = true;
        tQuantity.Enabled = true;
        ddlUnit.Enabled = true;
        bConfirm.Visible = true;
        bOverwrite.Visible = false;
        bCancel.Visible = false;
    }

    protected void bOverwrite_Click(object sender, EventArgs e)
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            //FormatStock();
            //FormatLocation();

            string result = svc.InventCountingCreateLine(TermID, DateTime.Now, LangID, PIN,
                Server.HtmlEncode(lJournalID.Text.Trim()), Server.HtmlEncode(tItemID.Text.Trim()),
                "", "",
                Server.HtmlEncode(tStock.Text.Trim()),
                Server.HtmlEncode(GetLocationWithStock(tStock.Text.Trim(), tLocation.Text.Trim())),
                Common.StringToDecimal(tQuantity.Text), 
                ddlUnit.SelectedValue,
                "",
                "1")[0];
            string[] r = result.Split(';');

            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                r = new string[5];
                r[3] = "OK";
                r[4] = "1";
            }

            if ((r.Length >= 4) && (r[3] == "OK"))
            {
                tItemID.Enabled = true;
                tLocation.Enabled = true;
                tQuantity.Enabled = true;
                ddlUnit.Enabled = true;
                bConfirm.Visible = true;
                bOverwrite.Visible = false;
                bCancel.Visible = false;

                tItemID.Text = "";
                tLocation.Text = "";
                tQuantity.Text = "";
                tItemID.Focus();
                ShowInfo();
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

