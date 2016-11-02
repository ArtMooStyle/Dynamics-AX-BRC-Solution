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

public partial class _PalletTransportSelectBlock : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            string ShowPopup = Common.NullToStr(Request.QueryString["ShowPopup"]);
            if (ShowPopup == "1")
            {
                transportCount.Text = "1";
                transportComplete.Visible = true;
            }
            ReLoadTable();
            tPalletID.Focus();
        }
    }

    protected void ReLoadTable()
    {
        string TransportType = Common.NullToStr(Request.QueryString["TransportType"]);
        string ForkliftID = Common.NullToStr(Request.QueryString["ForkliftID"]);
        string filter = ddlLocation.Text;
        if (filter == "") filter = Common.NullToStr(Request.QueryString["Filter"]);

        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            int WS_TT = -1;
            switch (TransportType)
            {
                case "ALL":
                    WS_TT = 100; break;
                case "IN":
                    WS_TT = 0; break;
                case "OUT":
                    WS_TT = 1; break;
                case "REFILL":
                    WS_TT = 3; break;
            }

            string result = svc.PalletTransportList(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(ForkliftID), WS_TT)[0];
            // OFFLINE DEBUGGING
            if (ConfigurationManager.AppSettings.Get("offline") == "true")
            {
                result = "SF2.1;term11;25.2.2016 9:51:17;OK;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;7 085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;8 085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;9 085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;10 085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132254;RM;01;0;;3;Doplnit;HBD1;pick;176084;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132261;RM;01;0;;3;Doplnit;HBD2;pick;176085;624203 Kolibri Combed classic 60x60;3;Aktivováno;085956116002132278;RM;01;0;;3;Doplnit;HBD2;pick;176086;624203 Kolibri Combed classic 60x60";
            }
            string[] r = result.Split(';');

            ddlLocation.Items.Clear();
            ddlLocation.Items.Add("");

            if ((r.Length >= 3) && (r[3] == "OK"))
            {
                lInfo.Text = "";
                lInfo.ForeColor = Color.Black;

                lTable.Text = "<table><tbody>"; //GetLocalResourceObject("res_Table_Format").ToString();
                int row = 0;
                for (int i = 4; i < r.Length; i += 13)
                {
                    string outputLoc = r[i + 9] + "/" + r[i + 10];
                    ListItem it = new ListItem(outputLoc);
                    if (!ddlLocation.Items.Contains(it)) ddlLocation.Items.Add(it);

                    if ((filter == "") || (filter == outputLoc))
                    {
                        row++;
                        string urlargs = "&Status=" + r[i] + "&From=" + r[i + 3] + "/" + r[i + 4] + "&TransportType=" + TransportType + "&ForkliftID=" + ForkliftID + "&Warehouse=" + r[i + 9] + "&Location=" + r[i + 10] + "&TransportID=" + r[i + 11] + "&Filter=" + filter;
                        if (row == 1)
                        {
                            lFirstPalletId.Text = r[i + 2];
                            lFirstTransportId.Text = r[i + 11];
                            lFirstWarehouse.Text = r[i + 9];
                            lFirstLocation.Text = r[i + 10];
                            lFirstURLArgs.Text = urlargs;
                        }
                        string url = "PalletTransportStart.aspx?PalletID=" + r[i + 2] + urlargs;
                        //lTable.Text += "<tr><td class='tabcell'>" + r[i] + "</td><td class='tabcell' style='font-size: 10pt'><a href='" + url + "'>" + r[i + 2] + "</a></td><td class='tabcell'>" + r[i + 12] + "</td><td class='tabcell'>" + r[i + 3] + "/" + r[i + 4] + "</td><td class='tabcell'>" + r[i + 9] + "/" + r[i + 10] + "</td>";
                        if (row % 2 == 0) 
                            lTable.Text += "<tr><td class='tabcell' style='width: 230px; line-height: 13pt;padding: 2px'>";
                        else
                            lTable.Text += "<tr><td class='tabcell' style='width: 230px; line-height: 13pt;padding: 2px;background-color: #E0E0FF'>";
                        lTable.Text += "<span style='font-size: 12pt'>" + r[i + 12] + "</span><br/>";
                        lTable.Text += "<span style='font-size: 11pt'><a href='" + url + "'>" + r[i + 2] + "</a></span><br/>";
                        lTable.Text += "<span style='font-size: 11pt; font-weight: bold;border: 0;margin: 0;padding:0;'>" + GetLocalResourceObject("res_Table_Output_From").ToString() + ": " + r[i + 3] + "/" + r[i + 4] + "</span> &nbsp; ";
                        lTable.Text += "<span style='font-size: 11pt; font-weight: bold;border: 0;margin: 0;padding:0'>" + GetLocalResourceObject("res_Table_Output_To").ToString() + ": " + outputLoc + "</span>";

                        /*
                        if (row == 3)
                        {
                            lTable.Text += "<a href='#drow4'><img style='position: absolute; left: 205px;' src='images/arrowd.jpg'/></a>";
                        }
                        else if (row == 4)
                        {
                            lTable.Text += "<a name='drow4'></a>";
                        }
                        else if (row == 7)
                        {
                            lTable.Text += "<img onclick='javascript:window.scrollTo(0, 0)' style='position: absolute; left: 173px;' src='images/arrowu.jpg'/>";
                            lTable.Text += "<a href='#drow8'><img style='position: absolute; left: 205px;' src='images/arrowd.jpg'/></a>";
                        }
                        else if (row == 8)
                        {
                            lTable.Text += "<a name='drow8'></a>";
                        }
                        else if ((row >= 11) && ((row - 11) % 4 == 0))
                        {
                            lTable.Text += "<a href='#drow" + (row - 7).ToString() + "'><img style='position: absolute; left: 173px;' src='images/arrowu.jpg'/></a>";
                            lTable.Text += "<a href='#drow" + (row + 1).ToString() + "'><img style='position: absolute; left: 205px;' src='images/arrowd.jpg'/></a>";
                        }
                        else if ((row >= 12) && ((row - 12) % 4 == 0))
                        {
                            lTable.Text += "<a name='drow" + row.ToString() + "'></a>";
                        }
                        */

                        lTable.Text += "</td></tr>";
                    }
                }
                lTable.Text += "</tbody></table>";

                lTable.Text += "<img onclick='javascript:window.scrollTo(0, 280)' style='position: absolute; left: 205px; top: 250px' src='images/arrowd.jpg'/>";
                for (int i = 1; i < 20; i++)
                {
                    lTable.Text += "<img onclick='javascript:window.scrollTo(0, " + (280*(i-2)).ToString() + ")' style='position: absolute; left: 205px; top: " + (280*(i+1)-32-30).ToString() + "px' src='images/arrowu.jpg'/>";
                    lTable.Text += "<img onclick='javascript:window.scrollTo(0, " + (280*(i+1)).ToString() + ")' style='position: absolute; left: 205px; top: " + (280 * (i + 1)-30).ToString() + "px' src='images/arrowd.jpg'/>";
                }

                if (filter != "") ddlLocation.Text = filter;
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

    protected void bLocation_Click(object sender, EventArgs e)
    {
        ReLoadTable();
        tPalletID.Focus();
    }

    protected void bPalletInfo_Click(object sender, EventArgs e)
    {

        string enteredPalletId = tPalletID.Text.Trim();
        if (enteredPalletId.StartsWith("00")) enteredPalletId = enteredPalletId.Substring(2);
        tPalletID.Text = "";
        tPalletID.Focus();
        if (enteredPalletId == "") return;

        BCSWSReference.BCSWS svc = new BCSWSReference.BCSWS();
        try
        {
            if (lFirstPalletId.Text == enteredPalletId)
            {
                string result = svc.StartPalletTransport(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(enteredPalletId), Server.HtmlEncode(lFirstTransportId.Text))[0];
                // OFFLINE DEBUGGING
                if (ConfigurationManager.AppSettings.Get("offline") == "true")
                {
                    result = "SF2.3;term11;25.2.2016 9:10:14;OK;HBD1;pick";
                }

                string[] r = result.Split(';');

                if ((r.Length >= 5) && (r[3] == "OK"))
                {
                    result = svc.CompletePalleteTransport(TermID, DateTime.Now, LangID, PIN, Server.HtmlEncode(enteredPalletId), Server.HtmlEncode(lFirstWarehouse.Text.Trim()), Server.HtmlEncode(lFirstLocation.Text.Trim()))[0];
                    // OFFLINE DEBUGGING
                    if (ConfigurationManager.AppSettings.Get("offline") == "true")
                    {
                        result = "SF2.4;term11;25.2.2016 9:11:29;OK";
                    }

                    r = result.Split(';');

                    if ((r.Length >= 4) && (r[3] == "OK"))
                    {
                        //Response.Redirect("PalletTransportSelectBlock.aspx?TransportType=" + TransportType + "&ForkliftID=" + ForkliftID + "&Filter=" + Filter);
                        ReLoadTable();
                        transportCount.Text = "2";
                        transportComplete.Visible = true;
                    }
                    else
                    {
                        if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                        lInfo.ForeColor = Color.Red;
                    }
                }
                else
                {
                    if (r.Length >= 5) lInfo.Text = r[4]; else lInfo.Text = r[0];
                    lInfo.ForeColor = Color.Red;
                }
            }
            else
            {
                string url = "PalletTransportStart.aspx?PalletID=" + lFirstPalletId.Text + lFirstURLArgs.Text + "&NewPalletID=" + enteredPalletId;
                Response.Redirect(url);
            }
        }
        finally
        {
            //svc.Close();
        }
    }
}


