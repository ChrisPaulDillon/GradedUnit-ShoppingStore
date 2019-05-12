<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
      <table style="width: 100%">
        <tr>
            <td style="width: 166px;">Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="190px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtName"
                    ErrorMessage="Name is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">Description:</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Width="190px"></asp:TextBox>
                 <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtDescription"
                    ErrorMessage="Description is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">Price:</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Width="190px"></asp:TextBox>
                 <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtPrice"
                    ErrorMessage="Price is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Quantity Held:</td>
            <td>
                <asp:TextBox ID="txtQuantityHeld" runat="server" Width="190px"></asp:TextBox>
                 <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                    ControlToValidate="txtQuantityHeld"
                    ErrorMessage="Quantity Held is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Reorder Level:</td>
            <td>
                <asp:TextBox ID="txtReorderLevel" runat="server" Width="190px"></asp:TextBox>
                 <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtReorderLevel"
                    ErrorMessage="Reorder Level is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Reorder Quantity:</td>
            <td>
                <asp:TextBox ID="txtReorderQuantity" runat="server" Width="190px"></asp:TextBox>
                 <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
                    ControlToValidate="txtReorderQuantity"
                    ErrorMessage="Reorder Quantity is a required field."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="width: 166px"></td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#33CC33" Visible="False"></asp:Label>
            </td>
        </tr>
        
    </table> 

     </asp:Content>
