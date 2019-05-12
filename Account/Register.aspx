<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    Username:<br />
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <br />
    Password:<br />
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    Confirm Password:<br />
    <asp:TextBox ID="txtConfPass" runat="server" TextMode="Password" ></asp:TextBox>
    <br />
    Email Address:<br />
    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Sign Up" OnClick="btnSubmit_Click" />
    <br />
    <br />
    <asp:Label ID="lblRegisterError" runat="server" Visable="false"></asp:Label>
</asp:Content>

