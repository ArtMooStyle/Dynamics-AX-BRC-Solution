<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="_Settings" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" DefaultButton="bBack" Width="100%">
  <div style="width: 220px; margin-bottom: 0.8em">
   <asp:ImageButton ID="bBack" runat="server" PostBackUrl="index.aspx" ImageUrl="Images/41.jpg"/>
   <img src="<% =fdAsp.Web.Common.Logo(Request) %>"/>
   <br/>
   <h1><asp:Localize ID="lHeader" runat="server" meta:resourcekey="res_lHeader" Text="Settings"/></h1>
  </div>
  <div>
   <span style="width: 10em"><asp:Label ID="lLang" CssClass="label" runat="server" Text="Language:" meta:resourcekey="res_lLang"/></span>
   <asp:DropDownList ID="ddlLang" CssClass="input" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLang_SelectedIndexChanged">
    <asp:ListItem Value="cs" Text="CZ"/>
    <asp:ListItem Value="en-gb" Text="EN"/>
    <asp:ListItem Value="ru" Text="RU"/>
   </asp:DropDownList>
  </span>
  <div style="margin-top: 0.5em"> <asp:Button ID="bLogout" runat="server" Text="LOGOUT" CssClass="button" PostBackUrl="Login.aspx?logout=1" Width="11.2em" Height="2.4em" meta:resourcekey="res_bLogout" style="text-align: center"/> </div>
  <div style="margin-top: 0.5em"> <asp:Button ID="bExit" runat="server" Text="EXIT" CssClass="button" PostBackUrl="Login.aspx?FORCE_EXIT=1" Width="11.2em" Height="2.4em" meta:resourcekey="res_bExit" style="text-align: center"/> </div>
  <div style="margin-top: 0.5em"> <asp:Button ID="bTest" runat="server" Text="TEST" CssClass="button" PostBackUrl="Test.aspx" Width="11.2em" Height="2.4em" style="text-align: center"/> </div>
 </asp:Panel>
</div>



</asp:Content>