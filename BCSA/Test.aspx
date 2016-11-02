<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="_Test" validateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="Settings.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Test"/></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
                 </td>
             </tr>
         </table>


  <div> <asp:Button ID="bConfirm" runat="server" Text="AUTOTEST" OnClick="bConfirm_Click" CssClass="button" style="text-align: center;" OnClientClick="currentTime()" Width="11.2em" Height="2.4em" UseSubmitBehavior="false"/> </div>

     <table><tr>
         <td>
             <asp:Label ID="lC" runat="server" Text=""/>
             </td><td>
             <asp:Label ID="lS" runat="server" Text=""/>
                 </td></tr></table>
  
  
         <script type="text/javascript" language="javascript">
             function getCookie(cname) {
                 var name = cname + "=";
                 var ca = document.cookie.split(';');
                 for (var i = 0; i < ca.length; i++) {
                     var c = ca[i];
                     while (c.charAt(0) == ' ') {
                         c = c.substring(1);
                     }
                     if (c.indexOf(name) == 0) {
                         return c.substring(name.length, c.length);
                     }
                 }
                 return "";
             }
    function currentTime()
    {
        var cd = new Date(); 
        var ct = (cd.getHours() >= 10) ? cd.getHours() : "0" + cd.getHours();
        ct = ct + ":";
        if (cd.getMinutes() >= 10)
            ct = ct + cd.getMinutes();
        else
            ct = ct + "0" + cd.getMinutes();
        ct = ct + ":";
        if (cd.getSeconds() >= 10)
            ct = ct + cd.getSeconds();
        else
            ct = ct + "0" + cd.getSeconds();
        ct = ct + ".";
        if (cd.getMilliseconds() < 10)
            ct += "00" + cd.getMilliseconds();
        else if (cd.getMilliseconds() < 100)
            ct += "0" + cd.getMilliseconds();
        else
            ct += cd.getMilliseconds();

        var tmp = getCookie("tcount");
        if (tmp == "") tmp = "1";
        var tcount = parseInt(tmp);

        ct = ct + " " + tcount;
        tcount = tcount + 1;
        document.cookie = "tcount=" + tcount;

        //document.getElementById("ctl00_phldMain_lS").innerText += "xyz";
        __doPostBack('ctl00$phldMain$bConfirm', ct);
        //window.setTimeout('currentTime()', 1000);
    }
    window.setTimeout('currentTime()', 2000);
    </script>

 </asp:Panel>
</div>
</asp:Content>