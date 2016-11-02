<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" %>

<asp:Content ID="cMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panLogin" runat="server" DefaultButton="bLogin" Width="100%">
  <div style="text-align: center; margin-bottom: 3em">
   <div style="width: 240px;">
    <img src="<% =fdAsp.Web.Common.Logo(Request) %>"/>
    <img src="Images/84.jpg"/>
    <div style="width: 100%; background-color: #003d50; margin: 1.8em 0 0 0; padding: 10px 0 20px 0;">
     <div><asp:Label ID="lPIN" CssClass="label" style="color: #ffffff" runat="server" Text="Enter PIN:" meta:resourcekey="res_lPIN"/></div>
     <div><asp:TextBox ID="tPIN" CssClass="input" style="font-size: 30pt; text-align: center" runat="server" MaxLength="4" TextMode="Password" Width="3.5em" Height="1.2em"/></div>
     <div><asp:Button ID="bLogin" CssClass="button" style="text-align: center" runat="server" OnClick="bLogin_Click" Text="LOGIN" Width="8em" Height="2.7em" meta:resourcekey="res_bLogin"/></div>
     <div><asp:Label ID="lResult" runat="server" CssClass="outputError"></asp:Label></div>
    </div>
   </div>
  </div>
 </asp:Panel>
</div>
</asp:Content>
