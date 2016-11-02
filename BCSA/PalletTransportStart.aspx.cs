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

public partial class _PalletTransportStart : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            string TransportType = Common.NullToStr(Request.QueryString["TransportType"]);
            string ForkliftID = Common.NullToStr(Request.QueryString["ForkliftID"]);
            string PalletID = Common.NullToStr(Request.QueryString["PalletID"]);
            string NewPalletID = Common.NullToStr(Request.QueryString["NewPalletID"]);
            string Status = Common.NullToStr(Request.QueryString["Status"]);
            string From = Common.NullToStr(Request.QueryString["From"]);
            string Warehouse = Common.NullToStr(Request.QueryString["Warehouse"]);
            string Location = Common.NullToStr(Request.QueryString["Location"]);
            string TransportID = Common.NullToStr(Request.QueryString["TransportID"]);
            string Filter = Common.NullToStr(Request.QueryString["Filter"]);
            bBack.PostBackUrl = "PalletTransportSelectBlock.aspx?TransportType=" + TransportType + "&ForkliftID=" + ForkliftID + "&Filter=" + Filter;
            //lInfo.Text = lInfo.Text + " " + ForkliftID;

            lTable.Text = String.Format(GetLocalResourceObject("res_Table_Format").ToString(), TransportID, From, Warehouse + "/" + Location, PalletID);

            tPalletID.Text = NewPalletID;
			tPalletID.Focus();
        }
    }

    protected void AdjustPalletId()
    {
        tPalletID.Text = tPalletID.Text.Trim();
        if ((lOldPalletID.Text != "") && (tPalletID.Text.Length > lOldPalletID.Text.Length) && (tPalletID.Text.EndsWith(lOldPalletID.Text)))
            tPalletID.Text = tPalletID.Text.Substring(0, tPalletID.Text.Length - lOldPalletID.Text.Length);
        lOldPalletID.Text = tPalletID.Text;
    }

    protected void bPallet_Click(object sender, EventArgs e)
    {
        AdjustPalletId();
        bConfirm.Focus();
    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            AdjustPalletId();
            string TransportType = Common.NullToStr(Request.QueryString["TransportType"]);
            string ForkliftID = Common.NullToStr(Request.QueryString["ForkliftID"]);
            string PalletID = Common.NullToStr(Request.QueryString["PalletID"]);
            string Status = Common.NullToStr(Request.QueryString["Status"]);
            string Warehouse = Common.NullToStr(Request.QueryString["Warehouse"]);
            string Location = Common.NullToStr(Request.QueryString["Location"]);
            string TransportID = Common.NullToStr(Request.QueryString["TransportID"]);
            string Filter = Common.NullToStr(Request.QueryString["Filter"]);
            string result = svc.StartPalletTransport(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tPalletID.Text.Trim()), Server.HtmlEncode(TransportID))[0];
            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                result = "SF2.3;term11;25.2.2016 9:10:14;OK;HBD1;pick";
            }

            string[] r = result.Split(';');

            if ((r.Length >= 5) && (r[3] == "OK"))
            {
                result = svc.CompletePalleteTransport(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(tPalletID.Text.Trim()), Server.HtmlEncode(Warehouse), Server.HtmlEncode(Location))[0];

                // OFFLINE DEBUGGING
                if (ConfigurationManager.AppSettings.Get("offline") == "true")
                {
                    result = "SF2.4;term11;25.2.2016 9:11:29;NOK";
                }

                r = result.Split(';');

                if ((r.Length >= 4) && (r[3] == "OK"))
                {
                    Response.Redirect("PalletTransportSelectBlock.aspx?TransportType=" + TransportType + "&ForkliftID=" + ForkliftID + "&Filter=" + Filter + "&ShowPopup=1");
                }
                else
                {
                    if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                    lInfo.ForeColor = Color.Red;
                    //bConfirm.Enabled = true;
                }
                //Response.Redirect("PalletTransportComplete.aspx?TransportType=" + TransportType + "&ForkliftID=" + ForkliftID + "&PalletID=" + PalletID + "&Status=" + Status + "&Warehouse=" + Warehouse + "&Location=" + Location + "&TransportID=" + TransportID + "&EnteredPalletID=" + Server.HtmlEncode(tPalletID.Text.Trim()) + "&EnteredWarehouse=" + r[4] + "&EnteredLocation=" + r[5] + "&Filter=" + Filter);
            }
            else
            {
                if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                lInfo.ForeColor = Color.Red;
                bConfirm.Enabled = true;
                //bConfirm.Focus();
            }
        }
        finally
        {
            //svc.Close();
        }
    }
}

