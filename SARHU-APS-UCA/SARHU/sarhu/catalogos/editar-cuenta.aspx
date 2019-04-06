<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="editar-cuenta.aspx.cs" Inherits="SARHU.sarhu.catalogos.editar_cuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Cuenta</h1>
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

                                            <label>Código Contable</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <input disabled="disabled" type="text" class="form-control">
                                            </div>

                                            <label>Cuenta Salario</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <input type="text" class="form-control">
                                            </div>

                                            <label>Cuenta Impuesto</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <input type="text" class="form-control">
                                            </div>

                                            <label>Cuenta Seguro</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <input type="text" class="form-control">
                                            </div>

                                            <div  class="form-group input-group" style="width: 100%;">
                                                 <input type="checkbox" name="Cuenta" value="Si" > Cuenta Planilla
                                            </div>

                                                <label>Descripción</label>
                                                <textarea style="resize: none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                <div id="textarea_feedback" class="form-group input-group" style="width: 100%;">200 caracteres disponibles</div>

                                            <div class="form-group" align="center">
                                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Editar</button>
                                                <a href="cuentas.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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

</asp:Content>
