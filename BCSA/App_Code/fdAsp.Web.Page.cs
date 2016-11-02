using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace fdAsp.Web
{
    public class Page : System.Web.UI.Page
    {
        public string TermID = "";
        public string LangID = "";
        public string CompanyID = "";
        public string PIN = "";
        public string Rights = "";
        CultureInfo ci = new CultureInfo("cs");

        public Page()
            : base()
        {
            if (!IsPostBack)
            {
            }
        }

        protected override void OnError(EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
        }

        protected override void InitializeCulture()
        {
            //base.InitializeCulture();
            Common.LoadCookieInfo(Request, out TermID, out LangID, out CompanyID, out PIN, out Rights);

            ci = new CultureInfo(LangID);
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }

        protected override void OnLoad(EventArgs e)
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            if (ConfigurationManager.AppSettings.Get("debug") == "true")
            {
                writer.WriteLine(String.Format(@"
  <div style='margin-top: 0.5em; border-top: 1px solid #000000'>
  TermID: {0} <br/>
  LangID: {1} <br/>
  CompanyID: {2} <br/>
  PIN: {3} <br/>
  Rights: {4}", TermID, LangID, CompanyID, PIN, Rights));
            }
        }
    }
}
