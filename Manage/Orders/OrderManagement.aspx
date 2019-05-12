<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="OrderManagement.aspx.cs" Inherits="Manage_Orders_OrderManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
        <asp:RadioButtonList ID="rdbType" runat="server" RepeatColumns="2" OnSelectedIndexChanged="rdbType_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem>All Orders</asp:ListItem>
                            <asp:ListItem>Unshipped Orders</asp:ListItem>
                        </asp:RadioButtonList>
    <br />
     <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Middle">
         <Columns>      
        <asp:BoundField DataField="Value.OrderDate" HeaderText="Order Date"/> 
        <asp:BoundField DataField="Value.Username" HeaderText="Username"/>    
        <asp:BoundField DataField="Value.ShippingStatus" HeaderText="Status" ItemStyle-Width="140px"/>            
        <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <%#:String.Format("{0:c}", Convert.ToDouble(Eval("Value.Total"))) %>
                </ItemTemplate>        
        </asp:TemplateField> 
             <asp:TemplateField ItemStyle-Width="50px">

                <ItemTemplate>
                    <a href='OrderManagement.aspx?OrderId=<%# Eval("Value.OrderId") %>'>Approve</a>
                </ItemTemplate>        
        </asp:TemplateField> 

        </Columns>    
    </asp:GridView>
                <br />
    <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>
       </ContentTemplate>

    <Triggers>
        <asp:AsyncPostBackTrigger controlid="rdbType" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

