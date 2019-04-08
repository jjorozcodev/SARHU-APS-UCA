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

                            
                        

                             <label>Empleado</label>
                       <div class="form-group input-group" style="width: 100%;">
                             <div class="form-group input-group" style="width: 100%;">
                         <input disabled="disabled" class="form-control"></>
                        <span class="input-group-btn">
                           <a data-toggle="modal" data-target="#empleadoModal" type="button" class="btn btn-default">
                         <span data-toggle="tooltip" data-placement="top" title="Lista de Empleados"><i class="fa fa-search"></i></span></a>
                        </span>
                           </div>
               

                                <label>Rol</label>
                       <div class="form-group input-group" style="width: 100%;">
                             <div class="form-group input-group" style="width: 100%;">
                         <input disabled="disabled" class="form-control"></>
                        <span class="input-group-btn">
                           <a data-toggle="modal" data-target="#rolModal" type="button" class="btn btn-default">
                         <span data-toggle="tooltip" data-placement="top" title="Lista de Roles"><i class="fa fa-search"></i></span></a>
                        </span>
                           </div>
               


                                <label>Contraseña</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control">
                            </div>

                                <label>Correo Electrónico</label>
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







    <div class="modal fade" id="empleadoModal" tabindex="-1" role="dialog" aria-labelledby="empleadoModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="empleadoModalLabel">Lista de Empleados</h2>
                </div>
                <div class="modal-body">
                    <div id="page-wrappelr2">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">
                                <div class="panel panel-formulario">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="panel panel-default2">
                                                    <div> <br />
                                                        <h5 class="modalLittle" id="littleModalLabels2">Seleccione Empleado</h5>
                                                    </div>
                                                    <div class="panel-body tooltip-demo">
                                                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-empleado">
                                                            <thead>
                                                                <tr>
                                                                    <th class="tableHeader">ID</th>
                                                                    <th class="tableHeader">Nombre</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr class="odd gradeX">
                                                                    <td class="tableData">001</td>
                                                                    <td class="tableData">Maria López </td>
                                                                </tr>
                                                                <tr class="even gradeC" style='border: inset 0pt'>
                                                                    <td class="tableData">002</td>
                                                                    <td class="tableData">Brandon Caballero</td>
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



            
    <div class="modal fade" id="rolModal" tabindex="-1" role="dialog" aria-labelledby="empleadoModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button> 
                    <h2 class="modal-title" id="rolModalLabel">Lista de Rol</h2>
                </div>
                <div class="modal-body">
                    <div id="page-wrappelr1">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">
                                <div class="panel panel-formulario">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="panel panel-default2">
                                                    <div>  <br />
                                                        <h5 class="modalLittle" id="littleModalLabels">Seleccione Rol</h5>
                                                    </div>
                                                    <div class="panel-body tooltip-demo">
                                                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-rol">
                                                            <thead>
                                                                <tr>
                                                                    <th class="tableHeader">ID</th>
                                                                    <th class="tableHeader">Nombre</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr class="odd gradeX">
                                                                    <td class="tableData">001</td>
                                                                    <td class="tableData">Administrativo </td>
                                                                </tr>
                                                                <tr class="even gradeC" style='border: inset 0pt'>
                                                                    <td class="tableData">002</td>
                                                                    <td class="tableData">Jardinero</td>
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


            $('.tooltip-demo').tooltip({
                selector: "[data-toggle=tooltip]",
                container: "body"
            })




        $(document).ready(function () {
            var text_max = 150;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });



        $(document).ready(function () {
            $('#dataTables-empleado').DataTable({
                responsive: true
            });
        });


        $(document).ready(function () {
            $('#dataTables-rol').DataTable({
                responsive: true
            });
        });




        
    </script>













</asp:Content>
