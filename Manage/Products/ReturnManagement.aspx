<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="ReturnManagement.aspx.cs" Inherits="Manage_Products_ReturnManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
        <br />
        <br />
        <br />
          <asp:GridView ID="gvReturnList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4" >   
        <Columns>     
        <asp:BoundField DataField="Value.ReturnDate" HeaderText="Return Date"/>      
        <asp:BoundField DataField="Value.Reason" HeaderText="Reason"/>     
        <asp:BoundField DataField="Value.Condition" HeaderText="Condition"/>
        <asp:BoundField DataField="Value.Username" HeaderText="Username"/>
               <asp:TemplateField ItemStyle-Width="50px">

                <ItemTemplate>
                    <a href='ReturnManagement.aspx?ReturnId=<%# Eval("Value.ReturnId") %>&Action=Approve'>Approve</a>
                </ItemTemplate>        
        </asp:TemplateField> 
            <asp:TemplateField ItemStyle-Width="50px">

                <ItemTemplate>
                    <a href='ReturnManagement.aspx?ReturnId=<%# Eval("Value.ReturnId") %>&Action=Remove'>Remove</a>
                </ItemTemplate>        
        </asp:TemplateField> 
        </Columns>    

    </asp:GridView>
    <br />
    <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>
    <br />
    </asp:Content>

