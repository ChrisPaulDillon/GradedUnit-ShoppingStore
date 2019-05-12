<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="FindUs.aspx.cs" Inherits="FindUs" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <cc1:GMap ID="GMap1" runat="server" Width="1000px" Height="500px" />
</asp:Content>
