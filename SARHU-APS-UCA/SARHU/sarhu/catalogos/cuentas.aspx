<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="cuentas.aspx.cs" Inherits="SARHU.sarhu.catalogos.cuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Listado de Cuentas</h1>
                <a href="agregar-cuenta.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Cuenta</a>
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
                                    <th>Código Contable</th>
                                    <th>Descripción</th>
                                    <th width="200px">Operaciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td> 008</td>
                                    <td> Banco</td>
                                    <td align="center">

                                        <a data-toggle="modal" data-target="#ModalCuenta" href="#" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Cuenta"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-cuenta.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Cuenta"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Cuenta"><i class="fa fa-trash-o fa-fw"></i></span></button>
                                    </td>
                                </tr>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td>002</td>
                                    <td>Banco</td>
                                    <td align="center">
                                        <a data-toggle="modal" data-target="#ModalCuenta" href="#" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Cuenta"><i class="fa fa-eye fa-fw"></i></span></a>
                                        <a href="editar-cuenta.aspx" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Cuenta"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <button type="button" onclick="ShowPopup()" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Cuenta"><i class="fa fa-trash-o fa-fw"></i></span></button>
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

     <div class="modal fade" id="ModalCuenta" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Detalle de la Cuenta</h2>
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

                                                            <label>Código Contable</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input disabled="disabled" type="text" class="form-control">
                                                                </div>

                                                                <label>Cuenta Salario</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input disabled="disabled" type="text" class="form-control">
                                                                </div>

                                                                <label>Cuenta Impuesto</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input disabled="disabled" type="text" class="form-control">
                                                                </div>

                                                                <label>Cuenta Seguro</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input disabled="disabled" type="text" class="form-control">
                                                                </div>

                                                                <div  class="form-group input-group" style="width: 100%;">
                                                                     <input disabled="disabled" type="checkbox" name="Cuenta" value="Si" > Cuenta Planilla
                                                                </div>

                                                                <label>Descripción</label>
                                                                <textarea disabled="disabled" style="resize: none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                                <div  id="textarea_feedback" class="form-group input-group" style="width: 100%;">200 caracteres disponibles</div>

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

           $(document).ready(function () {
            $('#dataTables-example').DataTable({
                responsive: true
            });

    </script>

</asp:Content>
