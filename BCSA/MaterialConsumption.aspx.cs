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

public partial class _MaterialConsumption : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            tWorkorderID.Focus();
            lLocationID.Visible = false;
            tLocationID.Visible = false;
            lPalletID.Visible = false;
            tPalletID.Visible = false;
            lQuantity.Visible = false;
            tQuantity.Visible = false;
            lUnit.Visible = false;
            ddlUnit.Visible = false;
        }
    }

    protected void bWorkorder_Click(object sender, EventArgs e)
    {
        //bConfirm.Focus();
        bConfirm_Click(null, null);
    }

    protected void bLocation_Click(object sender, EventArgs e)
    {
        //FormatLocation();
        ShowSetup();
        tPalletID.Focus();
    }

    protected void bPallet_Click(object sender, EventArgs e)
    {
        AdjustPalletId();

        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            string result = svc.InventPickPalletInfo(TermID, DateTime.Now, LangID, PIN,
                Server.HtmlEncode(tWorkorderID.Text.Trim()),
                Server.HtmlEncode(tPalletID.Text.Trim()))[0];

            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                result = "SFX;term11;25.2.2016 9:51:17;OK;F20003;HBD1;pick;7000;8000;pcs";
            }
            string[] r = result.Split(';');

            if ((r.Length >= 10) && (r[3] == "OK"))
            {
                lAXItem.Text = r[4];
                lAXLocation.Text = r[5].ToUpper() + "/" + r[6].ToUpper();
                lAXQty.Text = r[7];
                lAXPickedQty.Text = r[8];
                ddlUnit.SelectedValue = r[9];
                ShowSetup();
            }
            else
            {
                if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                lInfo.ForeColor = Color.Red;
                lInfo.Text = "<br/>" + lInfo.Text;
                bConfirm.Focus();
            }
        }
        finally
        {
            //svc.Close();
        }

        ShowSetup();
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

    protected void FormatLocation()
    {
        string location = tLocationID.Text;
        int idx = location.IndexOf('/');
        if (idx > 0) tLocationID.Text = location.Substring(idx + 1);
        tLocationID.Text = tLocationID.Text.Trim().ToUpper();
    }

    protected void AdjustPalletId()
    {
        tPalletID.Text = tPalletID.Text.Trim();
        if ((lOldPalletID.Text != "") && (tPalletID.Text.Length > lOldPalletID.Text.Length) && (tPalletID.Text.EndsWith(lOldPalletID.Text)))
            tPalletID.Text = tPalletID.Text.Substring(0, tPalletID.Text.Length - lOldPalletID.Text.Length);
        lOldPalletID.Text = tPalletID.Text;
    }

    protected void ShowSetup()
    {
        lSetup.Text = String.Format(GetLocalResourceObject("res_MSG_Info_format").ToString(),
            tWorkorderID.Text, lAXItem.Text, lAXLocation.Text, lAXQty.Text, lAXPickedQty.Text);
        lSetup.ForeColor = Color.Black;
        lInfo.Text = "";
    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            bConfirm.Enabled = false;

            if (lWorkorderID.Visible)
            {
                lWorkorderID.Visible = false;
                tWorkorderID.Visible = false;

                lLocationID.Visible = true;
                tLocationID.Visible = true;
                lPalletID.Visible = true;
                tPalletID.Visible = true;
                lQuantity.Visible = true;
                tQuantity.Visible = true;
                lUnit.Visible = true;
                ddlUnit.Visible = true;

                ShowSetup();

                tLocationID.Focus();
            }
            else
            {
                AdjustPalletId();
                if (Common.StringToDecimal(tQuantity.Text) < 0)
                {
                    panTransfer.Visible = true;
                    bConfirm.Visible = false;
                    tLocationID.Enabled = false;
                    tPalletID.Enabled = false;
                    tQuantity.Enabled = false;
                    ddlUnit.Enabled = false;
                }
                else
                {
                    BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
                    try
                    {
                        string result = svc.PickingListPicking(TermID, DateTime.Now, LangID, PIN,
                            Server.HtmlEncode(tWorkorderID.Text.Trim()),
                            "",
                            "",
                            "",
                            "",
                            Server.HtmlEncode(tLocationID.Text.Trim()),
                            Server.HtmlEncode(tPalletID.Text.Trim()),
                            "",
                            Common.StringToDecimal(tQuantity.Text),
                            ddlUnit.SelectedValue,
                            false, "")[0];
                        string[] r = result.Split(';');

                        if ((r.Length >= 4) && (r[3] == "OK"))
                        {
                            ResetForm();
                        }
                        else
                        {
                            if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                            lInfo.ForeColor = Color.Red;
                            lInfo.Text = "<br/>" + lInfo.Text;
                            bConfirm.Focus();
                        }
                    }
                    finally
                    {
                        //svc.Close();
                    }
                }
            }
        }
        finally
        {
            bConfirm.Enabled = true;
        }
    }

    protected void bTransfer_Click(object sender, EventArgs e)
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            bTransfer.Enabled = false;
            bReturn.Enabled = false;
            string result = svc.PickingListPicking(TermID, DateTime.Now, LangID, PIN,
                Server.HtmlEncode(tWorkorderID.Text.Trim()),
                "",
                "",
                "",
                "",
                Server.HtmlEncode(tLocationID.Text.Trim()),
                Server.HtmlEncode(tPalletID.Text.Trim()),
                "",
                Common.StringToDecimal(tQuantity.Text), 
                ddlUnit.SelectedValue,
                false, Server.HtmlEncode(tNewWorkorderID.Text.Trim()))[0];

            string[] r = result.Split(';');

            if ((r.Length >= 4) && (r[3] == "OK"))
            {
                ResetForm();
            }
            else
            {
                ResetForm();
                if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                lInfo.ForeColor = Color.Red;
                lInfo.Text = "<br/>" + lInfo.Text;
                //bConfirm.Focus();
            }
        }
        finally
        {
            bTransfer.Enabled = true;
            bReturn.Enabled = true;
            //svc.Close();
        }
    }

    protected void bReturn_Click(object sender, EventArgs e)
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            bTransfer.Enabled = false;
            bReturn.Enabled = false;
            string result = svc.PickingListPicking(TermID, DateTime.Now, LangID, PIN,
                Server.HtmlEncode(tWorkorderID.Text.Trim()),
                "",
                "",
                "",
                "",
                Server.HtmlEncode(tLocationID.Text.Trim()),
                Server.HtmlEncode(tPalletID.Text.Trim()),
                "",
                Common.StringToDecimal(tQuantity.Text),
                ddlUnit.SelectedValue,
                false, "")[0];
            string[] r = result.Split(';');

            if ((r.Length >= 4) && (r[3] == "OK"))
            {
                ResetForm();
            }
            else
            {
                ResetForm();
                if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                lInfo.ForeColor = Color.Red;
                lInfo.Text = "<br/>" + lInfo.Text;
                //bConfirm.Focus();
            }
        }
        finally
        {
            bTransfer.Enabled = true;
            bReturn.Enabled = true;
            //svc.Close();
        }
    }

    protected void bNone_Click(object sender, EventArgs e)
    {
    }

    protected void ResetForm()
    {
        lAXItem.Text = "";
        lAXLocation.Text = "";
        lAXQty.Text = "";
        lAXPickedQty.Text = "";
        tLocationID.Text = "";
        tPalletID.Text = "";
        tQuantity.Text = "";
        ddlUnit.SelectedValue = "";
        ShowSetup();

        panTransfer.Visible = false;
        bConfirm.Visible = true;
        tLocationID.Enabled = true;
        tPalletID.Enabled = true;
        tQuantity.Enabled = true;
        ddlUnit.Enabled = true;

        tLocationID.Focus();
    }

}

