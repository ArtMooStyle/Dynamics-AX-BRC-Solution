<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="Production.aspx.cs" Inherits="_Production" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" DefaultButton="bBack" Width="100%">
  <div style="width: 220px; margin-bottom: 1.05em">
   <asp:ImageButton ID="bBack" runat="server" PostBackUrl="index.aspx" ImageUrl="Images/41.jpg"/>
   <img src="<% =fdAsp.Web.Common.Logo(Request) %>"/>
   <br/>
   <h1><asp:Localize ID="lHeader" runat="server" meta:resourcekey="res_lHeader" Text="Production"/></h1>
  </div> 
  <div> <asp:Button ID="bConsumption" runat="server" Text="Material consumption" CssClass="button" PostBackUrl="MaterialConsumption.aspx" Width="11.2em" Height="2.4em" meta:resourcekey="res_bConsumption"/> </div>
 </asp:Panel>
</div>
</asp:Content>