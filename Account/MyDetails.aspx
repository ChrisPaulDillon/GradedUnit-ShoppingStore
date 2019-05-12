<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="MyDetails.aspx.cs" Inherits="Account_MyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblIncompleteInfo" runat="server"></asp:Label>
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 166px; height: 25px;">First Name:</td>
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
                <asp:Label ID="lblNumber" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNumber" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Email:</td>
             <td style="width: 227px">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
             <td style="height: 30px">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 23px">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>
            </td>
        </tr>
        
    </table> 
</asp:Content>

