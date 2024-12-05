<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Alumnos.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Listado de Alumnos</h1>
    <hr />

    <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click"  />

    <br /><br />
    <asp:GridView ID="grdvAlumnos" runat="server" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" OnPageIndexChanging="grdvAlumnos_PageIndexChanging" OnRowCommand="grdvAlumnos_RowCommand" BorderStyle="None" CssClass="table table-hover" GridLines="Horizontal" PagerStyle-CssClass =" carousel" >
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="pApellido" HeaderText="Primer Apellido" />
            <asp:BoundField DataField="sApellido" HeaderText="Segundo Apellido" />
            <asp:BoundField DataField="correo" HeaderText="Correo" />
            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="idEstadoOrigen" HeaderText="Estado" />
            <asp:BoundField DataField="idEstatus" HeaderText="Estatus" />
            
            <asp:ButtonField CommandName="btnDetalles" Text="Detalles">
            <ControlStyle CssClass="btn btn-warning btn-sm" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="btnEditar" Text="Editar">
            <ControlStyle CssClass="btn btn-success btn-sm" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="btnEliminar" Text="Eliminar">
            <ControlStyle CssClass="btn btn-danger btn-sm" />
            </asp:ButtonField>

        </Columns>
        
       
    </asp:GridView>

</asp:Content>
