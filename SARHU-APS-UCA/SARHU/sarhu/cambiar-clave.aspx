<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="cambiar-clave.aspx.cs" Inherits="SARHU.sarhu.cambiar_contraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cambiar Contraseña</h1>
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
                                            <label>Actual</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <input type="password" class="form-control">
                                            </div>
                                            <label>Nueva</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <input type="password" class="form-control">
                                            </div>
                                            <label>Repetir Contraseña Nueva</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <input type="password" class="form-control">
                                            </div>
                                            <div class="form-group" align="center">
                                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Actualizar</button>
                                                <a href="inicio.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
