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
using System.Threading;
using System.Globalization;

public partial class _Test : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

    }

    protected void bConfirm_Click(object sender, EventArgs e)
    {
        string parameter = Request["__EVENTARGUMENT"]; // parameter
        if (parameter == "") return;

        int tcount = int.Parse(parameter.Substring(12));
        parameter = parameter.Substring(0, 12);

        CultureInfo provider = CultureInfo.InvariantCulture;
        string format = "HH:mm:ss.fff";

        DateTime dtC = DateTime.ParseExact(parameter, format, provider);
        DateTime dtS = DateTime.Now;
        TimeSpan ts = dtS - dtC;
        string tmp = "";
        if (lS.Text != "")
        {
            DateTime dtL = DateTime.ParseExact(lS.Text.Substring(47, 12), format, provider);
            TimeSpan t2 = dtS - dtL;
            if (t2.TotalMilliseconds > 3999)
                tmp = "<span style='color: red; font-size: 9pt'>";
            else
                tmp = "<span style='color: green; font-size: 9pt'>";
            tmp += ((int)t2.TotalMilliseconds).ToString() + "</span>";

            string pcount = lS.Text.Substring(60, 8);
            int pi = pcount.IndexOf(' ');
            if (pi > 0) pcount = pcount.Substring(0, pi);

            if (pcount != (tcount - 1).ToString())
            {
                WriteLine(String.Format("<span style='font-size: 8pt; font-weight: bold; color: red'>Client request lost!</span>"));
            }
        }

        string tmp2 = "";
        if (ts.TotalMilliseconds > 3999)
            tmp2 = "<span style='color: red; font-size: 9pt'>";
        else
            tmp2 = "<span style='color: green; font-size: 9pt'>";
        tmp2 += ((int)ts.TotalMilliseconds).ToString() + "</span>";

        string tmp3 = tcount.ToString();
        string line = String.Format("<span style='font-size: 8pt'>{0:HH:mm:ss.fff} {1:HH:mm:ss.fff} {4} {2} {3}</span>", dtC, dtS, tmp2, tmp, tmp3);
        WriteLine(line);
    }

    protected void WriteLine(string line)
    {
        lS.Text = "<div>" + line + "</div>" + lS.Text;

        int p = 0;
        for (int i = 0; i < 10; i++)
        {
            p = lS.Text.IndexOf("<div>", p + 1);
            if (p == -1) break;
        }
        if (p > 0)
            lS.Text = lS.Text.Substring(0, p);

        line = "<div><span style='font-weight: bold'>" + TermID + "</span> " + line + "</div>";
        using (TextWriter writer = new StreamWriter(@"C:\Inetpub\Wwwroot\BCSA_TEST\TEST.html", true))
        {
            writer.WriteLine(line);
            writer.Close();
        }
    }
}

