<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Presentacion.Alumnos.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col col-lg-6 ">

        <h1>Agregar Alumno</h1>
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
                        <asp:RegularExpressionValidator ID="revNameCreate" runat="server" ControlToValidate="txtNombre" ErrorMessage="Solo se permiten letras y espacios" ValidationExpression="^[a-zA-Z\s]+$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><strong>Primer Apellido</strong></td>
                    <td>
                        <asp:TextBox ID="txtPApe" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPApe" runat="server" ControlToValidate="txtPApe" ErrorMessage="Este campo es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPApeCreate" runat="server" ControlToValidate="txtPApe" ErrorMessage="Solo se permiten letras y espacios" ValidationExpression="^[a-zA-Z\s]+$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><strong>Segundo Apellido</strong></td>
                    <td>
                        <asp:TextBox ID="txtSApe" runat="server" Text=""></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revSApe" runat="server" ControlToValidate="txtSApe" ErrorMessage="Solo se permiten letras y espacios" ValidationExpression="^[a-zA-Z\s]+$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
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
                        <asp:CustomValidator ID="cvCurp" runat="server" ControlToValidate="txtCurp" ErrorMessage="El formato del CURP es inválido." ClientValidationFunction="validarCURP" CssClass="text-danger" Display="Dynamic"></asp:CustomValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCurp" ErrorMessage="El formato del CURP es inválido." OnServerValidate="cv2Curp_ServerValidate" CssClass="text-danger" Display="Dynamic"></asp:CustomValidator>
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
                        <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCreate_Click" CssClass="btn btn-default" />
                    </td>
                    <td>
                        <p><a href="Index.aspx">Regresar a lista</a></p>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:Label ID="lblEx" runat="server" Text=""></asp:Label>



    <div class="modal fade" id="ModalIsr" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Modal title</h4>
                </div>
                <div class="modal-body">

                    <dl>

                        <dt>Limite Inferior
                        </dt>
                        <dd>
                            <asp:Label ID="lblmLI" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>Limite Superior
                        </dt>
                        <dd>
                            <asp:Label ID="lblmLS" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>Cuota Fija
                        </dt>
                        <dd>
                            <asp:Label ID="lblmCF" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>Excedente
                        </dt>
                        <dd>
                            <asp:Label ID="lblmExc" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>Subsidio
                        </dt>
                        <dd>
                            <asp:Label ID="lblmSub" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>ISR
                        </dt>
                        <dd>
                            <asp:Label ID="lblmISR" runat="server" Text=""></asp:Label>
                        </dd>

                    </dl>

                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title">Modal title</h4>
                            </div>
                            <div class="modal-body">
                                <p>One fine body&hellip;</p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                <button type="button" class="btn btn-primary">Save changes</button>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>




    <script type="text/javascript"> 
        function validarCURP(sender, args) {

            var curpForm = args.Value;
            var dayCurp = curpForm.substr(8, 2);
            var monthCurp = curpForm.substr(6, 2);
            var yearCurp = curpForm.substr(4, 2);
            var fechaCurp = yearCurp + "-" + monthCurp + "-" + dayCurp;

            var fechaNacimiento = document.getElementById('<%= txtFNaci.ClientID %>').value.substr(2, 10);
            args.IsValid = curpForm.length === 18;

            if (args.IsValid) {
                args.IsValid = fechaCurp === fechaNacimiento;
            }
        }
    </script>


</asp:Content>
