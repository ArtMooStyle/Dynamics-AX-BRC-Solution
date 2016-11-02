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

public partial class _Settings : fdAsp.Web.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            ddlLang.SelectedValue = LangID;
        }
    }

    protected void ddlLang_SelectedIndexChanged(object sender, EventArgs e)
    {
        LangID = ddlLang.SelectedValue;
        Common.SaveCookieInfo(Response, TermID, LangID, CompanyID, PIN, Rights);
        Response.Redirect("Settings.aspx");
    }
}

