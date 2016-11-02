<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletTransportList.aspx.cs" Inherits="_PalletTransportList" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">
     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="Pallets.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Transport List" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">
                 <asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text="Forklift ID:"/>
                 </td>
             </tr>
         </table>

  <div><asp:Panel ID="panID" runat="server" DefaultButton="bForkliftInfo">
  <div><asp:TextBox ID="tForkliftID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/></div>
  <asp:Button ID="bForkliftInfo" runat="server" OnClick="bForkliftInfo_Click" style="display: none"/>
  </asp:Panel></div>  

  <div> <asp:Button ID="bAll" runat="server" Text="All" CssClass="button" Width="11.2em" Height="2.4em" meta:resourcekey="res_bAll" OnClick="bAllClick"/> </div>
  <div> <asp:Button ID="bIn" runat="server" Text="In" CssClass="button" Width="11.2em" Height="2.4em" meta:resourcekey="res_bIn" OnClick="bInClick"/> </div>
  <div> <asp:Button ID="bOut" runat="server" Text="Out" CssClass="button" Width="11.2em" Height="2.4em" meta:resourcekey="res_bOut" OnClick="bOutClick"/> </div>
  <div> <asp:Button ID="bRefill" runat="server" Text="Refill" CssClass="button" Width="11.2em" Height="2.4em" meta:resourcekey="res_bRefill" OnClick="bRefillClick"/> </div>

 </asp:Panel>
</div>
</asp:Content>