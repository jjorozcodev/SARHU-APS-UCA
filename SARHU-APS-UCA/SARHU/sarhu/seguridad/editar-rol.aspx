﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="editar-rol.aspx.cs" Inherits="SARHU.sarhu.seguridad.editar_rol" %>
<asp:Content ID="ContentEditarRol" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Rol</h1>
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
                                <input type="text" class="form-control" value="Responsable de Nómina">
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label>Descripción</label>
                                <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="50" name="textarea" >Se encarga de ver lo que corresponde a la nómina.</textarea>
                                <div id="textarea_feedback">150 caracteres disponibles</div>
                            </div>

                            <div class="form-group" align="center">
                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Editar</button>
                                <a href="roles.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
            var text_max = 50;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });


        
    </script>
</asp:Content>
