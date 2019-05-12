<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Manage_Users_EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblWarning" runat="server"></asp:Label>
    <asp:Label ID="lblMessage" Text="For the original values to remain, please leave the textboxes as the default values" runat="server"></asp:Label>
    <br />
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 166px">Username:</td>
            <td style="width: 227px">
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">First Name:</td>
            <td style="width: 227px">
                <asp:Label ID="lblFName" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">Last Name:</td>
            <td style="width: 227px">
                <asp:Label ID="lblLName" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLName" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Street:</td>
             <td style="width: 227px">
                <asp:Label ID="lblStreet" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtStreet" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Town:</td>
             <td style="width: 227px">
                <asp:Label ID="lblTown" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTown" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Postcode:</td>
             <td style="width: 227px">
                <asp:Label ID="lblPostcode" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPostcode" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td style="width: 166px">Phone Number:</td>
             <td style="width: 227px">
                <asp:Label ID="lblPhoneNo" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhoneNo" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td style="width: 166px">Email:</td>
             <td style="width: 227px">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">&nbsp;</td>
            <td style="width: 227px">
                &nbsp;</td>
             <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" />
            </td>
        </tr> 
    </table> 
</asp:Content>
