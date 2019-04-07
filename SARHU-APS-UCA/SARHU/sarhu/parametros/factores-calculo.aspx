<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="factores-calculo.aspx.cs" Inherits="SARHU.sarhu.parametros.factores_calculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <div class="col-md-6">
                    <h1 class="page-header">Factores de Cálculo</h1>
                </div>
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
                                            <div class="form-group" style="width: 100%">
                                                <label>Días en Año</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="360">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Días en Mes</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="30">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Factor Mensual</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="2.5" disabled="">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Factor Diario</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="0.0833333333" disabled="">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Meses Prestaciones</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="6">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Indemnización Año 1-3</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="30">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Factor Indemnización Año 1-3</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="2.5" disabled="">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Indemnización Año 4-6</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="20">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Factor Indemnización Año 4-6</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="1.6666" disabled="">
                                                </div>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Factor Indemnización Diario Año 4-5</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input type="text" class="form-control" value="0.055555" disabled="">
                                                </div>
                                            </div>
                                            <div class="form-group" align="center">
                                                <button id="btnActualizar" class="btn btn-success  fondo-verde-aldeas" align="center">Actualizar</button>
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
