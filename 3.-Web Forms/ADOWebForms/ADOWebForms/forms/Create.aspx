<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ADOWebForms.forms.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        table {
            width: 25%;
        }

        td {
            width: 10%;
        }
    </style>

    <h1>Agregar</h1>

    <table>

        <tbody>

            <tr>
                <td>
                    <h5>ID</h5>
                </td>
                <td>
                    <asp:TextBox ID="boxId" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <h5>Nombre</h5>
                </td>
                <td>
                    <asp:TextBox ID="boxNombre" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <h5>Clave</h5>
                </td>
                <td>
                    <asp:TextBox ID="boxClave" runat="server"></asp:TextBox>
                </td>
            </tr>

        </tbody>

    </table>

    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    </br> </br> </br>

    <h5>
        <asp:Label ID="lblIdNuevo" runat="server" Text=""></asp:Label>
    </h5>

</asp:Content>
