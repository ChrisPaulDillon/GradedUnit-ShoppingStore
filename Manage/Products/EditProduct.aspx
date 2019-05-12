<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="Manage_Products_EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblWarning" runat="server"></asp:Label>
    <asp:Label ID="lblMessage" Text="For the original values to remain, please leave the textboxes as the default values" runat="server"></asp:Label>
    <br />
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 166px">Product Name:</td>
            <td style="width: 227px">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">Description:</td>
            <td style="width: 227px">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">Price:</td>
            <td style="width: 227px">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Text="0" Width="190px" TextMode="Number" Min="0" Max="1000"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Quantity Held:</td>
             <td style="width: 227px">
                <asp:Label ID="lblQuantityHeld" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtQuantityHeld" runat="server" Text="0" Width="190px" TextMode="Number" Min="0" Max="1000"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Reorder Level:</td>
             <td style="width: 227px">
                <asp:Label ID="lblReorderLevel" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReorderLevel" runat="server" Text="0" Width="190px" TextMode="Number" Min="0" Max="1000"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">Reorder Quantity:</td>
             <td style="width: 227px">
                <asp:Label ID="lblReorderQuantity" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReorderQuantity" runat="server" Text="0" Width="190px" TextMode="Number" Min="0" Max="1000"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 166px">&nbsp;</td>
            <td style="width: 227px">
                &nbsp;</td>
             <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" />
            </td>
        </tr> 
    </table> 
</asp:Content>