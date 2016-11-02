<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletBlocking.aspx.cs" Inherits="_PalletBlocking" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" DefaultButton="bBack" Width="100%">
  <div style="width: 220px; margin-bottom: 1.05em">
   <asp:ImageButton ID="bBack" runat="server" PostBackUrl="Pallets.aspx" ImageUrl="Images/41.jpg"/>
   <img src="<% =fdAsp.Web.Common.Logo(Request) %>"/>
   <br/>
   <h1><asp:Localize ID="lHeader" runat="server" meta:resourcekey="res_lHeader" Text="Pallet blocking"/></h1>
  </div>
  <div> <asp:Button ID="bPalletBlock" runat="server" Text="Pallet block" CssClass="button" PostBackUrl="PalletBlock.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletBlock"/> </div>
  <div> <asp:Button ID="bPalletUnblock" runat="server" Text="Pallet unblock" CssClass="button" PostBackUrl="PalletUnblock.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bPalletUnblock"/> </div>
 </asp:Panel>
</div>
</asp:Content>