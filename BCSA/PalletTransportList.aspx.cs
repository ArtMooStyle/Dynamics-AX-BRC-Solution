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

public partial class _PalletTransportList : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
            tForkliftID.Focus();
    }

    protected void bForkliftInfo_Click(object sender, EventArgs e)
    {
        /*
        bAll.PostBackUrl = "PalletTransportSelectBlock.aspx?TransportType=ALL";
        bIn.PostBackUrl = "PalletTransportSelectBlock.aspx?TransportType=IN";
        bOut.PostBackUrl = "PalletTransportSelectBlock.aspx?TransportType=OUT";
        bRefill.PostBackUrl = "PalletTransportSelectBlock.aspx?TransportType=REFILL";
        if (tForkliftID.Text.Trim() != "")
        {
            bAll.PostBackUrl += "&ForkliftID=" + tForkliftID.Text.Trim();
            bIn.PostBackUrl += "&ForkliftID=" + tForkliftID.Text.Trim();
            bOut.PostBackUrl += "&ForkliftID=" + tForkliftID.Text.Trim();
            bRefill.PostBackUrl += "&ForkliftID=" + tForkliftID.Text.Trim();
        }*/
    }

    protected void bAllClick(object sender, EventArgs e)
    {
        Redirect("ALL");
    }

    protected void bInClick(object sender, EventArgs e)
    {
        Redirect("IN");
    }

    protected void bOutClick(object sender, EventArgs e)
    {
        Redirect("OUT");
    }

    protected void bRefillClick(object sender, EventArgs e)
    {
        Redirect("REFILL");
    }
    
    protected void Redirect(string type)
    {
        string url = "PalletTransportSelectBlock.aspx?TransportType=" + type;
        if (tForkliftID.Text.Trim() != "") url += "&ForkliftID=" + tForkliftID.Text.Trim();
        Response.Redirect(url);
    }


}

