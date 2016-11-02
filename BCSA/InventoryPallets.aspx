<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="InventoryPallets.aspx.cs" Inherits="_InventoryPallets" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="Inventory.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Inventory of pallets" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lInfo" CssClass="info" runat="server" Text=""/>
                 </td>
             </tr>
         </table>


  <div><asp:Label ID="lStock" CssClass="labsmall" runat="server" Text="Stock:" meta:resourcekey="res_lStock"/>
      <asp:Label ID="lJournalID" runat="server" Visible="false"/>
      <asp:Label ID="lItemID" runat="server" Visible="false"/>
      <asp:Label ID="lBatch" runat="server" Visible="false"/>
  </div>
  <asp:Panel ID="panStock" runat="server" DefaultButton="bStock">
  <div><asp:TextBox ID="tStock" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/></div>
  <asp:Button ID="bStock" runat="server" OnClick="bStock_Click" style="display: none"/>
  </asp:Panel>

  <asp:Panel ID="panForm" runat="server" Visible="false">

      <table>
<tr><td colspan="2">

  <asp:Panel ID="panID" runat="server" DefaultButton="bPalletInfo">
  <asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
      <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
     <asp:Button ID="bPalletInfo" runat="server" OnClick="bPalletInfo_Click" style="display: none"/>
  </asp:Panel>

</td></tr><tr><td>
      <asp:Label ID="lLocation" CssClass="labsmall" runat="server" Text="Location:" meta:resourcekey="res_lLocation"/>
          </td><td>
  <asp:Panel ID="panLocation" runat="server" DefaultButton="bLocation">
      <asp:TextBox ID="tLocation" CssClass="input" runat="server" MaxLength="32" Width="7em" Text=""/>
  <asp:Button ID="bLocation" runat="server" OnClick="bLocation_Click" style="display: none"/>
  </asp:Panel>
</td></tr><tr><td>

  <asp:Panel ID="panQuantity" runat="server" DefaultButton="bQuantity">
  <asp:Label ID="lQuantity" CssClass="labsmall" runat="server" Text="Quantity:" meta:resourcekey="res_lQuantity"/> <br/>
  <asp:TextBox ID="tQuantity" CssClass="input" runat="server" MaxLength="32" Width="4.5em" Text=""/>
  <asp:Button ID="bQuantity" runat="server" OnClick="bQuantity_Click" style="display: none"/>
  </asp:Panel>

  </td><td>

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
          
</td></tr><tr><td>

      <asp:Label ID="lBlocking" CssClass="labsmall" runat="server" Text="Blocking code:" meta:resourcekey="res_lBlocking"/>
          </td>
          <td>
  <asp:Panel ID="panBlocking" runat="server" DefaultButton="bBlocking">
   <asp:DropDownList ID="ddlBlocking" CssClass="input" runat="server" AutoPostBack="true" OnSelectedIndexChanged="bBlocking_Click" Width="7em">
    <asp:ListItem Value="" Text=""/>
    <asp:ListItem Value="auto" Text="auto"/>
    <asp:ListItem Value="log check" Text="log check"/>
    <asp:ListItem Value="prod def" Text="prod def"/>
    <asp:ListItem Value="prod check" Text="prod check"/>
    <asp:ListItem Value="prod ok" Text="prod ok"/>
    <asp:ListItem Value="prod repac" Text="prod repac"/>
    <asp:ListItem Value="pur check" Text="pur check"/>
    <asp:ListItem Value="TempBlock" Text="TempBlock"/>
   </asp:DropDownList>
  <asp:Button ID="bBlocking" runat="server" OnClick="bBlocking_Click" style="display: none"/>
  </asp:Panel>

</td></tr></table>

  </asp:Panel>

  <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em" meta:resourcekey="res_bConfirm"/>
      <asp:Button ID="bOverwrite" runat="server" Text="OVERWRITE" OnClick="bOverwrite_Click" CssClass="button" style="text-align: center" Width="5em" Height="2.4em" Visible="false" meta:resourcekey="res_bOverwrite"/>
      <asp:Button ID="bCancel" runat="server" Text="CANCEL" OnClick="bCancel_Click" CssClass="button" style="text-align: center" Width="5em" Height="2.4em" Visible="false" meta:resourcekey="res_bCancel"/>
  </div>
 </asp:Panel>
</div>
</asp:Content>