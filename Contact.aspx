<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <br />

    Subject:<br />
    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
    <br />
    <br />
    Email:<br />
    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
    <br />
    <br />
    Body: 
    <br />
    <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="272px" Width="370px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

  
</asp:Content>