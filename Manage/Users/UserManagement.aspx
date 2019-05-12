<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="Manage_Users_UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Button ID="btnAddCustomer" runat="server" Text="Add Customer" OnClick="btnAddCustomer_Click" />
    
        <asp:Button ID="btnAddStaff" runat="server" Text="Add Staff" OnClick="btnAddStaff_Click" />
    
                <br />
    
                <br />
        <asp:DropDownList ID="ddlUsers" runat="server" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>Customers</asp:ListItem>
            <asp:ListItem>Staff</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
    <asp:TextBox ID="txtSearch" runat="server" Height="23px"/>
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
        <br />
        <br />
    
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Middle">
         <Columns>      
        <asp:BoundField DataField="Value.Username" HeaderText="Username"/> 
        <asp:BoundField DataField="Value.JobTitle" HeaderText="Job Title"/> 
        <asp:BoundField DataField="Value.FirstName" HeaderText="First Name"/>  
        <asp:BoundField DataField="Value.LastName" HeaderText="Last Name"/>  
        <asp:BoundField DataField="Value.PhoneNo" HeaderText="Number"/>  
        <asp:BoundField DataField="Value.Email" HeaderText="Email"/>     
             <asp:TemplateField ItemStyle-Width="50px">
                <ItemTemplate>
                    <a href='EditUser.aspx?Username=<%# Eval("Value.Username") %>&Type=Customer'>Edit</a>
                </ItemTemplate>        
        </asp:TemplateField>          
             <asp:TemplateField ItemStyle-Width="50px">
                <ItemTemplate>
                    <a href='EditUser.aspx?Username=<%# Eval("Value.Username") %>&Type=Staff'>Edit</a>
                </ItemTemplate>        
        </asp:TemplateField>      
             <asp:TemplateField ItemStyle-Width="50px">
                <ItemTemplate>
                    <a href='UserManagement.aspx?Username=<%# Eval("Value.Username") %>&Type=Customer'>Delete</a>
                </ItemTemplate>        
        </asp:TemplateField> 
              <asp:TemplateField ItemStyle-Width="50px">
                <ItemTemplate>
                    <a href='UserManagement.aspx?Username=<%# Eval("Value.Username") %>&Type=Staff'>Delete</a>
                </ItemTemplate>        
        </asp:TemplateField> 

        </Columns>    
    </asp:GridView>
      </ContentTemplate>
         <Triggers>
        <asp:AsyncPostBackTrigger controlid="ddlUsers" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>

    <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>

    <br />
    <br />

</asp:Content>

