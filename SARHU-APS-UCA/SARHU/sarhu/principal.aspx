<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="SARHU.sarhu.principal" %>

<asp:Content ID="ContentPrincipal" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <div class="col-md-6">
                    <h1 class="page-header">Información Organizacional</h1>
                </div>
                <div id="alertitaVerde" class="alert alert-success col-md-6 alertas collapse">
                    <button id="mibotoncerrar" class="close">&times;</button>
                    El registro ha sido <strong>actualizado</strong> correctamente.
                </div>
                <div id="alertitaAmarilla" class="alert alert-warning col-md-6 alertas collapse">
                    <button id="mibotoncerrar2" class="close">&times;</button>
                    <strong>¡Ups!</strong> al final no se dejó guardar...
                </div>
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
                                    <asp:Panel ID="panelNotificacion" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <i class="fa-lg fa fa-exclamation-circle "></i>
                                                <% =Mensaje %>
                                            </asp:Panel>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Nombre</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox ID="orgNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <%--                                        TODO: PENDIENTE
                                            <label>Localidad</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox ID="orgLocalidadAlias" CssClass="form-control" runat="server"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <a data-toggle="modal" data-target="#mediumModal" type="button" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Lista de Localidades"><i class="fa fa-search"></i></span></a>
                                                </span>
                                            </div>--%>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Misión</label>

                                                <textarea style="resize: none" id="textareaM" rows="5" cols="5" class="form-control" maxlength="200" name="textarea" runat="server"></textarea>
                                                <div id="textareaM_feedback">200 caracteres disponibles</div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Visión</label>
                                                <textarea style="resize: none" id="textareaV" rows="5" cols="5" class="form-control" maxlength="200" name="textarea" runat="server"></textarea>
                                                <div id="textareaV_feedback">200 caracteres disponibles</div>
                                            </div>

                                            <div class="form-group" style="width: 100%;">
                                                <label>Descripción</label>
                                                <textarea style="resize: none" id="textareaD" rows="5" cols="5" class="form-control" maxlength="200" name="textarea" runat="server"></textarea>
                                                <div id="textareaD_feedback">200 caracteres disponibles</div>
                                            </div>

                                            <div class="form-group" align="center">
                                                <asp:Button ID="btnActualizar" CssClass="btn btn-success fondo-verde-aldeas" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                                                <%--<button id="btnActualizafr" class="btn btn-success  fondo-verde-aldeas" align="center">Actualizar</button>--%>
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
    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Lista de Localidades</h2>
                </div>
                <div class="modal-body">
                    <div id="page-wrapper1">
                        <div class="row">
                            <div class="col-md-6 col-md-offset-6">
                                <div class="panel panel-formulario">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="panel panel-default2">
                                                    <div>
                                                        <h5 class="modalLittle" id="littleModalLabel">Seleccione</h5>
                                                    </div>
                                                    <div class="panel-body tooltip-demo">
                                                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                                                            <thead>
                                                                <tr>
                                                                    <th>Departamento</th>
                                                                    <th>Municipio</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr class="odd gradeX">
                                                                    <td>Somoto</td>
                                                                    <td>Totogalpa</td>
                                                                </tr>
                                                                <tr class="even gradeC" style='border: inset 0pt'>
                                                                    <td>Estelí</td>
                                                                    <td>Pueblo Nuevo</td>
                                                                </tr>
                                                                <tr class="even gradeD" style='border: inset 0pt'>
                                                                    <td>Managua</td>
                                                                    <td>Managua</td>
                                                                </tr>
                                                                <tr class="even gradeE" style='border: inset 0pt'>
                                                                    <td>Masaya</td>
                                                                    <td>Masatepe</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <!-- /.table-responsive -->
                                                    </div>
                                                    <!-- /.panel-body -->
                                                </div>
                                                <!-- /.panel -->
                                            </div>
                                            <!-- /.col-lg-12 -->
                                        </div>
                                        <!-- /.row (nested) -->
                                    </div>
                                    <!-- /.panel-body -->
                                </div>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                        </div>

                    </div>

                </div>

            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            var text_l = $('#ContentPlaceHolder_textareaM').val().length;
            var text_max = 200;
            $('#textareaM_feedback').html(text_max - text_l + ' caracteres disponibles');

            $('#ContentPlaceHolder_textareaM').keyup(function () {
                var text_length = $('#ContentPlaceHolder_textareaM').val().length;
                var text_remaining = text_max - text_length;

                $('#textareaM_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });

        $(document).ready(function () {
            var text_l = $('#ContentPlaceHolder_textareaV').val().length;
            var text_max = 200;
            $('#textareaV_feedback').html(text_max - text_l + ' caracteres disponibles');

            $('#ContentPlaceHolder_textareaV').keyup(function () {
                var text_length = $('#ContentPlaceHolder_textareaV').val().length;
                var text_remaining = text_max - text_length;

                $('#textareaV_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });

        $(document).ready(function () {
            var text_l = $('#ContentPlaceHolder_textareaD').val().length;
            var text_max = 200;
            $('#textareaD_feedback').html(text_max - text_l + ' caracteres disponibles');

            $('#ContentPlaceHolder_textareaD').keyup(function () {
                var text_length = $('#ContentPlaceHolder_textareaD').val().length;
                var text_remaining = text_max - text_length;

                $('#textareaD_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });

        var hasFaded = false;

        $(document).ready(function () {
            setTimeout(function () {
                $("#panelNotificacion").fadeOut("slow", function () {
                    //$('#alertitaAmarilla').show('fade');
                });
            }, 3500);
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#btnActualizar').click(function () {
                $('#alertitaVerde').show('fade');
                setTimeout(function () {
                    $('#alertitaVerde').hide('fade');
                    $('#alertitaAmarilla').show('fade');
                    setTimeout(function () {
                        $('#alertitaAmarilla').hide('fade');
                    }, 2500)
                }, 2500)
            })
            $('#mibotoncerrar2').click(function () {
                $('#alertitaAmarilla').hide('fade');

            })
        })
    </script>
</asp:Content>
