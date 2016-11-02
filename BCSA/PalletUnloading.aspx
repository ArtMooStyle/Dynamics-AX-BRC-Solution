<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletUnloading.aspx.cs" Inherits="_PalletUnloading" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">

     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="PalletExpedition.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Pallet unloading" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
  <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
                 </td>
             </tr>
         </table>

  <div><asp:Label ID="lStock" CssClass="labsmall" runat="server" Text="Stock:" meta:resourcekey="res_lStock"/></div>
  <asp:Panel ID="panStock" runat="server" DefaultButton="bStock">
  <div><asp:TextBox ID="tStock" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/></div>
  <asp:Button ID="bStock" runat="server" OnClick="bStock_Click" style="display: none"/>
  </asp:Panel>

  <div><asp:Label ID="lLocation" CssClass="labsmall" runat="server" Text="Location:" meta:resourcekey="res_lLocation"/></div>
  <asp:Panel ID="panLocation" runat="server" DefaultButton="bLocation">
  <div><asp:TextBox ID="tLocation" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/></div>
  <asp:Button ID="bLocation" runat="server" OnClick="bLocation_Click" style="display: none"/>
  </asp:Panel>

  <div><asp:Label ID="lPalletID" CssClass="labsmall" runat="server" Text="Pallet ID:" meta:resourcekey="res_lPalletID"/></div>
      <asp:Panel ID="panID" runat="server" DefaultButton="bPalletInfo">
  <div><asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.6em" Text=""/>
      <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
  </div>
     <asp:Button ID="bPalletInfo" runat="server" OnClick="bPalletInfo_Click" style="display: none"/>
  </asp:Panel></div>
  
  <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bConfirm"/> </div>

 </asp:Panel>
</div>
</asp:Content>