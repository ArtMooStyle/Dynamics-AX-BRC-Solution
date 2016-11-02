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

public partial class _index : fdAsp.Web.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        string tid = Common.NullToStr(Request.QueryString["TermID"]);
        string lid = Common.NullToStr(Request.QueryString["LangID"]);
        if (tid != "") TermID = tid;
        if (lid != "") LangID = lid;

        Common.SaveCookieInfo(Response, TermID, LangID, CompanyID, PIN, Rights);

        if (!Rights.Contains("[1]")) bPallets.Visible = false;
    }
}

