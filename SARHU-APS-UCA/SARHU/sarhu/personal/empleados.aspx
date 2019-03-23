<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="empleados.aspx.cs" Inherits="SARHU.sarhu.personal.empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div id="page-wrapper">
      <div class="row">
           <div class="col-lg-12">
                <h1 class="page-header">Listado de Empleados</h1>
                <a href="agregar-empleado.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Empleado</a>
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
                                    <th>Código</th>
                                    <th>Nombres</th>
                                    <th>Apellidos</th>
                                    <th>Programa</th>
                                    <th width="200px">Operaciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td>230319</td>
                                    <td>Maria Juana</td>
                                    <td>Maldonado Palacios</td>
                                    <td>Centro de Formación Hermann Gmeiner Estelí</td>
                                    <td align="center">
                                      <a data-toggle="modal" data-target="#mediumModal"  type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Empleado"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-empleado.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Empleado"><i class="fa fa-edit fa-fw"></i></span></a>
                                         <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Empleado"><i class="fa fa-trash-o fa-fw"></i></span></button>
                                    </td>

                                </tr>
                                <tr class="odd gradeX">
                                    <td>230320</td>
                                    <td>Pedro Luis</td>
                                    <td>Rodriguez Mendez</td>
                                    <td>Programa de Fortalecimiento Familiar Somoto</td>
                                    <td align="center">
                                      <a data-toggle="modal" data-target="#mediumModal"  type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Empleado"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-empleado.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Empleado"><i class="fa fa-edit fa-fw"></i></span></a>
                                         <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Empleado"><i class="fa fa-trash-o fa-fw"></i></span></button>
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
                    <h2 class="modal-title" id="mediumModalLabel">Detalle del Empleado</h2>
                   
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
                                        <div class="col-md-12" id="tabs">
                                           <ul class="nav nav-tabs">
                                                <li class="active"><a href="#datosP" data-toggle="tab">Datos Personales</a></li>
                                                <li ><a href="#datosA" data-toggle="tab">Datos Administrativos</a></li>
                                           </ul>
                                           <div class="tab-content">
                                                <div class="tab-pane fade in active" id="datosP">
                                                    <label>Código</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="number" class="form-control" value="230319" disabled="">
                                                            </div>
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th>Sexo</th>
                                                                <th>Edad</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                     <input type="radio" name="gender" value="male" style="margin-left: 5px;" disabled="">Masculino
                                                                     <input type="radio" name="gender" value="Female"  checked="" disabled="">Femenino
                                                                </td>
                                                                <td><input class="form-control" style="margin-left: 83px;width: 45px;" type="text" placeholder="" id="edad" disabled="" value="48" ></td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>
                                                        <label>Nombres</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control" disabled="" value="Maria Juana" >
                                                            </div>
                                                        <label>Apellidos</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control" disabled="" value="Maldonado Palacios">
                                                            </div>
                                                        <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th>Cédula</th>
                                                                <th>Fecha de Nacimiento</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                     <input class="form-control" type="text"  id="cedula" placeholder="" tabindex="14" disabled="" value="001-171180-0005B">
                                                                </td>
                                                                <td>
                                                                     <input class="form-control" type="text"  id="fechaN" placeholder="" tabindex="8" value="24/02/1971" disabled="">
                                                                </td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>
                                                     <label>Teléfono</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <span class="input-group-addon">+505</span>
                                                            <input class="form-control" type="text"  id="Telefono" placeholder="" tabindex="8" disabled="" value="8256-7651">
                                                        </div>
                                                    <div class="form-group" style="width: 100%;">
                                                        <label>Dirección</label>
                                                        <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" name="textarea" disabled="">B° Juana Elena Mendoza, costado Este Escuela Maria Llanes</textarea>
                                                    </div>  
                                                    <label>Estado Civil</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <input type="text" class="form-control" value="Soltero/a" disabled="" >
                                                        </div>
                                                    <label>Nivel Académico</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <input type="text" class="form-control" value="Técnico" disabled="" >
                                                        </div>
                                                    </div>
                                                <div class="tab-pane fade " id="datosA">                                   
                                                     <label>Inss</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input class="form-control" type="text"  id="inss" placeholder="0000000-0" tabindex="8" disabled="" value="5132706-0">
                                                            </div>
                                                     <label>Fecha de Ingreso</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input class="form-control" type="text"  id="fechaI" placeholder="00/00/0000" tabindex="8" disabled="" value="07/04/2018">
                                                            </div>
                                                    <label>Programa</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <input type="text" class="form-control" value="Centro de Formación Hermann Gmeiner Estelí" disabled="" >
                                                        </div>
                                                    <label>Puesto</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <input type="text" class="form-control" value="Bibliotecario/a" disabled="" >
                                                        </div>                                    
                                                   <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th>Salario</th>
                                                                <th>Banco</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                     <div class="form-group input-group" style="width: 100%;">
                                                                        <span class="input-group-addon">C$</span>
                                                                        <input class="form-control" id="Monto" type="text" disabled="" value="10,000">
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group input-group" style="width: 100%;">
                                                                        <input type="text" class="form-control" value="No" disabled="" >
                                                                    </div>  
                                                                </td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>
                                                    <div class="form-group" style="width: 100%;">
                                                        <label>Observaciones</label>
                                                        <textarea style="resize:none" id="textarea1" rows="5" cols="5" class="form-control" maxlength="200" name="textarea" disabled="">Su nuevo salario a partir del primero de Octubre del 2019 es de C$8,900</textarea>
                                                        <div id="textarea_feedback1">200 caracteres disponibles</div>
                                                    </div>  
                                                        <label>Antigüedad</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control" disabled="" value="0 Años con 11 Meses y 16 Días">
                                                            </div>
                                                    <label>Fecha de Egreso/Cambio</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input class="form-control" type="text"  id="fechaE" placeholder="00/00/0000" tabindex="8" disabled="" value="13/08/2019">
                                                                </div>
                                                        <div class="form-group" style="width: 100%;">
                                                            <label>Observaciones de Egreso</label>
                                                            <textarea style="resize:none" id="textarea2" rows="5" cols="5" class="form-control" maxlength="200" disabled="" name="textarea">Asuntos personales</textarea>
                                                            <div id="textarea_feedback2">200 caracteres disponibles</div>
                                                        </div> 
                                            </div> 
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
                        <!-- /.col-lg-6 (nested) -->
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
                                            ¿Está seguro que desea borrar al empleado con código "230319"?
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

    <script>

    $(document).ready(function () {
                $('#dataTables-example').DataTable({
                    responsive: true
                });
            });
 </script>
</asp:Content>
