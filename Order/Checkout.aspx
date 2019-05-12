<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Order_Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <asp:Label ID="lblWarning" runat="server" Visable="false"></asp:Label> 
       <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:GridView ID="gvDisplayOrder" runat="server" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="Value.Product.ProductName" HeaderText="Name"/>        
        <asp:BoundField DataField="Value.Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}"/>           
        <asp:BoundField DataField="Value.Quantity" HeaderText="Quantity"/>        
        <asp:TemplateField HeaderText="Item Total">
                <ItemTemplate>
                    <%#:String.Format("{0:c}", Convert.ToDouble(Eval("Value.Quantity")) * Convert.ToDouble(Eval("Value.Product.UnitPrice"))) %>
                </ItemTemplate>        
        </asp:TemplateField> 
        </Columns>          
    </asp:GridView>
    <br />

    Please Select an appropriate shipping method below<br />
    <asp:RadioButtonList ID="rdbType" runat="server" RepeatColumns="2" OnSelectedIndexChanged="rdbType_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem Text="Next Day Delivery (£4)">NextDay</asp:ListItem>
                            <asp:ListItem Text ="Standard Delivery [3-5 Days] (Free)">Standard</asp:ListItem>
                        </asp:RadioButtonList>
    <br />
    <br />
    <asp:ImageButton ID="btnFinish" runat="server" 
                      ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" 
                      Width="145px" AlternateText="Check out with PayPal" 
                      OnClick="btnFinish_Click" 
                      BackColor="Transparent" BorderWidth="0" Height="40px" />
       &nbsp;<br />
  
       <br />
  
<asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
    <ContentTemplate>
         <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
         <br />
    </ContentTemplate>

    <Triggers>
        <asp:AsyncPostBackTrigger controlid="rdbType" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

    <asp:Label ID="lblCancel" runat="server" Text="If you would no longer wish to continue with your order "></asp:Label><asp:LinkButton ID="lbCancel" runat="server" OnClick="lbCancel_Click" CausesValidation="false">Click here to cancel</asp:LinkButton>
</asp:Content>

