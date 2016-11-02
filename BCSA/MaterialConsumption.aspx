<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="MaterialConsumption.aspx.cs" Inherits="_MaterialConsumption" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="Production.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Material Consumption" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lSetup" CssClass="info" runat="server" Text=""/>
                 <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
                 </td>
             </tr>
         </table>


  <div><asp:Label ID="lWorkorderID" CssClass="labsmall" runat="server" Text="Work order:" meta:resourcekey="res_lWorkorderID"/></div>
  <div><asp:Panel ID="panlWorkorder" runat="server" DefaultButton="bWorkorder">
  <div><asp:TextBox ID="tWorkorderID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
  </div>
     <asp:Button ID="bWorkorder" runat="server" OnClick="bWorkorder_Click" style="display: none"/>
  </asp:Panel></div>

  <div>
  <asp:Panel ID="panLocation" runat="server" DefaultButton="bLocation">
  <asp:Label ID="lLocationID" CssClass="labsmall" runat="server" Text="Location ID:" style="vertical-align: top"  meta:resourcekey="res_lLocationID"/> &nbsp; 
  <asp:TextBox ID="tLocationID" CssClass="input" runat="server" MaxLength="32" Width="7.2em" Text=""/>
  
     <asp:Button ID="bLocation" runat="server" OnClick="bLocation_Click" style="display: none"/>
  </asp:Panel></div>

  <div><asp:Label ID="lPalletID" CssClass="labsmall" runat="server" Text="Pallet ID:" meta:resourcekey="res_lPalletID"/></div>
  <div><asp:Panel ID="panPallet" runat="server" DefaultButton="bPallet">
  <div><asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
      <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
  </div>
     <asp:Button ID="bPallet" runat="server" OnClick="bPallet_Click" style="display: none"/>
  </asp:Panel></div>

  <table><tr>
  <td>

  <asp:Panel ID="panQuantity" runat="server" DefaultButton="bQuantity">
  <asp:Label ID="lQuantity" CssClass="labsmall" runat="server" Text="Quantity:" meta:resourcekey="res_lQuantity"/> <br/>
  <asp:TextBox ID="tQuantity" CssClass="input" runat="server" MaxLength="32" Width="6em" Text=""/>
  <asp:Button ID="bQuantity" runat="server" OnClick="bQuantity_Click" style="display: none"/>
  </asp:Panel>

  </td><td>

  <asp:Panel ID="panUnit" runat="server" DefaultButton="bUnit">
  <asp:Label ID="lUnit" CssClass="labsmall" runat="server" Text="Unit:" meta:resourcekey="res_lUnit"/> <br/>
   <asp:DropDownList ID="ddlUnit" CssClass="input" runat="server" AutoPostBack="true" OnSelectedIndexChanged="bUnit_Click" Width="4.9em">
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
          
  </td></tr></table>


  <asp:Label ID="lAXItem" runat="server" Text="" Visible="false"/>
  <asp:Label ID="lAXLocation" runat="server" Text="" Visible="false"/>
  <asp:Label ID="lAXQty" runat="server" Text="" Visible="false"/>
  <asp:Label ID="lAXPickedQty" runat="server" Text="" Visible="false"/>

  <asp:Panel ID="panTransfer" runat="server" style="background-color: #91e8ff; border: 4px solid #888888; position: absolute; left: 2px; top: 160px" Visible="false" DefaultButton="bNone">
      <div> <asp:Button ID="bTransfer" runat="server" Text="TRANSFER" OnClick="bTransfer_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bTransfer"/> </div>
      <div> <asp:Label ID="lNewWorkorderID" CssClass="labsmall" runat="server" Text="New work order:" meta:resourcekey="res_lNewWorkorderID"/></div>
      <div> <asp:TextBox ID="tNewWorkorderID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/></div>
      <div> <asp:Button ID="bReturn" runat="server" Text="RETURN" OnClick="bReturn_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bReturn"/> </div>
      <asp:Button ID="bNone" runat="server" OnClick="bNone_Click" style="display: none"/>
  </asp:Panel>

  <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bConfirm"/> </div>

 </asp:Panel>
</div>
</asp:Content>