<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentacion.Alumnos.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col col-lg-6 ">

    <h1>Datos del Alumno</h1>
    <hr />
    <table class="table table-hover col col-md-2">
        <tbody>
        <tr>
            <td><strong>Id</strong></td>
            <td>
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Nombre</strong></td>
            <td>
                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Primer Apellido</strong></td>
            <td>
                <asp:Label ID="lblPApe" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Segundo Apellido</strong></td>
            <td>
                <asp:Label ID="lblSApe" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Correo</strong></td>
            <td>
                <asp:Label ID="lblCorreo" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Telefono</strong></td>
            <td>
                <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Fecha de Nacimiento</strong></td>
            <td>
                <asp:Label ID="lblFNaci" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Curp</strong></td>
            <td>
                <asp:Label ID="lblCurp" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Sueldo</strong></td>
            <td>
                <asp:Label ID="lblSueldo" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Estado de Origen</strong></td>
            <td>
                <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><strong>Estatus</strong></td>
            <td>
                <asp:Label ID="lblEstatus" runat="server" Text=""></asp:Label></td>
        </tr>

            <tr>
                <td>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-default" />
                </td>
            </tr>

            <tr>
                <td>
                    <p><a href ="Index.aspx">Regresar a lista</a></p>
                </td>
            </tr>

            </tbody>
    </table>
    <br />
    

        </div>

</asp:Content>
