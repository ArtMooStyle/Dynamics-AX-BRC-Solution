<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_index" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
  <div style="width: 220px; margin-bottom: 0.2em">
   <asp:ImageButton ID="bSettings" runat="server" PostBackUrl="Settings.aspx" ImageUrl="Images/40.jpg"/>
   <asp:ImageButton ID="bLogo" runat="server" PostBackUrl="index.aspx"/>
  </div>
  <div> <asp:Button ID="bPallets" runat="server" Text="Pallets" CssClass="button" PostBackUrl="Pallets.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPallets"/> </div>
  <div> <asp:Button ID="bTransaction" runat="server" Text="Transaction" CssClass="button" PostBackUrl="Transactions.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bTransaction"/> </div>
  <div> <asp:Button ID="bProduction" runat="server" Text="Production" CssClass="button" PostBackUrl="Production.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bProduction"/> </div>
  <div> <asp:Button ID="bReports" runat="server" Text="Reports" CssClass="button" Width="11.2em" Height="2.4em" meta:resourcekey="res_bReports"/> </div>
  <div> <asp:Button ID="bInventory" runat="server" Text="Inventory" CssClass="button" PostBackUrl="Inventory.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bInventory"/> </div>
 </asp:Panel>
</div>
</asp:Content>