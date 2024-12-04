<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ADOWebForms.forms.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Detalles</h1>

    <dl>

        <dt>ID</dt>
        <dd><asp:Label ID="lblId" runat="server" Text="-"></asp:Label></dd>

        <dt>Nombre</dt>
        <dd><asp:Label ID="lblNombre" runat="server" Text="-"></asp:Label></dd>

        <dt>Clave</dt>
        <dd><asp:Label ID="lblClave" runat="server" Text="-"></asp:Label></dd>

    </dl>

    <asp:Button ID="btnReturn" runat="server" Text="Regresar" OnClick="btnReturn_Click" />

</asp:Content>
