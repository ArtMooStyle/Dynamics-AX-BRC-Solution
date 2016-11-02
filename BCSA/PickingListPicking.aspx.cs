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

public partial class _PickingListPicking : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            tPickingListID.Focus();
            lLocationID.Visible = false;
            tLocationID.Visible = false;
            lPalletID.Visible = false;
            tPalletID.Visible = false;
            lBatchID.Visible = false;
            tBatchID.Visible = false;
            lQuantity.Visible = false;
            tQuantity.Visible = false;
            lUnit.Visible = false;
            ddlUnit.Visible = false;
        }
    }

    protected void bPicking_Click(object sender, EventArgs e)
    {
		tPickingListItem.Focus();
    }

    protected void bPickingListItem_Click(object sender, EventArgs e)
    {
        bConfirm.Focus();
    }

    protected void bLocation_Click(object sender, EventArgs e)
    {
        FormatLocation();
        tPalletID.Focus();
    }

    protected void bPallet_Click(object sender, EventArgs e)
    {
        AdjustPalletId(); 
        tBatchID.Focus();
    }

    protected void bBatch_Click(object sender, EventArgs e)
    {
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
        lSetup.Text = String.Format(GetLocalResourceObject("res_MSG_Info_format").ToString(), tPickingListID.Text, tPickingListItem.Text);
        lSetup.ForeColor = Color.Black;
        lInfo.Text = "";
    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        if (lPickingListID.Visible)
        {
            lPickingListID.Visible = false;
            tPickingListID.Visible = false;
            lPickingListItem.Visible = false;
            tPickingListItem.Visible = false;

            lLocationID.Visible = true;
            tLocationID.Visible = true;
            lPalletID.Visible = true;
            tPalletID.Visible = true;
            lBatchID.Visible = true;
            tBatchID.Visible = true;
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
            BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
            try
            {
                string result = svc.PickingListPicking(TermID, DateTime.Now, LangID, PIN,
                    Server.HtmlEncode(tPickingListID.Text.Trim()),
                    "",
                    Server.HtmlEncode(tPickingListItem.Text.Trim()),
                    "",
                    "",
                    Server.HtmlEncode(tLocationID.Text.Trim()),
                    Server.HtmlEncode(tPalletID.Text.Trim()),
                    Server.HtmlEncode(tBatchID.Text.Trim()),
                    Common.StringToDecimal(tQuantity.Text),
                    ddlUnit.SelectedValue,
                    false, "")[0];
                string[] r = result.Split(';');

                if ((r.Length >= 4) && (r[3] == "OK"))
                {
                    tLocationID.Text = "";
                    tPalletID.Text = "";
                    tBatchID.Text = "";
                    tQuantity.Text = "";
                    ddlUnit.SelectedValue = "";
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
        }
    }
}

