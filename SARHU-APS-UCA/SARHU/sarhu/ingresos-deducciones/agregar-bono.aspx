<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="agregar-bono.aspx.cs" Inherits="SARHU.sarhu.ingresos.agregar_bono" %>

<asp:Content ID="ContentAgregarBono" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agregar Bono</h1>
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
                                            <div class="form-group input-group" style="width: 100%;">
                                                <label>Nombre</label>
                                                <asp:TextBox ID="bonoNombre" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <label>Descripción</label>
                                                <textarea style="resize: none" id="bonoDescripcion" runat="server" rows="5" cols="5" class="form-control" required="required" maxlength="150" name="textarea"></textarea>
                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                            </div>
                                            <label>Monto</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <span class="input-group-btn">
                                                    <button class="btn btn-default" type="button" disabled>C$</button>
                                                </span>
                                                <asp:TextBox ID="bonoMonto" type="number" step=".01" min="1.00" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>
                                            <div class="form-group" align="center">
                                               <asp:Button runat="server" class="btn btn-success  fondo-verde-aldeas" ID="btnGuardar" Text="Guardar" OnClick="Guardar_Click" />
                                                <a href="bonos.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
            var text_max = 150;
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
                    location.href = 'http://<% =HttpContext.Current.Request.Url.Authority %><% =HttpContext.Current.Request.ApplicationPath %>/sarhu/ingresos-deducciones/bonos' 
                });
            }, 2500);
        });
    </script>

</asp:Content>
