<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletTransportComplete.aspx.cs" Inherits="_PalletTransportComplete" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="PalletTransportSelectBlock.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Complete Transport" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
                 </td>
             </tr>
         </table>

  <div><asp:Label ID="lTable" runat="server" Text=""/></div>
  
  <div><asp:Label ID="lWarehouse" CssClass="labsmall" runat="server" Text="Destination Warehouse:" meta:resourcekey="res_lWarehouse"/></div>
  <asp:Panel ID="panWarehouse" runat="server" DefaultButton="bWarehouse">
  <div><asp:TextBox ID="tWarehouse" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
</div>
  <asp:Button ID="bWarehouse" runat="server" OnClick="bWarehouse_Click" style="display: none"/>
  </asp:Panel>

  <div><asp:Label ID="lLocation" CssClass="labsmall" runat="server" Text="Destination Location:" meta:resourcekey="res_lLocation"/></div>
  <asp:Panel ID="panLocation" runat="server" DefaultButton="bLocation">
  <div><asp:TextBox ID="tLocation" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
</div>
  <asp:Button ID="bLocation" runat="server" OnClick="bLocation_Click" style="display: none"/>
  </asp:Panel>

       <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bConfirm"/> </div>
 </asp:Panel>
</div>
</asp:Content>