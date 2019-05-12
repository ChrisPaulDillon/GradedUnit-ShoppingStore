<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="StockManagement.aspx.cs" Inherits="Manage_Products_StockManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />
    <br />
    <br />
     <asp:DropDownList ID="ddlProducts" runat="server" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>Low Stock</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
    <asp:TextBox ID="txtSearch" runat="server" Height="23px"  />
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
        <br />
        <br />
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
    <ContentTemplate>
          <asp:GridView ID="gvStockList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4">   
        <Columns>
        <asp:BoundField DataField="Value.ProductName" HeaderText="Name"/>        
        <asp:BoundField DataField="Value.UnitPrice" HeaderText="Price" DataFormatString="{0:c}"/>
        <asp:BoundField DataField="Value.QuantityHeld" HeaderText="Stock Level"/>
        <asp:BoundField DataField="Value.ReorderLevel" HeaderText="Reorder Level"/>
        <asp:BoundField DataField="Value.ReorderQuantity" HeaderText="Reorder Quantity"/>
                <asp:TemplateField>
                <ItemTemplate>
                    <a href='EditProduct.aspx?ProductId=<%# Eval("Value.ProductId") %>&Action=Edit'>Edit</a>
                </ItemTemplate>        
                </asp:TemplateField> 
                <asp:TemplateField>
                <ItemTemplate>
                    <a href='StockManagement.aspx?ProductId=<%# Eval("Value.ProductId") %>&Action=Reorder'>Reorder</a>
                </ItemTemplate>        
                </asp:TemplateField> 
                 <asp:TemplateField>
                <ItemTemplate>
                    <a href='StockManagement.aspx?ProductId=<%# Eval("Value.ProductId") %>&Action=Delete'>Delete</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>    
    </asp:GridView>
            <br />
    
    <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>
    </ContentTemplate>

    <Triggers>
        <asp:AsyncPostBackTrigger controlid="ddlProducts" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </asp:Content>

