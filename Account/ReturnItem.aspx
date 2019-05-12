
<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="ReturnItem.aspx.cs" Inherits="ReturnItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:Label ID="lblWarning" runat="server"></asp:Label>
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 147px">Please state a reason for the return of this product</td>
            <td><asp:TextBox ID="txtReason" runat="server" Width="246px" TextMode="MultiLine" Height="243px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 147px">Condition:</td>
            <td>
                <br />
                <asp:DropDownList ID="ddlCondition" runat="server">
                    <asp:ListItem>Unopened</asp:ListItem>
                    <asp:ListItem>Like New</asp:ListItem>
                    <asp:ListItem>Damaged</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
        </tr>
         <tr>
            <td style="width: 147px"></td>
             <td>
                 <br />
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <br />
             </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>
            </td>
        </tr>
        
    </table> 
</asp:Content>

