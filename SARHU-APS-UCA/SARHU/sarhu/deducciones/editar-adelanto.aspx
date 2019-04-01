<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="editar-adelanto.aspx.cs" Inherits="SARHU.sarhu.deducciones.editar_adelanto" %>

<asp:Content ID="ContentEditarAdelanto" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Adelanto</h1>
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
                                        <asp:Panel ID="panel" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                            <i class="fa-lg fa fa-exclamation-circle "></i>
                                            <%=Message %>
                                        </asp:Panel>
                                        <div class="col-md-12">
                                            <asp:HiddenField ID="Idadelanto" runat="server" />
                                            <label>Empleado</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:DropDownList CssClass="form-control" ID="Empleado" runat="server" InitialValue="Please select" ErrorMessage="Please select something"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="Empleado"
                                                    ErrorMessage="Selecciona Empleado"
                                                    InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                    </asp:RequiredFieldValidator>
                                            </div>

                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                            <div class="form-group" style="width: 100%">
                                                <label>Fecha Entrega</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="date" id="idFechaEntrega" class="form-control" runat="server" name="FechaEntrega" step="1" format="yyyy-mm-dd" min="2019-01-01" max="2019-12-31" value="2019-03-27">
                                                </div>
                                            </div>

                                            <div class="form-group" style="width: 100%">
                                                <label>Fecha Deduccion</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="date" id="idFechaDeduccion" class="form-control" runat="server" name="FechaDeduccion" step="1" format="yyyy-mm-dd" min="2019-01-01" max="2019-12-31" value="2019-03-27">
                                                </div>
                                            </div>

                                            <label>Monto C$</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <asp:TextBox ID="Monto" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="Monto"
                                                    ErrorMessage="Monto requerido"
                                                    SetFocusOnError="True" ForeColor="#FF3300">
                                                </asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group" style="width: 100%;">
                                                <label>Descripcion</label>
                                                <textarea style="resize: none" id="textarea" rows="5" cols="5" runat="server" clientidmode="Static" class="form-control" maxlength="200" name="textarea"></textarea>
                                                <div id="textarea_feedback">200 caracteres disponibles</div>
                                            </div>

                                            <div class="form-group" align="center">
                                                <asp:Button runat="server" ID="Guardar" CssClass="btn btn-success  fondo-verde-aldeas" align="center" Text="Guardar" OnClick="Guardar_Click"></asp:Button>
                                                <a href="adelantos.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
            var text_max = 200;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });



    </script>

    <script type="text/javascript">
        $(function () {
            $("#Telefono").mask("9999-9999", { placeholder: " " });
        });

        $(document).ready(function () {
            setTimeout(function () {
                $("#panel").fadeOut("slow", function () {
                    location.href = 'http://<% =HttpContext.Current.Request.Url.Authority %><% =HttpContext.Current.Request.ApplicationPath %>/sarhu/deducciones/adelantos'
                });
                //#popupBox is the DIV to fade out
            }, 2000); //5000 equals 5 seconds
        });

    </script>
</asp:Content>
