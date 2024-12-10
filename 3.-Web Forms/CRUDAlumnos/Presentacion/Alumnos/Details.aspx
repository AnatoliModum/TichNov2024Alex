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
                    <td>
                        <asp:Button ID="btnCalcularIMMS" runat="server" Text="CalcularIMMS  " CssClass="btn btn-primary" Font-Size="X-Small" OnClick="btnCalcularIMMS_Click" /></td>
                    <%--<td><asp:Button ID="btnCalcularISR" runat="server" Text="CalcularISR" CssClass="btn btn-default" Font-Size ="X-Small" OnClick="btnCalcularISR_Click" /></td>--%>
                </tr>

                <tr>
                    <td>
                        <p><a href="Index.aspx">Regresar a la lista</a></p>
                    </td>
                </tr>
            </tbody>

        </table>
        <div> <input id="btnCalcularISR" type="button" value="CalcularISR" class="btn btn-primary" onclick="calcularIsrJS()" /></div>
        <%--        <asp:Label ID="lblData" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnHide" runat="server" Text="Ocultar" CssClass="btn btn-primary" Font-Size="X-Small" OnClick="btnHide_Click" />--%>
    </div>


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


    <div class="modal fade" id="ModalIMSS" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Modal title</h4>
                </div>
                <div class="modal-body">
                    <dl>

                        <dt>Enfermedad Maternidad
                        </dt>
                        <dd>
                            <asp:Label ID="lblmEnfMat" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>Invalidez Vida
                        </dt>
                        <dd>
                            <asp:Label ID="lblmInvVid" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>Retiro
                        </dt>
                        <dd>
                            <asp:Label ID="lblmRet" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>Cesantia
                        </dt>
                        <dd>
                            <asp:Label ID="lblmCes" runat="server" Text=""></asp:Label>
                        </dd>

                        <dt>Infonavit
                        </dt>
                        <dd>
                            <asp:Label ID="lblmInfo" runat="server" Text=""></asp:Label>
                        </dd>

                    </dl>
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


    <script type="text/javascript">
        function calcularIsrJS() {

            let _WSurl = 'http://localhost:60081/WSAlumnos.asmx/CalcularIsr';
            let id = $("#<%=lblId.ClientID%>").text();
            let _JSId = JSON.stringify({ id: id });

            $.ajax({

                type: 'POST',
                url: _WSurl,
                data: _JSId,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: RecibeObjetoIsr,
                error: errorGenerico
            })
        }

 

        function RecibeObjetoIsr(resultado) {
            let itemTablaIsr = resultado.d;
            if (itemTablaIsr != null) {
                $("#<%=lblmLI.ClientID%>").text(itemTablaIsr.limiteInferior);
                $("#<%=lblmLS.ClientID%>").text(itemTablaIsr.limiteSuperior);
                $("#<%=lblmCF.ClientID%>").text(itemTablaIsr.cuotaFija);
                $("#<%=lblmExc.ClientID%>").text(itemTablaIsr.excedente);
                $("#<%=lblmSub.ClientID%>").text(itemTablaIsr.subsidio);
                $("#<%=lblmISR.ClientID%>").text(itemTablaIsr.ISR);
                $("#ModalIsr").modal('show');
            }
        }

        function errorGenerico(jqXHR, estatus, error) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No está conectado, favor de verificar su conexión.';
            }
            else if (jqXHR.status === 404) {
                msg = 'Página no encontrada [404]';
            }
            else if (jqXHR.status === 500) {
                msg = 'Error no hay conexión al servidor [500]';
            }
            else if (jqXHR.status === 'parseerror') {
                msg = 'El parseo del JSON es erróneo.';
            }
            else if (jqXHR.status === 'timeout') {
                $('body').addClass('loaded');
            }
            else if (jqXHR.status === 'abort') {
                msg = 'La petición Ajax fue abortada.';
            }
            else {
                msg = 'Error no conocido. ';
                console.log(exception);
            }
            alert(msg);
        }

    </script>

 

</asp:Content>
