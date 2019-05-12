<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="ConfirmDetails.aspx.cs" Inherits="Order_ConfirmDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table style="width: 104%" >
        <tr>
            <td style="width: 94px">First Name:</td>
            <td style="width: 270px"><asp:Label ID="lblFName" runat="server"></asp:Label></td> 
        </tr>
        <tr>
            <td style="width: 96px">Last Name:</td>
            <td><asp:Label ID="lblLName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 94px">Street:</td>
            <td style="width: 270px"><asp:Label ID="lblStreet" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 96px">Town:</td>
            <td><asp:Label ID="lblTown" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 94px">Postcode:</td>
            <td style="width: 270px"><asp:Label ID="lblPostcode" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 96px">Phone No:</td>
            <td><asp:Label ID="lblPhoneNo" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td style="width: 94px">Email:</td>
            <td style="width: 270px"><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Text="Are these Details Correct?"></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 94px">&nbsp;</td>
            <td style="width: 270px">
                <asp:Button ID="btnConfirm" runat="server" Text="Continue" OnClick="btnContinue_Click" style="height: 29px" />
                <asp:Button ID="btnChange" runat="server" Text="Change" OnClick="btnChange_Click" style="height: 29px" />
            </td>
        </tr>
        
    </table> 
</asp:Content>

