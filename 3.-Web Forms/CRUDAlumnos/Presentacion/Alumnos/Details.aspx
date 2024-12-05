<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Presentacion.Alumnos.Details" %>

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
                        <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><strong>Estatus</strong></td>
                    <td>
                        <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td><asp:Button ID="btnCalcularIMMS" runat="server" Text="CalcularIMMS  " CssClass="btn btn-primary" Font-Size ="X-Small" OnClick="btnCalcularIMMS_Click" /></td>
                    <td><asp:Button ID="btnCalcularISR" runat="server" Text="CalcularISR" CssClass="btn btn-default" Font-Size ="X-Small" OnClick="btnCalcularISR_Click" /></td>
                </tr>

                <tr>
                    <td><p><a href="Index.aspx">Regresar a la lista</a></p></td>
                </tr>
            </tbody>

        </table>

        <asp:Label ID="lblData" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnHide" runat="server" Text="Ocultar" CssClass="btn btn-primary" Font-Size ="X-Small" OnClick="btnHide_Click" />

</div>

</asp:Content>
