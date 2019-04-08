﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="editar-rol.aspx.cs" Inherits="SARHU.sarhu.seguridad.editar_rol" %>

<asp:Content ID="ContentEditarRol" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Rol</h1>
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
                                            <asp:Panel ID="panelNotificacion" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <i class="fa-lg fa fa-exclamation-circle "></i>
                                                <% =Mensaje %>
                                            </asp:Panel>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <label>Nombre</label>
                                                <asp:TextBox ID="rolNombre" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Descripción</label>
                                                <textarea style="resize: none" id="rolDescripcion" runat="server" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                            </div>
                                            <div class="form-group" align="center">
                                                <asp:Button ID="Editar" Text="Editar" runat="server" CssClass="btn btn-success  fondo-verde-aldeas" align="center" OnClick="Editar_click"></asp:Button>
                                                <a href="roles.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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

    <script>
        $(document).ready(function () {
            var text_l = $('#ContentPlaceHolder_programaDescripcion').val().length;
            var text_max = 150;
            $('#textarea_feedback').html(text_max - text_l + ' caracteres disponibles');

            $('#ContentPlaceHolder_programaDescripcion').keyup(function () {
                var text_length = $('#ContentPlaceHolder_programaDescripcion').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });

        $(document).ready(function () {
            setTimeout(function () {
                $("#panelNotificacion").fadeOut("slow", function () {
                    location.href = 'http://<% =HttpContext.Current.Request.Url.Authority %><% =HttpContext.Current.Request.ApplicationPath %>/sarhu/seguridad/roles'
                });
            }, 2500);
        });
    </script>
</asp:Content>
