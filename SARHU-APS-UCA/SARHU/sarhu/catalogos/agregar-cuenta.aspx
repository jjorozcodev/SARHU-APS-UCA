<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="agregar-cuenta.aspx.cs" Inherits="SARHU.sarhu.catalogos.agregar_cuenta" %>
<asp:Content ID="ContentCuenta" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agregar Cuenta</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6 col-md-offset-6">
                            <div class="panel panel-formulario">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Panel ID="panelNotificacion" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <i class="fa-lg fa fa-exclamation-circle "></i>
                                                <% =Mensaje %>
                                            </asp:Panel>
                                            <label>Código Contable</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox ID="codigoContable" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <label>Cuenta Salario</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox ID="cuentaSalario" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <label>Cuenta Impuesto</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox ID="cuentaImpuestos" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <label>Cuenta Seguro</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox ID="cuentaSeguro" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <label>Cuenta Planilla</label>
                                            <div  class="form-group input-group" style="width: 100%;">
                                                <asp:CheckBox ID="cuentaPlanilla" runat="server" CssClass="form-check-input" required="required"></asp:CheckBox>
                                            </div>

                                            <label>Descripción</label>
                                            <textarea style="resize: none" id="cuentaDescripcion" runat="server" rows="5" cols="5" class="form-control" maxlength="25" name="textarea"></textarea>
                                            <div id="textarea_feedback">25 caracteres disponibles</div>

                                            <div class="form-group" align="center">
                                               <asp:Button runat="server" class="btn btn-success  fondo-verde-aldeas" ID="btnGuardar" Text="Guardar" OnClick="Guardar_Click" />
                                                <a href="cuentas.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
                                            </div>

                                        </div>
                                        <!-- /.col-lg-6 (nested) -->
                                    </div>
                                    <!-- /.row (nested) -->
                                </div>
                                <!-- /.panel-body -->
                            </div>
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
     </div>

    <script>
        $(document).ready(function () {
            var text_max = 25;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#ContentPlaceHolder_bonoDescripcion').keyup(function () {
                var text_length = $('#ContentPlaceHolder_bonoDescripcion').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });

        $(document).ready(function () {
            setTimeout(function () {
                $("#panelNotificacion").fadeOut("slow", function () {
                    location.href = 'http://<% =HttpContext.Current.Request.Url.Authority %><% =HttpContext.Current.Request.ApplicationPath %>/sarhu/catalogos/cuentas' 
                });
            }, 2500);
        });
    </script>

</asp:Content>