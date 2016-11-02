<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletTransportSelectBlock.aspx.cs" Inherits="_PalletTransportSelectBlock" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">

     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="PalletExpedition.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Select/Block Transport" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">

                   <div><asp:Panel ID="panID" runat="server" DefaultButton="bPalletInfo">
  <div><asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
      <asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/>
      <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
  </div>
     <asp:Button ID="bPalletInfo" runat="server" OnClick="bPalletInfo_Click" style="display: none"/>
  </asp:Panel></div>
                 
                 </td>
             </tr>
         </table>

     <asp:Label ID="lFirstPalletId" runat="server" Text="" Visible="false"/>
     <asp:Label ID="lFirstTransportId" runat="server" Text="" Visible="false"/>
     <asp:Label ID="lFirstWarehouse" runat="server" Text="" Visible="false"/>
     <asp:Label ID="lFirstLocation" runat="server" Text="" Visible="false"/>
     <asp:Label ID="lFirstURLArgs" runat="server" Text="" Visible="false"/>

<table><tr><td>
     <asp:Label ID="lLocation" CssClass="labsmall" runat="server" Text="Output location:" meta:resourcekey="res_Table_Output_Location"/></td>
   <td><asp:DropDownList ID="ddlLocation" CssClass="input" style="font-size: 11pt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="bLocation_Click" Width="6em">
   </asp:DropDownList></td></tr></table>

  <asp:Button ID="bLocation" runat="server" OnClick="bLocation_Click" style="display: none"/>

         <asp:Label ID="lTable" runat="server" Text=""/>

     <div id="transportComplete" runat="server" style="position: absolute; left: 0px; top: 110px; padding: 14px; border: 3px solid #000000; background-color: #00ff21; color: #000000; font-size: 13pt; font-weight: bold" visible="false">PalletTransport complete</div>
     <asp:Label ID="transportCount" runat="server" Text="0" style="color: white"/>

         <script type="text/javascript" language="javascript">
    function currentTime()
    {
        var label = document.getElementById("ctl00_phldMain_transportComplete");
        var count = document.getElementById("ctl00_phldMain_transportCount").innerText;
        if (label != null)
        {
            if (count > 0)
            {
                label.style.display = "";
                count = count - 1;
                document.getElementById("ctl00_phldMain_transportCount").innerHTML = count;
            }
            else
            {
                label.style.display = "none";
            }
            window.setTimeout('currentTime()', 1000);
        }    
    }
    currentTime();
    </script>


 </asp:Panel>
</div>
</asp:Content>