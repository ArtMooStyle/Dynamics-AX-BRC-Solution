<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletExpedition.aspx.cs" Inherits="_PalletExpedition" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" DefaultButton="bBack" Width="100%">
  <div style="width: 220px; margin-bottom: 1.05em">
   <asp:ImageButton ID="bBack" runat="server" PostBackUrl="Pallets.aspx" ImageUrl="Images/41.jpg"/>
   <img src="<% =fdAsp.Web.Common.Logo(Request) %>"/>
   <br/>
   <h1><asp:Localize ID="lHeader" runat="server" meta:resourcekey="res_lHeader" Text="Expedition"/></h1>
  </div>
  <div> <asp:Button ID="bPalletTransport" runat="server" Text="Pallet transport" CssClass="button" PostBackUrl="PalletTransportSelectBlock.aspx?TransportType=OUT" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletTransport"/> </div>
  <div> <asp:Button ID="bPalletLoading" runat="server" Text="Pallet loading" CssClass="button" PostBackUrl="PalletLoading.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletLoading"/> </div>
  <div> <asp:Button ID="bPalletUnloading" runat="server" Text="Pallet unloading" CssClass="button" PostBackUrl="PalletUnloading.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletUnloading"/> </div>
 </asp:Panel>
</div>
</asp:Content>