<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="editar-localidad.aspx.cs" Inherits="SARHU.sarhu.catalogos.editar_localidad" %>
<asp:Content ID="ContentEditarLocalidad" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Localidad</h1>
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
                           <label>Programa</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control" value="Fortalecimiento Familiar" >
                            </div>
                            <label>Departamento</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control" value="Somoto" disabled="" >
                            </div>
                            <label>Municipio</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control" value="Totogalpa" disabled="">
                            </div>
                            <label>Director</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control" value="Maria Espinoza">
                                <span class="input-group-btn">
                                    <a data-toggle="modal" data-target="#mediumModal" type="button" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Lista de Directores"><i class="fa fa-search"></i></span></a>
                                </span>
                            </div>
                            <label>Alias</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control" value="Programa de Fortalecimiento Familiar Somoto" >
                            </div>
                            <div>
                                <label>Teléfono</label>
                            </div>
                            <div class="form-group input-group" style="width: 100%;">
                                <span class="input-group-addon">+505</span>
                                <input class="form-control" value="2224-5897">
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label>Dirección</label>
                                <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="200" name="textarea">Barrio Totogalpa calle 14.</textarea>
                                <div id="textarea_feedback">200 caracteres disponibles</div>
                            </div>

                            <div class="form-group" align="center">
                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Editar</button>
                                <a href="localidades.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
                     <button style="font-size:35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Lista de Directores</h2>     
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
                    <div><h5 class="modalLittle" id="littleModalLabel">Seleccione</h5></div>
                    <div class="panel-body tooltip-demo">
                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Nombre</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td>001</td>
                                    <td>María Espinoza</td>
                                </tr>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td>002</td>
                                    <td>Luis Morales</td>
                                </tr>
                                 <tr class="even gradeD" style='border: inset 0pt'>
                                    <td>003</td>
                                    <td>Andrea Mendez</td>
                                </tr>
                                <tr class="even gradeE" style='border: inset 0pt'>
                                    <td>004</td>
                                    <td>Rodrigo Hernandez</td>
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
            var text_max = 200;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });


        
    </script>
</asp:Content>
