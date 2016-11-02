<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="Pallets.aspx.cs" Inherits="_Pallets" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" DefaultButton="bBack" Width="100%">
  <div style="width: 220px; margin-bottom: 1.05em">
   <asp:ImageButton ID="bBack" runat="server" PostBackUrl="index.aspx" ImageUrl="Images/41.jpg"/>
   <img src="<% =fdAsp.Web.Common.Logo(Request) %>"/>
   <br/>
   <h1><asp:Localize ID="lHeader" runat="server" meta:resourcekey="res_lHeader" Text="Pallets"/></h1>
  </div>
  <div> <asp:Button ID="bPalletMove" runat="server" Text="Pallet move" CssClass="button" PostBackUrl="PalletMove.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletMove"/> </div>
  <div> <asp:Button ID="bPalletTransports" runat="server" Text="Expedition" CssClass="button" PostBackUrl="PalletExpedition.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletTransports"/> </div>
  <div> <asp:Button ID="bPalletRegistration" runat="server" Text="Pallet registration" CssClass="button" PostBackUrl="PalletRegister.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletRegistration"/> </div>
  <div> <asp:Button ID="bPalletBlocking" runat="server" Text="Pallet blocking" CssClass="button" PostBackUrl="PalletBlocking.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletBlocking"/> </div>
 </asp:Panel>
</div>
</asp:Content>