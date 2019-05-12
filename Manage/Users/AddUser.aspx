<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="Manage_Users_AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <table style="width: 100%">
         <tr>
            <td style="width: 166px">Username:</td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtUsername"
                    ErrorMessage="Username is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtPassword"
                    ErrorMessage="Password is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="jobTitle" runat="server">
            <td style="width: 166px;">Job Title:</td>
            <td>
                <asp:DropDownList ID="ddlJob" runat="server">
                    <asp:ListItem>Sales</asp:ListItem>
                    <asp:ListItem>Stock Manager</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>

            <td style="width: 166px;">First Name:</td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtFName"
                    ErrorMessage="First Name is a required field."

                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">Last Name:</td>
            <td>
                <asp:TextBox ID="txtLName" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                    ControlToValidate="txtLName"
                    ErrorMessage="Last Name is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">Street:</td>
            <td>
                <asp:TextBox ID="txtStreet" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtStreet"
                    ErrorMessage="Street is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Town:</td>
            <td>
                <asp:TextBox ID="txtTown" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
                    ControlToValidate="txtTown"
                    ErrorMessage="Town is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Postcode:</td>
            <td>
                <asp:TextBox ID="txtPostcode" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"
                    ControlToValidate="txtPostcode"
                    ErrorMessage="Postcode is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Phone Number:</td>
            <td>
                <asp:TextBox ID="txtNumber" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server"
                    ControlToValidate="txtNumber"
                    ErrorMessage="Phone Number is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="190px" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Email is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>
            </td>
        </tr>
        
    </table> 
</asp:Content>
