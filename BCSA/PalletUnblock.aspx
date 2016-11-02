<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletUnblock.aspx.cs" Inherits="_PalletUnblock" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="PalletBlocking.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Unblock pallet" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text="Scan Pallet ID..."/>
                 </td>
             </tr>
         </table>


  <div><asp:Panel ID="panID" runat="server" DefaultButton="bPalletInfo">
  <div><asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
      <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
  </div>
     <asp:Button ID="bPalletInfo" runat="server" OnClick="bPalletInfo_Click" style="display: none"/>
  </asp:Panel></div>

<div>  
  <asp:Panel ID="panBlocking" runat="server" DefaultButton="bBlocking">
      <asp:Label ID="lBlocking" CssClass="labsmall" runat="server" Text="Blocking code:" meta:resourcekey="res_lBlocking"/><br/>
   <asp:DropDownList ID="ddlBlocking" CssClass="input" runat="server" AutoPostBack="true" OnSelectedIndexChanged="bBlocking_Click" Width="7em">
   </asp:DropDownList>
  <asp:Button ID="bBlocking" runat="server" OnClick="bBlocking_Click" style="display: none"/>
  </asp:Panel>
    </div>
  
  <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bConfirm"/> </div>

 </asp:Panel>
</div>
</asp:Content>