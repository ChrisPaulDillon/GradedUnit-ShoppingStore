<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblWarning" runat="server" Visable="false" />
    <br />
    <br />
    <asp:TextBox ID="txtSearch" runat="server" Height="23px" />
    <asp:Button ID="btnSearch" runat="server" Text="Search"/>
    <br />
    <br />
         <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4">
        <Columns>
            <asp:TemplateField HeaderText="Product" ItemStyle-Width="200px">
                <ItemTemplate>
                    <a href='ProductDetails.aspx?ProductId=<%# Eval("Value.ProductId") %>'><%# Eval("Value.ProductName") %></a>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:BoundField DataField="Value.UnitPrice" HeaderText="Price" ItemStyle-Width="50px" DataFormatString="{0:c}"/>
        <asp:BoundField DataField="Value.QuantityHeld" HeaderText="Quantity" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='AddToCart.aspx?ProductId=<%# Eval("Value.ProductId") %>'>Add To Cart</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
</asp:Content>