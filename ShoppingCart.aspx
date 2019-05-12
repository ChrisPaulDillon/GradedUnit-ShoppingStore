<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
    <asp:Label ID="lblWarning" runat="server" Visable="false"></asp:Label>
    <asp:GridView ID="gvCartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4">   
        <Columns>
        <asp:BoundField DataField="Value.Product.ProductName" HeaderText="Name" ItemStyle-Width="200px"/>        
        <asp:BoundField DataField="Value.Product.UnitPrice" HeaderText="Price" DataFormatString="{0:c}"/>          
        <asp:BoundField DataField="Value.Quantity" HeaderText="Quantity"/>        
        <asp:TemplateField HeaderText="Item Total">
                <ItemTemplate>
                    <%#:String.Format("{0:c}", Convert.ToDouble(Eval("Value.Quantity")) * Convert.ToDouble(Eval("Value.Product.UnitPrice"))) %>
                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField>
                <ItemTemplate>
                    <a href='ShoppingCart.aspx?OrderLineId=<%# Eval("Value.OrderLineId") %>'>Remove</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>    
    </asp:GridView>
    <br />
    <div>
        <strong>
            <asp:Label ID="lblTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />

          <asp:Button ID="btnOrder" runat="server" Text="Order" OnClick="btnOrder_Click" />
</asp:Content>

