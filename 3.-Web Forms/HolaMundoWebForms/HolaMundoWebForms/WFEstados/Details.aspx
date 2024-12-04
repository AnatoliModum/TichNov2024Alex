<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="HolaMundoWebForms.WFEstados.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <dl>
        <dt>Id</dt>
        <dd><asp:Label ID="lblId" runat="server" Text=""></asp:Label></dd>
        
        <dt><asp:Label ID="lblNombreTer" runat="server" Text="Nombre"></asp:Label></dt>
        <dd><asp:Label ID="lblNombreDef" runat="server" Text=""></asp:Label></dd>
    </dl>

</asp:Content>
