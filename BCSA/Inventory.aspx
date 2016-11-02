<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="Pallets.aspx.cs" Inherits="_Pallets" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" DefaultButton="bBack" Width="100%">
  <div style="width: 220px; margin-bottom: 1.05em">
   <asp:ImageButton ID="bBack" runat="server" PostBackUrl="index.aspx" ImageUrl="Images/41.jpg"/>
   <img src="<% =fdAsp.Web.Common.Logo(Request) %>"/>
   <br/>
   <h1><asp:Localize ID="lHeader" runat="server" meta:resourcekey="res_lHeader" Text="Inventory"/></h1>
  </div>
  <div> <asp:Button ID="bInventoryPallets" runat="server" Text="Inventory of pallets" CssClass="button" PostBackUrl="InventoryPallets.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bInventoryPallets"/> </div>
  <div> <asp:Button ID="bInventoryItems" runat="server" Text="Inventory of items" CssClass="button" PostBackUrl="InventoryItems.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bInventoryItems"/> </div>
 </asp:Panel>
</div>
</asp:Content>