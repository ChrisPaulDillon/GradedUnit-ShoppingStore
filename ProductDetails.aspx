<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:FormView ID="fvProductDetail" runat="server" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%# Eval("Value.ProductName") %></h1>
            </div>
            <br />
            <table>
                <td>
                        <img src="Images/Products/<%# Eval("Value.ImgPath") %>" style="border:solid; height:300px"/>
                    </td>
                <tr>
                    <td style="vertical-align: top; text-align:left;">
                        <b>Description:</b><br /><%# Eval("Value.Description") %><br /><span><b>Price:</b>&nbsp;<%#:String.Format("{0:c}", Eval("Value.UnitPrice")) %></span><br /><span></tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:DropDownList ID="ddlQuantity" runat="server"></asp:DropDownList>
    <br />
    <asp:LinkButton ID="lbAddToCart" runat="server" OnClick="lbAddToCart_Click" >Add to Cart</asp:LinkButton>
    <br />
    <asp:Label ID="lblOutOfStock" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
</asp:Content>

