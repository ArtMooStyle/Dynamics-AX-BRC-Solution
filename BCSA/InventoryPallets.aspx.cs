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

public partial class _InventoryPallets : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            tStock.Focus();

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
                ////svc.Close();
            }
        }
    }

    protected void ShowInfo()
    {
        if (tPalletID.Text == "")
            lInfo.Text = String.Format(GetLocalResourceObject("res_MSG_Info_format").ToString(), tStock.Text, lJournalID.Text);
        else
            lInfo.Text = String.Format(GetLocalResourceObject("res_MSG_Info_format_2").ToString(), tStock.Text, lJournalID.Text, lItemID.Text, lBatch.Text);
        lInfo.ForeColor = Color.Black;
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
                r = new string[11];
                r[3] = "OK";
                r[4] = "1";
                r[5] = "2";
                r[6] = "3";
                r[7] = "4";
                r[8] = "";
            }

            if ((r.Length >= 10) && (r[3] == "OK"))
            {
                lItemID.Text = r[4];
                lBatch.Text = r[9];
                ddlBlocking.SelectedValue = r[8];
                /*if (ddlUnit.SelectedValue == "")*/ ddlUnit.SelectedValue = r[10];
                ShowInfo();
                tLocation.Focus();
            }
            else
            {
                if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                lInfo.ForeColor = Color.Red;
                tPalletID.Focus();
            }


            result = svc.InventPickPalletInfo(TermID, DateTime.Now, LangID, PIN, "005000", Server.HtmlEncode(tPalletID.Text))[0];

            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                result = "SFX;term11;25.2.2016 9:51:17;OK;F20003;HBD1;pick;7000;8000;pcs";
            }
            r = result.Split(';');

            if ((r.Length >= 10) && (r[3] == "OK"))
            {
                tQuantity.Text = r[7];
            }
            else
            {
                if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                lInfo.ForeColor = Color.Red;
                tPalletID.Focus();
            }

            CheckQty();
        }
        finally
        {
            //svc.Close();
        }
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
        ddlBlocking.Focus();
    }

    protected void bBlocking_Click(object sender, EventArgs e)
    {
        bConfirm.Focus();
    }

    protected bool CheckQty()
    {
        if (tQuantity.Text.Trim() == "")
        {
            tQuantity.BackColor = Color.LightPink;
            tQuantity.Focus();
            return false;
        }
        tQuantity.BackColor = Color.White;
        return true;
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
                //svc.Close();
            }
        }
        else
        {
            if (!CheckQty()) return;

            BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
            try
            {
                //FormatStock();
                //FormatLocation();
                AdjustPalletId();
                string result = svc.InventCountingCreateLine(TermID, DateTime.Now, LangID, PIN,
                    Server.HtmlEncode(lJournalID.Text.Trim()), "",
                    Server.HtmlEncode(tPalletID.Text.Trim()), "",
                    Server.HtmlEncode(tStock.Text.Trim()),
                    Server.HtmlEncode(GetLocationWithStock(tStock.Text.Trim(), tLocation.Text.Trim())),
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
                        ShowInfo();
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
                //svc.Close();
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
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            //FormatStock();
            //FormatLocation();
            AdjustPalletId();
            string result = svc.InventCountingCreateLine(TermID, DateTime.Now, LangID, PIN,
                Server.HtmlEncode(lJournalID.Text.Trim()), "",
                Server.HtmlEncode(tPalletID.Text.Trim()), "",
                Server.HtmlEncode(tStock.Text.Trim()),
                Server.HtmlEncode(GetLocationWithStock(tStock.Text.Trim(), tLocation.Text.Trim())),
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

            if ((r.Length >= 4) && (r[3] == "OK"))
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

