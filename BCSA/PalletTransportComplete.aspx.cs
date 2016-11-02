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

public partial class _PalletTransportComplete : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            string TransportType = Common.NullToStr(Request.QueryString["TransportType"]);
            string ForkliftID = Common.NullToStr(Request.QueryString["ForkliftID"]);
            string PalletID = Common.NullToStr(Request.QueryString["PalletID"]);
            string Status = Common.NullToStr(Request.QueryString["Status"]);
            string Warehouse = Common.NullToStr(Request.QueryString["Warehouse"]);
            string Location = Common.NullToStr(Request.QueryString["Location"]);
            string TransportID = Common.NullToStr(Request.QueryString["TransportID"]);
            string EnteredPalletID = Common.NullToStr(Request.QueryString["EnteredPalletID"]);
            string EnteredWarehouse = Common.NullToStr(Request.QueryString["EnteredWarehouse"]);
            string EnteredLocation = Common.NullToStr(Request.QueryString["EnteredLocation"]);

            bBack.PostBackUrl = "PalletTransportStart.aspx?TransportType=" + TransportType + "&ForkliftID=" + ForkliftID + "&PalletID=" + PalletID + "&Status=" + Status + "&Warehouse=" + Warehouse + "&Location=" + Location + "&TransportID=" + TransportID;

            tWarehouse.Text = EnteredWarehouse;
            tLocation.Text = EnteredLocation;
            lTable.Text = String.Format(GetLocalResourceObject("res_Table_Format").ToString(),
                EnteredPalletID, EnteredWarehouse, EnteredLocation);
				
			tWarehouse.Focus();
        }
    }

    protected void bWarehouse_Click(object sender, EventArgs e)
    {
        lLocation.Focus();
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
            string TransportType = Common.NullToStr(Request.QueryString["TransportType"]);
            string ForkliftID = Common.NullToStr(Request.QueryString["ForkliftID"]);
            string PalletID = Common.NullToStr(Request.QueryString["PalletID"]);
            string Status = Common.NullToStr(Request.QueryString["Status"]);
            string Warehouse = Common.NullToStr(Request.QueryString["Warehouse"]);
            string Location = Common.NullToStr(Request.QueryString["Location"]);
            string TransportID = Common.NullToStr(Request.QueryString["TransportID"]);
            string EnteredPalletID = Common.NullToStr(Request.QueryString["EnteredPalletID"]);
            string EnteredWarehouse = Common.NullToStr(Request.QueryString["EnteredWarehouse"]);
            string EnteredLocation = Common.NullToStr(Request.QueryString["EnteredLocation"]);
            string Filter = Common.NullToStr(Request.QueryString["Filter"]);
            string result = svc.CompletePalleteTransport(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(EnteredPalletID), Server.HtmlEncode(tWarehouse.Text.Trim()), Server.HtmlEncode(tLocation.Text.Trim()))[0];
            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                result = "SF2.4;term11;25.2.2016 9:11:29;OK";
            }

            string[] r = result.Split(';');

            if ((r.Length >= 4) && (r[3] == "OK"))
            {
                Response.Redirect("PalletTransportSelectBlock.aspx?TransportType=" + TransportType + "&ForkliftID=" + ForkliftID + "&Filter=" + Filter);
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

