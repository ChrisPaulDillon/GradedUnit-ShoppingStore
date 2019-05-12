<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblLoginError" runat="server" Text=""></asp:Label>
    <br />
    <br />
    Username:
    <br />
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtUser"
                    ErrorMessage="Please enter your username"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
    <br />
    Password:<br />
    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtPass"
                    ErrorMessage="Password cannot be empty"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:DropDownList ID="ddlType" runat="server">
        <asp:ListItem>Customer</asp:ListItem>
        <asp:ListItem>Administrator</asp:ListItem>
        <asp:ListItem>Sales</asp:ListItem>
        <asp:ListItem>Stock Manager</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Sign In" OnClick="btnSubmit_Click" />
     <br />

     <br />
     <asp:Label ID="lblRegister" runat="server" Text="Don't have an Account? "></asp:Label><asp:LinkButton ID="lbRegister" runat="server" OnClick="lbRegister_Click" CausesValidation="false">Click to register</asp:LinkButton>
</asp:Content>

