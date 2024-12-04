<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HolaMundoWebForms.WFEstados.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <dl>
        <dt>
            <asp:Label ID="lblEstado" runat="server" Text="Estado: "></asp:Label>
        </dt>
        <dd>
            <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
        </dd>
    </dl> </hr>

    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />


</asp:Content>
