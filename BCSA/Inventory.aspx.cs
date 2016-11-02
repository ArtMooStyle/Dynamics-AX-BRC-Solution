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

public partial class _Inventory : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
            tStock.Focus();
    }

    protected void ShowInfo()
    {
        if (tPalletID.Text == "")
            lInfo.Text = String.Format("Stock: <strong>{0}</strong>, &nbsp; Journal: <strong>{1}</strong><br/>{2}", tStock.Text, lJournalID.Text, "Scan Pallet ID to obtain info...");
        else
            lInfo.Text = String.Format("Stock: <strong>{0}</strong>, &nbsp; Journal: <strong>{1}</strong><br/>ItemID: <strong>{2}</strong>, &nbsp; Batch: <strong>{3}</strong>", tStock.Text, lJournalID.Text, lItemID.Text, lBatch.Text);
        lInfo.ForeColor = Color.Black;
    }

    protected void bPalletInfo_Click(object sender, EventArgs e)
    {
        BCSWSReference.ServiceClient svc = new BCSWSReference.ServiceClient();
        try
        {
            string result = svc.PalletInfo(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tPalletID.Text.Trim()))[0];
            string[] r = result.Split(';');

            if ((r.Length >= 10) && (r[3] == "OK"))
            {
                lItemID.Text = r[4];
                lBatch.Text = r[9];
                ddlBlocking.SelectedValue = r[8];
                ddlUnit.SelectedValue = r[10];
                ShowInfo();
                tLocation.Focus();
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
            svc.Close();
        }
    }

    protected void bStock_Click(object sender, EventArgs e)
    {
        string stock = tStock.Text;
        int idx = stock.IndexOf('/');
        if (idx > 0) tStock.Text = stock.Substring(0, idx);

        bConfirm.Focus();
    }

    protected void bLocation_Click(object sender, EventArgs e)
    {
        string location = tLocation.Text;
        int idx = location.IndexOf('/');
        if (idx > 0) tLocation.Text = location.Substring(idx + 1);
        ShowInfo();
        tQuantity.Focus();
    }

    protected void bQuantity_Click(object sender, EventArgs e)
    {
        ddlUnit.Focus();
    }

    protected void bUnit_Click(object sender, EventArgs e)
    {
        ddlBlocking.Focus();
    }

    protected void bBlocking_Click(object sender, EventArgs e)
    {
        bConfirm.Focus();
    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        if (lStock.Visible)
        {
            string stock = tStock.Text;
            int idx = stock.IndexOf('/');
            if (idx > 0) tStock.Text = stock.Substring(0, idx);

            BCSWSReference.ServiceClient svc = new BCSWSReference.ServiceClient();
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
                    tPalletID.Focus();
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
                svc.Close();
            }
        }
        else
        {

            BCSWSReference.ServiceClient svc = new BCSWSReference.ServiceClient();
            try
            {
                string result = svc.InventCountingCreateLine(TermID, DateTime.Now, LangID, PIN,
                    Server.HtmlEncode(lJournalID.Text.Trim()), "",
                    Server.HtmlEncode(tPalletID.Text.Trim()), "",
                    Server.HtmlEncode(tStock.Text.Trim()),
                    Server.HtmlEncode(tLocation.Text.Trim()),
                    Common.StringToDecimal(tQuantity.Text),
                    ddlUnit.SelectedValue,
                    ddlBlocking.SelectedValue,
                    "0")[0];
                string[] r = result.Split(';');

                // OFFLINE DEBUGGING
                if (ConfigurationManager.AppSettings.Get("offline") == "true")
                {
                    r = new string[5];
                    r[3] = "OK";
                    r[4] = "1";
                }

                if ((r.Length >= 5) && (r[3] == "OK"))
                {
                    if (r[4] == "1")
                    {
                        // need to overwrite
                        tPalletID.Enabled = false;
                        tLocation.Enabled = false;
                        tQuantity.Enabled = false;
                        ddlUnit.Enabled = false;
                        ddlBlocking.Enabled = false;
                        bConfirm.Visible = false;
                        bOverwrite.Visible = true;
                        bCancel.Visible = true;
                    }
                    else
                    {
                        tPalletID.Text = "";
                        tLocation.Text = "";
                        tQuantity.Text = "";
                        tPalletID.Focus();
                    }
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
                svc.Close();
            }
        }
    }

    protected void bCancel_Click(object sender, EventArgs e)
    {
        tPalletID.Enabled = true;
        tLocation.Enabled = true;
        tQuantity.Enabled = true;
        ddlUnit.Enabled = true;
        ddlBlocking.Enabled = true;
        bConfirm.Visible = true;
        bOverwrite.Visible = false;
        bCancel.Visible = false;
    }

    protected void bOverwrite_Click(object sender, EventArgs e)
    {
        BCSWSReference.ServiceClient svc = new BCSWSReference.ServiceClient();
        try
        {
            string result = svc.InventCountingCreateLine(TermID, DateTime.Now, LangID, PIN,
                Server.HtmlEncode(lJournalID.Text.Trim()), "",
                Server.HtmlEncode(tPalletID.Text.Trim()), "",
                Server.HtmlEncode(tStock.Text.Trim()),
                Server.HtmlEncode(tLocation.Text.Trim()),
                Common.StringToDecimal(tQuantity.Text),
                ddlUnit.SelectedValue,
                ddlBlocking.SelectedValue,
                "1")[0];
            string[] r = result.Split(';');

            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                r = new string[5];
                r[3] = "OK";
                r[4] = "1";
            }

            if ((r.Length >= 5) && (r[3] == "OK"))
            {
                tPalletID.Enabled = true;
                tLocation.Enabled = true;
                tQuantity.Enabled = true;
                ddlUnit.Enabled = true;
                ddlBlocking.Enabled = true;
                bConfirm.Visible = true;
                bOverwrite.Visible = false;
                bCancel.Visible = false;

                tPalletID.Text = "";
                tLocation.Text = "";
                tQuantity.Text = "";
                tPalletID.Focus();
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
            svc.Close();
        }
    }
}

