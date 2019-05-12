<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:Label ID="lblReturnCancel" runat="server" Visible="false"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblOrderMessage" runat="server" Visible="false"></asp:Label>
                <br />
    <p>To cancel an order, please click cancel next to the order you wish to cancel.<br />
        Orders can only be cancelled before 48 hours after the order has been placed.
    </p>
    <br />

    <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Middle">
         <Columns>      
        <asp:BoundField DataField="Value.OrderDate" HeaderText="Order Date"/>    
        <asp:BoundField DataField="Value.ShippingStatus" HeaderText="Status" ItemStyle-Width="140px"/>            
        <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <%#:String.Format("{0:c}", Convert.ToDouble(Eval("Value.Total"))) %>
                </ItemTemplate>     
        </asp:TemplateField> 
             <asp:TemplateField ItemStyle-Width="50px">
                <ItemTemplate>
                    <a href='ViewOrderDetails.aspx?OrderId=<%# Eval("Value.OrderId") %>'>View/Return</a>
                </ItemTemplate>        
        </asp:TemplateField> 
             <asp:TemplateField ItemStyle-Width="50px">
                <ItemTemplate>
                    <a href='MyOrders.aspx?OrderId=<%# Eval("Value.OrderId") %>'>Cancel</a>
                </ItemTemplate>        
        </asp:TemplateField>
        </Columns>    
    </asp:GridView>
                <br />
                <br />
                <br />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />

</asp:Content>

