<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PickingListPicking.aspx.cs" Inherits="_PickingListPicking" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="PickingMenu.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Pickinglist Picking" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lSetup" CssClass="info" runat="server" Text=""/>
                 <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
                 </td>
             </tr>
         </table>


  <div><asp:Label ID="lPickingListID" CssClass="labsmall" runat="server" Text="PickingList ID:" meta:resourcekey="res_lPickingListID"/></div>
  <div><asp:Panel ID="panlPicking" runat="server" DefaultButton="bPicking">
  <div><asp:TextBox ID="tPickingListID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
  </div>
     <asp:Button ID="bPicking" runat="server" OnClick="bPicking_Click" style="display: none"/>
  </asp:Panel></div>

  <div><asp:Label ID="lPickingListItem" CssClass="labsmall" runat="server" Text="Item ID:" meta:resourcekey="res_lPickingListItem"/></div>
  <div><asp:Panel ID="panItem" runat="server" DefaultButton="bPickingListItem">
  <div><asp:TextBox ID="tPickingListItem" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
  </div>
     <asp:Button ID="bPickingListItem" runat="server" OnClick="bPickingListItem_Click" style="display: none"/>
  </asp:Panel></div>
  
  <div><asp:Label ID="lLocationID" CssClass="labsmall" runat="server" Text="Location ID:" meta:resourcekey="res_lLocationID"/></div>
  <div><asp:Panel ID="panLocation" runat="server" DefaultButton="bLocation">
  <div><asp:TextBox ID="tLocationID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
  </div>
     <asp:Button ID="bLocation" runat="server" OnClick="bLocation_Click" style="display: none"/>
  </asp:Panel></div>

  <div><asp:Label ID="lPalletID" CssClass="labsmall" runat="server" Text="Pallet ID:" meta:resourcekey="res_lPalletID"/></div>
  <div><asp:Panel ID="panPallet" runat="server" DefaultButton="bPallet">
  <div><asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
      <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
  </div>
     <asp:Button ID="bPallet" runat="server" OnClick="bPallet_Click" style="display: none"/>
  </asp:Panel></div>

  <div><asp:Label ID="lBatchID" CssClass="labsmall" runat="server" Text="Batch ID:" meta:resourcekey="res_lBatchID"/></div>
  <div><asp:Panel ID="panBatch" runat="server" DefaultButton="bBatch">
  <div><asp:TextBox ID="tBatchID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
  </div>
     <asp:Button ID="bBatch" runat="server" OnClick="bBatch_Click" style="display: none"/>
  </asp:Panel></div>

  <div><asp:Label ID="lQuantity" CssClass="labsmall" runat="server" Text="Quantity:" meta:resourcekey="res_lQuantity"/></div>
  <div><asp:Panel ID="panQuantity" runat="server" DefaultButton="bQuantity">
  <div><asp:TextBox ID="tQuantity" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
  </div>
     <asp:Button ID="bQuantity" runat="server" OnClick="bQuantity_Click" style="display: none"/>
  </asp:Panel></div>

  <asp:Panel ID="panUnit" runat="server" DefaultButton="bUnit">
  <asp:Label ID="lUnit" CssClass="labsmall" runat="server" Text="Unit:" meta:resourcekey="res_lUnit"/> <br/>
   <asp:DropDownList ID="ddlUnit" CssClass="input" runat="server" AutoPostBack="true" OnSelectedIndexChanged="bUnit_Click" Width="5.5em">
    <asp:ListItem Value="" Text=""/>
    <asp:ListItem Value="pcs" Text="pcs"/>
    <asp:ListItem Value="bag" Text="bag"/>
    <asp:ListItem Value="crt" Text="crt"/>
    <asp:ListItem Value="pal" Text="pal"/>
    <asp:ListItem Value="rol" Text="rol"/>
    <asp:ListItem Value="kg" Text="kg"/>
    <asp:ListItem Value="m3" Text="m3"/>
    <asp:ListItem Value="m2" Text="m2"/>
    <asp:ListItem Value="m" Text="m"/>
    <asp:ListItem Value="l" Text="l"/>
   </asp:DropDownList>
  <asp:Button ID="bUnit" runat="server" OnClick="bUnit_Click" style="display: none"/>
  </asp:Panel>

  <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bConfirm"/> </div>

 </asp:Panel>
</div>
</asp:Content>