<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Presentacion.Alumnos.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     


    <h1>Actualizar Alumno</h1>
<hr />

<style>
    table {
        width: 50%;
    }

    th, td {
        width: 25%;
        text-align: left;
    }
</style>

<table>
    <tr>
        <td><strong>Id</strong></td>
        <td>
            <asp:TextBox ID="txtId" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Nombre</strong></td>
        <td>
            <asp:TextBox ID="txtNombre" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Primer Apellido</strong></td>
        <td>
            <asp:TextBox ID="txtPApe" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Segundo Apellido</strong></td>
        <td>
            <asp:TextBox ID="txtSApe" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Correo</strong></td>
        <td>
            <asp:TextBox ID="txtCorreo" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Telefono</strong></td>
        <td>
            <asp:TextBox ID="txtTelefono" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Fecha de Nacimiento</strong></td>
        <td>
            <asp:TextBox ID="txtFNaci" runat="server" Text="" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Curp</strong></td>
        <td>
            <asp:TextBox ID="txtCurp" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Sueldo</strong></td>
        <td>
            <asp:TextBox ID="txtSueldo" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><strong>Estado de Origen</strong></td>
        <td>
            <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td><strong>Estatus</strong></td>
        <td>
            <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
        </td>
    </tr>
</table>
<br />

    <hr />
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
    <br />
    <asp:Label ID="lblEx" runat="server" Text=""></asp:Label></td>

</asp:Content>
