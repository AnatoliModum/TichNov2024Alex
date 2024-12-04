<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ADOWebForms.forms.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <dl>
       <dt><h1>Indice</h1></dt>
       <dd>Estatus: </dd>
       <dd><asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList></dd>
   </dl>
    </hr>

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    <asp:Button ID="btnDetalles" runat="server" Text="Detalles" OnClick="btnDetalles_Click" />
    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

    <asp:Label ID="lblErrorers" runat="server" Text=""></asp:Label>

</asp:Content>
