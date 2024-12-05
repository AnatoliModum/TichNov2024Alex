<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Presentacion.Alumnos.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="col col-lg-6 ">

        <h1>Actualizar Alumno</h1>
        <hr />

        <table class="table table-hover col col-md-2">
            <tbody>
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
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtNombre" ErrorMessage="Este campo es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revName" runat="server" ControlToValidate="txtNombre" ErrorMessage="Solo se permiten letras y espacios" ValidationExpression="^[a-zA-Z\s]+$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><strong>Primer Apellido</strong></td>
                    <td>
                        <asp:TextBox ID="txtPApe" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPApe" runat="server" ControlToValidate="txtPApe" ErrorMessage="Este campo es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPApeEd" runat="server" ControlToValidate="txtPApe" ErrorMessage="Solo se permiten letras y espacios" ValidationExpression="^[a-zA-Z\s]+$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><strong>Segundo Apellido</strong></td>
                    <td>
                        <asp:TextBox ID="txtSApe" runat="server" Text=""></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revSApeEdit" runat="server" ControlToValidate="txtSApe" ErrorMessage="Solo se permiten letras y espacios" ValidationExpression="^[a-zA-Z\s]+$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><strong>Correo</strong></td>
                    <td>
                        <asp:TextBox ID="txtCorreo" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Este campo es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="rfvFNaci" runat="server" ControlToValidate="txtFNaci" ErrorMessage="Este campo es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvFecha" runat="server" ControlToValidate="txtFNaci" ErrorMessage="La fecha de nacimiento debe estar entre el 01-ene-1990 y el 31-dic-2000." MinimumValue="1990-01-01" MaximumValue="2000-12-31" Type="Date" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td><strong>Curp</strong></td>
                    <td>
                        <asp:TextBox ID="txtCurp" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCurp" runat="server" ControlToValidate="txtCurp" ErrorMessage="Este campo es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvCurp" runat="server" ControlToValidate="txtCurp" ErrorMessage="El formato del CURP es inválido." CssClass="text-danger" Display="Dynamic" OnServerValidate="cvCurp_ServerValidate"></asp:CustomValidator>
                        <asp:CustomValidator ID="cv2Curp" runat="server" ControlToValidate="txtCurp" ErrorMessage="El formato del CURP es inválido." CssClass="text-danger" Display="Dynamic" OnServerValidate="cv2Curp_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td><strong>Sueldo</strong></td>
                    <td>
                        <asp:TextBox ID="txtSueldo" runat="server" Text=""></asp:TextBox>
                        <asp:RangeValidator ID="rvSueldo" runat="server" ControlToValidate="txtSueldo" ErrorMessage="El sueldo deberá estar entre 10,000 y 40,000 pesos" MinimumValue="10000" MaximumValue="40000" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
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
                <tr>
                    <td>
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-default" Font-Size="Smaller" />
                    </td>
                    <td>
                        <p><a href="Index.aspx">Regresar a lista</a></p>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
    </div>

    <hr />

    <br />
    <asp:Label ID="lblEx" runat="server" Text=""></asp:Label></td>

    <%--<script type="text/javascript">
        function validarCURP(sender, args) {
            var curp = args.value;

            var year = curp.substring(4, 6);
            var month = curp.substring(6, 8);
            var day = curp.substring(8, 10);
            var fechaNacimiento = document.getElementById('<%= txtFNaci.ClientID %>').value;
            
        }
    </script>--%>

</asp:Content>
