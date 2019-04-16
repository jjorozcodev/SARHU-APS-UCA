<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="historial-planillas.aspx.cs" Inherits="SARHU.sarhu.planilla.historial_planillas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div id="page-wrapper">
      <div class="row">
           <div class="col-lg-12">
                <h1 class="page-header">Listado de Planillas</h1>
                <a href="procesar-planilla.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Procesar Planilla</a>
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
                                    <th>ID</th>
                                    <th>Localidad</th>
                                    <th>Fecha de Elaboración</th>
                                    <th>Aprobado</th>
                                    <th>Fecha de Aprobación</th>
                                    <th width="200px">Operaciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td>0001</td>
                                    <td>Colegio SOS Chinandega-Chichigalpa</td>
                                    <td>14/04/2019</td>
                                    <td>Si</td>
                                    <td>15/04/2019</td>
                                    <td align="center">
                                        <a href="editar-planilla.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Planilla"><i class="fa fa-edit fa-fw"></i></span></a>
                                         <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Aprobar Planilla"><i class="fa fa-check fa-fw"></i></span></button>
                                    </td>
                                </tr>
                                <tr class="odd gradeX">
                                    <td>0002</td>
                                    <td>Fortalecimiento Familiar Masaya-Catarina</td>
                                    <td>14/04/2019</td>
                                    <td>No</td>
                                    <td>15/04/2019</td>
                                    <td align="center">
                                        <a href="editar-planilla.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Planilla"><i class="fa fa-edit fa-fw"></i></span></a>
                                         <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Aprobar Planilla"><i class="fa fa-check fa-fw"></i></span></button>
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

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button style="font-size:30px" type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">¡Atención!</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Está seguro que desea aprobar la planilla con el ID "0001"?
                                        </div>
                                        <div class="modal-footer">
                                            <button  onclick="DeletePopup()" data-dismiss="modal" type="button" class="btn btn-danger fondo-rojo-aldeas">Aprobar</button>
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button> 
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
     </div>

    <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    Aprobado correctamente
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
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
    </script>
    <script>

    $(document).ready(function () {
                $('#dataTables-example').DataTable({
                    responsive: true
                });
            });
 </script>
</asp:Content>
