<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="adendums.aspx.cs" Inherits="SARHU.sarhu.personal.adendums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Listado de Adendums</h1>
                <a href="agregar-adendum.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Adéndum</a>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default2">
                    <div class="panel-body tooltip-demo">
                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>Código Adéndum</th>
                                    <th>Nombre de Empleado</th>
                                    <th>Puesto</th>
                                    <th>Aunmento Salarial</th>
                                    <th width="200px">Operaciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td> 001</td>
                                    <td> Junior Gonzalez</td>
                                    <td> Administrador</td>
                                    <td> 00.0</td>
                                    <td align="center">

                                        <a data-toggle="modal" data-target="#mediumModal" href="#" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Adéndum"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-adendum.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Adéndum"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Adéndum"><i class="fa fa-trash-o fa-fw"></i></span></button>
                                    </td>
                                </tr>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td>002</td>
                                    <td>Maria López</td>
                                    <td>Contador</td>
                                    <td> 00.0</td>

                                    <td align="center">
                                        <a data-toggle="modal" data-target="#mediumModal" href="#" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Adéndum"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-adendum.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Adéndum"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Adéndum"><i class="fa fa-trash-o fa-fw"></i></span></button>
                                    </td>
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

    </div>

    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Detalle del Adéndum</h2>
                </div>
                <div class="modal-body">
                    <div id="page-wrapper1">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-6 col-md-offset-6">
                                            <div class="panel panel-formulario">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-md-12">

                                                            <label>Código Adéndum</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input disabled="disabled" type="text" class="form-control">
                                                            </div>
                                                                
                                                            <label>Nombre de Empleado</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                    <div  class="form-group input-group" style="width: 100%;" >
                                                                         <input disabled="disabled" class="form-control" ></>
                                                             </div>

                                                            <label>Área</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input disabled="disabled" id="quantity" class="form-control">
                                                            </div>

                                                              <label>Puesto</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input disabled="disabled" id="quantit" class="form-control">
                                                            </div>

                                                            <label>Monto de Aumento</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input disabled="disabled" id="quanti" class="form-control">
                                                            </div>

                                                                  <label>Fecha de aplicación de adéndum</label>
                                                                    <div class="form-group input-group" style="width: 100%;">
                                                                         <input disabled="disabled" type="date" id="fechaAden" class="form-control" runat="server" name="FechaAdendum" step="1" max="2000-12-31" value="2000-01-01">
                                                                    </div>

                                                              <div class="form-group" style="width: 100%;">
                                                                <label>Observaciones</label>
                                                                <textarea disabled="disabled" style="resize: none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                                            </div>

                                                            <div class="form-group input-group">
                                                                <label>Nuevas Funciones</label>
                                                              
                                                            </div>
                                                            <table width="100%" class="table table-striped table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="tableHeader">Función</th>

                                                                   
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr class="odd gradeX">
                                                                        <td class="tableData">Gerente General</td>

                                                                 
                                                                    </tr>
                                                                    <tr class="even gradeC" style='border: inset 0pt'>

                                                                        <td class="tableData">Administrador</td>

                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                      

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

                    </div>

                </div>

            </div>
        </div>
    </div>
          </div>

    <script>
        function ShowPopup() {
            $('#myModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

        function DeletePopup() {
            $('#delete').modal({ backdrop: 'static', keyboard: false }, 'show');
        }


        $('#closemodal').click(function () {
            $('#mymodal').modal('hide');

        });

        $(document).ready(function () {
            $('#dataTables-example').DataTable({
                responsive: true
            });
        });

    </script>

</asp:Content>
