using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Collections;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace fdAsp.Web
{
    // Common functions
    static public class Common
    {
        static public string StrLeft(string s, int len)
        {
            if (len <= 0)
                return "";
            else if (s.Length < len)
                return s;
            else
                return s.Substring(0, len);
        }

        static public string StrRight(string s, int len)
        {
            if (len <= 0)
                return "";
            else if (s.Length < len)
                return s;
            else
                return s.Substring(s.Length - len);
        }

        static public string ReplaceDecimal(string n)
        {
            return n.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
        }

        static public double StringToDecimal(string n)
        {
            if ((n == null) || (n.Trim() == ""))
                return 0;
            else
                return Convert.ToDouble(n.Trim().Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator).Replace(",", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator));
        }

        static public string MSSQLDateTime(DateTime d)
        {
            return "'" + d.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        }

        static public string MSSQLDate(DateTime d)
        {
            return "'" + d.ToString("yyyy-MM-dd") + "'";
        }

        static public string FIXLeft(object o, int len)
        {
            string s = o.ToString();
            if (s.Length > len)
                return s.Substring(0, len);
            else
                return s.PadRight(len);
        }

        static public string FIXDate(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return FIXLeft("", 6);
            else
                return Convert.ToDateTime(o).ToString("ddMMyy"); 
        }

        static public string FIXReal(object o, int len)
        {
            if ((o == null) || (o == DBNull.Value))
                return FIXLeft("0", len);
            else
                return FIXLeft(Convert.ToDouble(o).ToString("0.00"), len);
        }

        /*static public void AddFilterElement(ref string fil, string field, int datatype, string value)
        {
            string newfil = "";
            bool first = false, pack = false;
            string OP;  // =, <>, <, >, <=, >=
            string val;
            string log; // AND, OR
            string s, t, v1, v2;
            int i1, i2, m;
            DateTime dt;
            bool doSkip;

            if ((value.Trim()).Length == 0) return;

            field = "[" + field + "]";

            if (fil != "")
            {
                fil += " AND (";
                first = true;
            }

            value = value.Replace('*', '%');
            s = value.ToUpper() + " " + Resources.strings.Filtering_AND + " ";

            // separating filter to operands and operators
            while (s != "") 
            // --- BEGIN --- of while
            {
                i1 = s.IndexOf(" " + Resources.strings.Filtering_AND + " ");
                i2 = s.IndexOf(" " + Resources.strings.Filtering_OR + " ");

                log = "";
                if ((i1 > 0) && ((i2 <= 0) || (i1 < i2)))
                {
                    log = Resources.strings.Filtering_AND;
                    t = (StrLeft(s, i1)).Trim(); 
                    s = (StrRight(s, s.Length - i1 - 4));
                }
                else if ((i2 > 0) && ((i1 <= 0) || (i2 < i1)))
                {
                    log = Resources.strings.Filtering_OR;
                    t = (StrLeft(s, i2)).Trim();
                    s = (StrRight(s, s.Length - i2 - 4));
                }
                else
                {
                    s = "";
                    goto Skip;
                }
                
                v1 = (StrLeft(t + " ", 1)).Trim();
                v2 = (StrLeft(t + "  ", 2)).Trim();
                m = t.Length;

                if ((v2 == "<=") || (v2 == "=<"))
                {
                    OP = "<=";
                    val = (StrRight(t, m - 2)).Trim();
                }
                else if ((v2 == ">=") || (v2 == "=>"))
                {
                    OP = ">=";
                    val = (StrRight(t, m - 2)).Trim();
                }
                else if ((v2 == "><") || (v2 == "<>") || (v2 == "!="))
                {
                    if (datatype == 0)
                        OP = "NOT LIKE";
                    else
                        OP = "<>";
                    val = (StrRight(t, m - 2)).Trim();
                    goto Cont;
                }
                else if (v1 == "<")
                {
                    OP = "<";
                    val = (StrRight(t, m - 1)).Trim();
                }
                else if (v1 == ">")
                {
                    OP = ">";
                    val = (StrRight(t, m - 1)).Trim();
                }
                else if (v1 == "=")
                {
                    OP = "=";
                    val = (StrRight(t, m - 1)).Trim();
                }
                else
                {
                    // default operator
                    if (datatype == 0)
                        OP = "LIKE";
                    else
                        OP = "=";
                    val = t;
                }

            Cont:

                doSkip = false;

                // for "NULL" keyword replace OPs and treat all as number datatype
                if (val.Trim().ToUpper() == Resources.strings.Filtering_NULL)
                {
                    datatype = 2;
                    switch (OP)
                    {
                        case "=":
                        case "LIKE":
                            OP = "IS"; break;
                        case "<>":
                        case "NOT LIKE":
                            OP = "IS NOT"; break;
                    }
                }

                switch (datatype)
                {
                    case 0: // varchar
                        if ((val != "") && (val[val.Length-1] != '%')) val += "%";
                        val = field + " " + OP + " '" + val + "'";
                        break;
                    
                    case 1: // datetime
                        if (val == Resources.strings.Filtering_TODAY) val = DateTime.Today.ToString();

                        if (DateTime.TryParse(val, out dt))
                        {
                            if ((OP == "=") && (dt == dt.Date))
                            {
                                // for only date specified construct 24hour interval for datetime values 
                                val = "(" + field + ">=" + MSSQLDateTime(dt) + " AND " + field + "<" + MSSQLDateTime(dt.AddDays(1)) + ")";
                            }
                            else
                            {
                                val = field + " " + OP + " " + MSSQLDateTime(dt);
                            }
                        }
                        else
                            doSkip = true;
                        break;
                    
                    case 2: // number
                        val = field + " " + OP + " " + ReplaceDecimal(val);
                        break;
                }
                
                if (doSkip) goto Skip;
                if (s.Trim() != "") val = "(" + val + ") " + log + " ";
                if (newfil != "") 
                {
                    val = "(" + val + ")";
                    pack = true;
                }
                newfil += val;

            Skip:
                ;

            // --- END --- of while
            } 

            if (pack) newfil = "(" + newfil + ")";
            fil += newfil;
            if (first) fil += ")";
        }
    */ 

        public static string NullToStr(string s)
        {
            if (s == null)
                return "";
            else
                return s;
        }

        public static string EmptyStrToSQLNULL(string s)
        {
            if ((s == null) || (s == ""))
                return "NULL";
            else
                return s;
        }

        public static object SQLNULLToDBNull(string s)
        {
            if ((s == null) || (s == "") || (s == "NULL"))
                return DBNull.Value;
            else
                return s;
        }

        public static string GetSubstring(string s, string left, string right)
        {
            int p1 = s.IndexOf(left);
            if (p1 < 0) return "";

            p1 = p1 + left.Length;
            int p2 = s.IndexOf(right, p1);
            if (p2 < 0) return "";

            return s.Substring(p1, p2 - p1);
        }

        public static string SafeEncode(string s)
        {
            return HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes(s));
        }

        public static string SafeDecode(string s)
        {
            if (s == null)
            {
                return "";
            }
            else
            {
                return Encoding.UTF8.GetString(HttpServerUtility.UrlTokenDecode(s));
            }
        }

        public static string SafeFilename(string filename)
        {
            return filename.Replace('/', '_').Replace('?', '_');
        }

        public static string PasswordHash(string plaintext)
        {
            System.Security.Cryptography.SHA1CryptoServiceProvider CSP = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            MemoryStream memstr = new System.IO.MemoryStream();
            BinaryWriter wr = new BinaryWriter(memstr, System.Text.Encoding.UTF8);
            BinaryReader re = new BinaryReader(memstr, System.Text.Encoding.UTF8);
            wr.Write(plaintext);
            wr.Flush();
            memstr.Seek(0, SeekOrigin.Begin);
            byte[] PassHashB = CSP.ComputeHash(re.ReadBytes((int)memstr.Length));
            string PassHash = System.Convert.ToBase64String(PassHashB);
            memstr.Close();
            return PassHash;
        }

        public static string GenerateRandomCode(string allowedChars, int codeLength)
        {
            char[] chars = new char[codeLength];
            Random rd = new Random();

            for (int i = 0; i < codeLength; i++)
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];

            return new string(chars);
        }

        public static string FormatToRegExp(string format)
        {
            // CS
            // - dd.MM.yyyy - @"([0-2]?[0-9]|3[0-1])\.(0?[0-9]|1[0-2])\.(|[0-1][0-9]|[1-2][0-9]{3})$";
            // - dd.MM.yyyy H:mm:ss - @"([0-2]?[0-9]|3[0-1])\.(0?[0-9]|1[0-2])\.(|[0-1][0-9]|[1-2][0-9]{3})$|([0-2]?[0-9]|3[0-1])\.(0?[0-9]|1[0-2])\.(|[0-1][0-9]|[1-2][0-9]{3})\s([0-1]?[0-9]|2[0-3]):([0-5]?[0-9]):?(|[0-5]?[0-9])$";
            format = format.Replace("dd", @"([0-2]?[0-9]|3[0-1])");
            format = format.Replace("MM", @"(0?[0-9]|1[0-2])");
            format = format.Replace("yyyy", @"(|[0-1][0-9]|[1-2][0-9]{3})");
            format = format.Replace(".", @"\.");
            format = format.Replace(" ", @"\s");
            format = format.Replace("H", @"([0-1]?[0-9]|2[0-3])");
            format = format.Replace("mm", @"([0-5]?[0-9])");
            format = format.Replace("ss", @"?(|[0-5]?[0-9])");
            // EN
            // - M/d/yyyy
            // - M/d/yyyy h:mm:ss tt
            format = format.Replace("d", @"([0-2]?[0-9]|3[0-1])");
            format = format.Replace("M", @"(0?[0-9]|1[0-2])");
            format = format.Replace("/", @"\/");
            format = format.Replace("h", @"([0-1]?[0-9]|2[0-3])");
            format = format.Replace("tt", @"(AM|PM)");
            return format + "$";
        }

        public static string Format(string format, params object[] arg)
        {
            format = format.Replace("\\n", "\n");
            format = format.Replace("\\t", "\t");
            return String.Format(format, arg);
        }

        public static void GetRequestHeaderVariable(ref HttpRequest req, ref string output, string variable)
        {
            output += "<td>" + variable + "</td><td>" + req.ServerVariables[variable] + "</td> </tr><tr>";
        }

        public static void GetRequestInfo(HttpRequest req, out string ip, out string output)
        {
            ip = req.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = req.ServerVariables["REMOTE_ADDR"];
                if (string.IsNullOrEmpty(ip))
                {
                    ip = req.UserHostAddress;
                }
            }
            
            output = "<table><thead></thead><tbody><tr>";
            output += "<td>IP</td><td>" + ip + "</td></tr><tr>";

            GetRequestHeaderVariable(ref req, ref output, "HTTP_USER_AGENT");
            GetRequestHeaderVariable(ref req, ref output, "HTTP_HOST");
            GetRequestHeaderVariable(ref req, ref output, "HTTP_REFERER");
            GetRequestHeaderVariable(ref req, ref output, "LOGON_USER");
            GetRequestHeaderVariable(ref req, ref output, "PATH_INFO");
            GetRequestHeaderVariable(ref req, ref output, "PATH_TRANSLATED");
            GetRequestHeaderVariable(ref req, ref output, "QUERY_STRING");
            GetRequestHeaderVariable(ref req, ref output, "REMOTE_ADDR");
            GetRequestHeaderVariable(ref req, ref output, "REMOTE_HOST");
            GetRequestHeaderVariable(ref req, ref output, "REMOTE_USER");
            GetRequestHeaderVariable(ref req, ref output, "REQUEST_METHOD");
            GetRequestHeaderVariable(ref req, ref output, "SCRIPT_NAME");
            GetRequestHeaderVariable(ref req, ref output, "SERVER_NAME");
            GetRequestHeaderVariable(ref req, ref output, "SERVER_PORT");
            GetRequestHeaderVariable(ref req, ref output, "SERVER_PORT_SECURE");
            GetRequestHeaderVariable(ref req, ref output, "SERVER_PROTOCOL");
            GetRequestHeaderVariable(ref req, ref output, "SERVER_SOFTWARE");
            GetRequestHeaderVariable(ref req, ref output, "URL");

            output += "</tr></tbody></table>";
        }

        public static string SanitizeHtml(string text)
        {
            return text.Replace(">", "&gt;").Replace("<", "&lt;");
        }

        public static object SanitizeDBValue(object DBValue)
        {
            if ((DBValue != null) && (DBValue != DBNull.Value) && (DBValue is string))
                return DBValue.ToString().Replace(">", "&gt;").Replace("<", "&lt;");
            else
                return DBValue;
        }

        public static string ReplaceFirstOccurence(string original, string oldValue, string newValue)
        {
            int location = original.IndexOf(oldValue);

            if (location < 0)
                return oldValue;
            else
                return original.Remove(location, oldValue.Length).Insert(location, newValue);
        }

        public static bool ValidEmail(string email)
        {
            Regex rEmail = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[a-z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)$");
            if ((email.Length < 6) || (!rEmail.IsMatch(email)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Common data
        public static string CurrentLogo = "dcz";

        public static void LoadCookieInfo(HttpRequest Request, out string TermID, out string LangID, out string CompanyID, out string PIN, out string Rights)
        {
            TermID = "";
            LangID = "";
            CompanyID = "";
            PIN = "";
            Rights = "";
            HttpCookie cookie = Request.Cookies["BCSA"];
            if (cookie != null)
            {
                TermID = Common.NullToStr(cookie.Values["TermID"]);
                LangID = Common.NullToStr(cookie.Values["LangID"]);
                CompanyID = Common.NullToStr(cookie.Values["CompanyID"]);
                PIN = Common.NullToStr(cookie.Values["PIN"]);
                Rights = Common.NullToStr(cookie.Values["Rights"]);
            }
            if (CompanyID == "") CurrentLogo = "dcz"; else CurrentLogo = CompanyID;
            if (LangID == "") LangID = "en-gb";
        }

        public static void SaveCookieInfo(HttpResponse Response, string TermID, string LangID, string CompanyID, string PIN, string Rights)
        {
            HttpCookie cookie = new HttpCookie("BCSA");
            cookie.Values.Add("TermID", TermID);
            if (LangID == "") LangID = "en-gb";
            cookie.Values.Add("LangID", LangID);
            cookie.Values.Add("CompanyID", CompanyID);
            cookie.Values.Add("PIN", PIN);
            cookie.Values.Add("Rights", Rights);
            cookie.Expires = DateTime.Now.AddDays(14);
            Response.Cookies.Add(cookie);
        }

        public static string Logo(HttpRequest Request)
        {
            return "Images/logo_" + CurrentLogo + "_s.jpg"; // smaller version for testing!
        }

        public static string DisplaySvcOutput(string[] result)
        {
            string r = "";
            for (int i = 0; i < result.Length; i++)
                r += String.Format("[{0}] {1}<br/>", i, result[i]);
            return r;
        }

    }
}
