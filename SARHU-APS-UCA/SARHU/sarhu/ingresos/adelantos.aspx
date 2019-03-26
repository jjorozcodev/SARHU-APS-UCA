<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="adelantos.aspx.cs" Inherits="SARHU.sarhu.ingresos.adelantos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">


            <div id="page-wrapper">
      <div class="row">
           <div class="col-lg-12">
                <h1 class="page-header">Listado de Adelantos</h1>
                <a href="agregar-adelanto.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Adelanto</a>
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

                                  <th>Empleado</th>
                                  <th>C$ Monto</th>
                                  <th>Fecha de entrega</th> 
                                  <th>Fecha de deduccion</th> 
                                    
                                             
                                  <th width="200px">Operaciones</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">

                                        <td>Marlon Peraza</td>
                                        <td>C$ 2500.60</td>
                                        <td>2019-03-27</td>                                            
                                        <td>2019-08-4</td>  

                                        <td align="center">

                                           <a data-toggle="modal" data-target="#mediumModal"  type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Adelanto"><i class="fa fa-eye fa-fw"></i></span></a>
                                            <a href="editar-adelanto.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Adelanto"><i class="fa fa-edit fa-fw"></i></span></a>
                                           <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Adelanto"><i class="fa fa-trash-o fa-fw"></i></span></button>
                                        
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
                     <button style="font-size:35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Detalle del Adelanto</h2>
                   
                </div>
                <div class="modal-body">

                    <div id="page-wrapper1">
                        <div class="row">
                        <div class="col-md-6 col-md-offset-6">
        <div class="panel panel-formulario">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">



                             <label>Empleado</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <select class="form-control" disabled="">                                   
                                    <option>Marlon Peraza</option>                                   
                                </select>
                            </div>
   
                            <div><label>Monto</label></div>
                            <div class="form-group input-group" style="width: 100%;">
                                <span class="input-group-addon">C$</span>
                                <input class="form-control" id="Monto" type="text" value="2500.60" disabled="">
                            </div>

                            <div><label>Fecha de entrega</label></div>                          
                            <div class="form-group input-group" style="width: 100%;">
                              <input type="text" class="form-control" value="2019-03-27" disabled="" >
                            </div>
   
                            <div><label>Fecha de deduccion</label></div>                          
                            <div class="form-group input-group" style="width: 100%;">
                              <input type="text" class="form-control" value="2019-08-04" disabled="" >
                            </div>
   
                          
                            <div class="form-group" style="width: 100%;">
                                <label>Descripción</label>
                                <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea" disabled="" ReadOnly>Se ha realizado un adelanto al empleado correspondiente</textarea>
                            </div>

                     

                        </div>
                        <!-- /.col-lg-6           (nested) -->
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




        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button style="font-size:30px" type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">¡Atención!</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Está seguro que desea borrar "Marlon Peraza"?
                                        </div>
                                        <div class="modal-footer">
                                            <button  onclick="DeletePopup()" data-dismiss="modal" type="button" class="btn btn-danger fondo-rojo-aldeas">Borrar</button>
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
                    Borrado correctamente
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
















</asp:Content>
