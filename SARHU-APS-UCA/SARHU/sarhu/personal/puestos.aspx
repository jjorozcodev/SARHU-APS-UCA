<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="puestos.aspx.cs" Inherits="SARHU.sarhu.personal.puestos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Listado de Puestos</h1>
                <a href="agregar-puesto.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Puesto</a>
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
                                    <th>Nombre</th>
                                    <th>Descripción</th>
                                    <th>Salario Base</th>
                                    <th width="200px">Operaciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td>Gerente General</td>
                                    <td>Se encarga de ver lo que corresponde a la nómina.</td>
                                    <td>10,000 </td>
                                    <td align="center">

                                        <a data-toggle="modal" data-target="#mediumModal" href="#" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Puesto"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-puesto.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Puesto"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Puesto"><i class="fa fa-trash-o fa-fw"></i></span></button>
                                    </td>
                                </tr>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td>Administrador</td>
                                    <td>Encargado de la administracion del sistema.</td>
                                    <td>8,000</td>
                                    <td align="center">
                                        <a data-toggle="modal" data-target="#mediumModal" href="#" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Puesto"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-puesto.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Puesto"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Puesto"><i class="fa fa-trash-o fa-fw"></i></span></button>
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
                    <h2 class="modal-title" id="mediumModalLabel">Detalle del Puesto</h2>

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
                                                            <label>Nombre</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input disabled="disabled" type="text" class="form-control">
                                                            </div>
                                                            <div class="form-group" style="width: 100%;">
                                                                <label>Descripción</label>
                                                                <textarea disabled="disabled" style="resize: none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                                            </div>

                                                            <label>Salario Base</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input disabled="disabled" id="quantity" class="form-control">
                                                            </div>
                                                            <div class="alert alert-danger alert-dismissable" id="errmsg" hidden="hidden"></div>
                                                            <label>Cuenta</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <select disabled="disabled"  class="form-control">
                                                                    <option>Seleccione..</option>
                                                                    <option>proveedores SOS </option>
                                                                    <option>Ingresos Diversos </option>
                                                                </select>
                                                            </div>

                                                            <label>Área</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <select disabled="disabled" class="form-control">
                                                                    <option>Seleccione..</option>
                                                                    <option>Finanzas </option>
                                                                    <option>Contabilidad </option>
                                                                </select>
                                                            </div>

                                                            <div class="form-group input-group">
                                                                <label>Funciones Asociadas a Este Puesto</label>
                                                                <span class="input-group-btn">
                                                                    
                                                                </span>
                                                            </div>
                                                            <table  width="100%" class="table table-striped table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="tableHeader">Función</th>

                                                                     
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr class="odd gradeX">
                                                                        <td class="tableData">Gerente General</td>

                                                                       
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="even gradeC" style='border: inset 0pt'>
                                                                        <td  class="tableData">Administrador</td>
                                                                        
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <div class="form-group" align="center">
                                                               
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
