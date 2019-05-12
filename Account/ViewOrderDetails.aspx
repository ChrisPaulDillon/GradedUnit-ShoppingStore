<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="ViewOrderDetails.aspx.cs" Inherits="Account_ViewOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                <br />
    <br />

    <asp:GridView ID="gvOrderLines" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Middle">
         <Columns>      
        <asp:BoundField DataField="Value.Product.ProductName" HeaderText="Product" ItemStyle-Width="200px"/>    
        <asp:BoundField DataField="Value.Product.UnitPrice" HeaderText="Price" ItemStyle-Width="140px" DataFormatString="{0:c}"/>   
        <asp:BoundField DataField="Value.Quantity" HeaderText="Quantity"/>          
                <asp:TemplateField>
                <ItemTemplate>
                    <a href='ReturnItem.aspx?OrderLineId=<%# Eval("Value.OrderLineId") %>'>Return Item</a>
                </ItemTemplate>        
        </asp:TemplateField> 
        </Columns>    
    </asp:GridView>

            <br />
            Shipping Method:
            <asp:Label ID="lblShippingMethod" runat="server" ></asp:Label>
            <br />

            <br />
             Order Total: <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />

</asp:Content>

