<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="Account_MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="menubar">
          <ul id="menu">
            <li><asp:LinkButton ID="lbDetails" runat="server" OnClick="lbDetails_Click">My Details</asp:LinkButton></li>
            <li><asp:LinkButton ID="lbOrders" runat="server" OnClick="lbOrders_Click">My Orders</asp:LinkButton></li>
          </ul>
        </div><!--close menubar-->

    <h1><asp:Label ID="lblWelcomeUser" runat="server"></asp:Label></h1>
</asp:Content>

