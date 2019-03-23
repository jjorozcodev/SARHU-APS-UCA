<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="agregar-usuario.aspx.cs" Inherits="SARHU.sarhu.seguridad.agregar_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">




    
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agregar Usuario</h1>
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

                            
                            <label>Rol</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <select class="form-control" >
                                    <option >Seleccione..</option>
                                    <option>Administrador</option>
                                    <option>Responsable de Nomina</option>
                                </select>
                            </div>
               

                            <label>Colaborador</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <select class="form-control" >
                                    <option >Seleccione..</option>
                                    <option>Alberto Mairena</option>
                                    
                                </select>
                            </div>
               

                                <label>Usuario Clave</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control">
                            </div>

                                <label>Correo Electronico</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control">
                            </div>
                       




                            <div class="form-group" align="center">
                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Guardar</button>
                                <a href="usuarios.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });


        
    </script>













</asp:Content>
