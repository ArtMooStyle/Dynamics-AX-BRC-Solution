<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletRegister.aspx.cs" Inherits="_PalletRegister" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="Pallets.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Register Pallet" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
                 </td>
             </tr>
         </table>


  <div><asp:Label ID="lProdID" CssClass="labsmall" runat="server" Text="Production ID:" meta:resourcekey="res_lProdID"/></div>
  <div><asp:Panel ID="panProd" runat="server" DefaultButton="bProd">
  <div><asp:TextBox ID="tProdID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
  </div>
     <asp:Button ID="bProd" runat="server" OnClick="bProd_Click" style="display: none"/>
  </asp:Panel></div>
  
  <div><asp:Label ID="lPalletID" CssClass="labsmall" runat="server" Text="Pallet ID:" meta:resourcekey="res_lPalletID"/></div>
  <asp:Panel ID="panPallet" runat="server" DefaultButton="bPallet">
  <div><asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
    <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
</div>
  <asp:Button ID="bPallet" runat="server" OnClick="bPallet_Click" style="display: none"/>
  </asp:Panel>
  
  <asp:Panel ID="panQuantity" runat="server" DefaultButton="bQuantity">
  <asp:Label ID="lQuantity" CssClass="labsmall" runat="server" Text="Quantity:" meta:resourcekey="res_lQuantity"/> <br/>
  <asp:TextBox ID="tQuantity" CssClass="input" runat="server" MaxLength="32" Width="6em" Text=""/>
  <asp:Button ID="bQuantity" runat="server" OnClick="bQuantity_Click" style="display: none"/>
  </asp:Panel>
  
  <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bConfirm"/> </div>

 </asp:Panel>
</div>
</asp:Content>