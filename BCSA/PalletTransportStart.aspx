<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletTransportStart.aspx.cs" Inherits="_PalletTransportStart" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="PalletTransportSelectBlock.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Start Transport" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
                 </td>
             </tr>
         </table>

  <div><asp:Label ID="lTable" runat="server" Text=""/></div>
  
  <div><asp:Label ID="lPalletID" CssClass="labsmall" runat="server" Text="Pallet ID:" meta:resourcekey="res_lPalletID" Visible="false"/></div>
  <asp:Panel ID="panPallet" runat="server" DefaultButton="bPallet">
  <div><asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.6em" Text=""/>
    <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
</div>
  <asp:Button ID="bPallet" runat="server" OnClick="bPallet_Click" style="display: none"/>
  </asp:Panel>


       <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bConfirm" OnClientClick="this.disabled = true; this.value = '...';"  UseSubmitBehavior="false"/> </div>
 </asp:Panel>
</div>
</asp:Content>