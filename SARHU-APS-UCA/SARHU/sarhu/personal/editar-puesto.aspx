<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="editar-puesto.aspx.cs" Inherits="SARHU.sarhu.personal.editar_puesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Puesto</h1>
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
                                            <label>Nombre</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Descripción</label>
                                                <textarea style="resize: none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                            </div>

                                            <label>Salario Base</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <span class="input-group-addon">C$</span>
                                                <input id="quantity" class="form-control">
                                              
                                            </div>
                                              <div class="alert alert-danger alert-dismissable" id="errmsg" hidden="hidden"></div>
                                            <label>Cuenta</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <select class="form-control">
                                                    <option>Seleccione..</option>
                                                    <option>proveedores SOS </option>
                                                    <option>Ingresos Diversos </option>
                                                </select>
                                            </div>

                                            <label>Área</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <select class="form-control">
                                                    <option>Seleccione..</option>
                                                    <option>Finanzas </option>
                                                    <option>Contabilidad </option>
                                                </select>
                                            </div>

                                            <div class="form-group input-group">
                                                <label>Funciones Asociadas a Este Puesto</label>
                                                <span class="input-group-btn">
                                                    <a data-toggle="modal" data-target="#mediumModal" style="border-bottom-left-radius:4px; border-top-left-radius:4px" type="button" class="btn btn-default"><span data-toggle="tooltip"   data-placement="top" title="Lista de Directores"><i class="fa fa-plus-circle"></i></span></a>
                                                </span>
                                            </div>
                                            <table width="100%" class="table table-striped table-bordered table-hover">
                                                <thead>
                                                    <tr>
                                                        <th class="tableHeader">Función</th>

                                                        <th class="tableHeader">Eliminar</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr class="odd gradeX">
                                                        <td class="tableData">Gerente General</td>

                                                        <td align="center">
                                                            <button type="button" class="btn btn-danger fondo-rojo-aldeast"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Rol"><i class="fa fa-minus-circle fa-fw"></i></span></button>
                                                        </td>
                                                    </tr>
                                                    <tr class="even gradeC" style='border: inset 0pt'>
                                                        <td class="tableData">Administrador</td>

                                                        <td align="center">
                                                            <button type="button" class="btn btn-danger fondo-rojo-aldeast"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Rol"><i class="fa fa-minus-circle fa-fw"></i></span></button>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <div class="form-group" align="center">
                                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Guardar</button>
                                                <a href="puestos.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
                    <h2 class="modal-title" id="mediumModalLabel">Lista de Funciones</h2>
                </div>
                <div class="modal-body">
                    <div id="page-wrapper1">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">
                                <div class="panel panel-formulario">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="panel panel-default2">
                                                    <div>
                                                        <h5 class="modalLittle" id="littleModalLabel">Seleccione Funciones</h5>
                                                    </div>
                                                    <div class="panel-body tooltip-demo">
                                                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-funcion">
                                                            <thead>
                                                                <tr>
                                                                    <th class="tableHeader">ID</th>
                                                                    <th class="tableHeader">Nombre</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr class="odd gradeX">
                                                                    <td class="tableData">001</td>
                                                                    <td class="tableData">limpieza </td>
                                                                </tr>
                                                                <tr class="even gradeC" style='border: inset 0pt'>
                                                                    <td class="tableData">002</td>
                                                                    <td class="tableData">Administrador </td>
                                                                </tr>
                                                                <tr class="even gradeD" style='border: inset 0pt'>
                                                                    <td class="tableData">003</td>
                                                                    <td class="tableData">Director </td>
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
            var text_max = 150;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });

         $('#filterme').keypress(function (eve) {
            if ((eve.which != 46 || $(this).val().indexOf('.') != -1) && (eve.which < 48 || eve.which > 57) || (eve.which == 46 && $(this).caret().start == 0)) {
                eve.preventDefault();
                $("#errmsg").html("Solo Digitos").show().fadeOut(800);
            }

            // this part is when left part of number is deleted and leaves a . in the leftmost position. For example, 33.25, then 33 is deleted
            $('#filterme').keyup(function (eve) {
                if ($(this).val().indexOf('.') == 0) {
                    $(this).val($(this).val().substring(1));
                }
            });
        });

           $(document).ready(function () {
            $('#dataTables-funcion').DataTable({
                responsive: true
            });
        });

</script>

</asp:Content>
