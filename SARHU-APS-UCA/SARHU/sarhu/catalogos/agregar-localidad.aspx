<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregar-localidad.aspx.cs" Inherits="SARHU.Views.Administracion.Localidades.agregar_localidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agregar Localidad</h1>
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
                            <label>Programas</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <select class="form-control" >
                                    <option>Programa de Fortalecimiento Familiar Somoto</option>
                                    <option>Centro de Formación Hermann Gmeiner Estelí</option>
                                </select>
                            </div>
                            <label>Municipios</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <select class="form-control" >
                                    <option>Totogalpa</option>
                                    <option>Pueblo Nuevo</option>
                                </select>
                            </div>
                            <label>Directores</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <select class="form-control" >
                                    <option>General</option>
                                    <option>General</option>
                                </select>
                            </div>
                            <label>Alias</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control">
                            </div>
                             <div>
                                <label>Teléfono</label>
                            </div>
                            <div class="form-group input-group" style="width: 100%;">
                                <span class="input-group-addon">+505</span>
                                <input class="form-control" type="number" >
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label>Dirección</label>
                                <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="200" name="textarea"></textarea>
                                <div id="textarea_feedback">200 caracteres disponibles</div>
                            </div>
                            <div class="form-group" align="center">
                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Guardar</button>
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
