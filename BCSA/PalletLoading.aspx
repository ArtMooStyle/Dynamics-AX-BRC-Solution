<%@ Page Language="C#" MasterPageFile="~/App.master" AutoEventWireup="true" CodeFile="PalletLoading.aspx.cs" Inherits="_PalletLoading" validateRequest="false" %>

<asp:Content ID="cntMain" ContentPlaceHolderID="phldMain" Runat="server">
<div>
 <asp:Panel ID="panMain" runat="server" Width="100%">

     <table>
         <tr class="header">
             <td><asp:ImageButton ID="bBack" runat="server" PostBackUrl="PalletExpedition.aspx" ImageUrl="Images/41.jpg"/></td>
             <td><asp:Label ID="lHeader" CssClass="headerLabel" runat="server" Text="Pallet loading" meta:resourcekey="res_lHeader" /></td>
             </tr>
         <tr>
             <td colspan="2" style="background-color: #ffff80">

                   <div><asp:Panel ID="panID" runat="server" DefaultButton="bPalletInfo">
  <div><asp:Label ID="lInfo" CssClass="info" runat="server" meta:resourcekey="res_lInfo" Text=""/>
      <asp:TextBox ID="tPalletID" CssClass="input" runat="server" MaxLength="32" Width="11.6em" Text="" Visible="false"/>
      <asp:Label ID="lOldPalletID" runat="server" Text="" Visible="false"/>
  </div>
     <asp:Button ID="bPalletInfo" runat="server" OnClick="bPalletInfo_Click" style="display: none"/>
  </asp:Panel></div>
                 
                 </td>
             </tr>
         </table>

  <div><asp:Label ID="lStock" CssClass="labsmall" runat="server" Text="Stock:" meta:resourcekey="res_lStock"/></div>
  <asp:Panel ID="panStock" runat="server" DefaultButton="bStock">
  <div><asp:TextBox ID="tStock" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/></div>
  <asp:Button ID="bStock" runat="server" OnClick="bStock_Click" style="display: none"/>
  </asp:Panel>
  <div><asp:Label ID="lLocation" CssClass="labsmall" runat="server" Text="Location:" meta:resourcekey="res_lLocation"/></div>
  <asp:Panel ID="panLocation" runat="server" DefaultButton="bLocation">
  <div><asp:TextBox ID="tLocation" CssClass="input" runat="server" MaxLength="32" Width="11.2em" Text=""/></div>
  <asp:Button ID="bLocation" runat="server" OnClick="bLocation_Click" style="display: none"/>
  </asp:Panel>
  <div> <asp:Button ID="bConfirm" runat="server" Text="CONFIRM" OnClick="bConfirm_Click" CssClass="button" style="text-align: center" Width="11.2em" Height="2.4em"  meta:resourcekey="res_bConfirm"/> </div>


     <asp:Label ID="lTable" runat="server" Text=""/>
		 
     <div id="transportComplete" runat="server" style="font-size: 13pt; font-weight: bold" visible="false">
         <asp:Label id="transportCompleteText" runat="server" Text=" &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; " style="position: absolute; left: 30px; top: 80px; width: 160px; height: 160px; border: 3px solid #000000;"/>
     </div>
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