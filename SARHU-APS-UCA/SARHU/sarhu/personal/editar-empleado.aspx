﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="editar-empleado.aspx.cs" Inherits="SARHU.sarhu.personal.editar_empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Empleado</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel-body">
                        <div class="col-md-6 col-md-offset-6">
                            <div class="panel panel-formulario">
                                <div class="panel-body">
                                        <div class="col-md-12" id="tabs">
                                            <asp:Panel ID="panelNotificacion" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <i class="fa-lg fa fa-exclamation-circle "></i>
                                                <% =Mensaje %>
                                            </asp:Panel>

                                            <asp:ScriptManager ID="ScriptManagerEmp" runat="server"></asp:ScriptManager>

                                            <div class="row">
                                                <%--<div class="col-md-4" style="padding:5px;">
                                        <img src="../../Content/Imagenes/profile.png" width="130" height="140"
                                            title="De Clic Para Cambiar">
                                    </div>--%>
                                                <div class="col-md-12" style="padding: 10px;">
                                                    <label>Nombres</label>
                                                    <asp:TextBox ID="EmpNombres" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                                    <label>Apellidos</label>
                                                    <div class="form-group input-group" style="width: 100%;">
                                                        <asp:TextBox ID="EmpApellidos" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <ul class="nav nav-tabs">
                                                <li class="active">
                                                    <a href="#datosP" data-toggle="tab">Datos Personales</a>
                                                </li>
                                                <li>
                                                    <a href="#datosA" data-toggle="tab">Datos Administrativos</a>
                                                </li>
                                            </ul>
                                            <div class="tab-content">

                                                <div class="tab-pane fade in active" id="datosP">
                                                    <div class="row">
                                                        <label style="padding: 7px;">Código</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <asp:TextBox ID="EmpCodigo" runat="server" CssClass="form-control" disabled="disabled"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <label style="padding: 7px;">Sexo</label>
                                                            <div class="radio">
                                                                <label>
                                                                    <input type="radio" id="rdM" runat="server" checked value="M">Masculino</label>
                                                            </div>
                                                            <div class="radio">
                                                                <label>
                                                                    <input type="radio" id="rdF" runat="server" value="F">Femenino</label>
                                                            </div>
                                                        </div>
                                                                <div class="col-md-6">
                                                                    <label style="padding: 7px;">Edad</label>
                                                                    <div class="form-group input-group" style="width: 100%;">
                                                                        <asp:TextBox ID="EmpEdad" runat="server" CssClass="form-control" disabled="disabled"></asp:TextBox>
                                                                    </div>
                                                                </div>
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
                                                        <asp:TextBox ID="EmpCedula" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="EmpFechaNac" runat="server" OnTextChanged="EmpFechaNac_TextChanged" AutoPostBack="true" CssClass="form-control" type="date" required="required"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                                        </table>
                                        <div>
                                            <label>Teléfono</label>
                                        </div>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <span class="input-group-addon">+505</span>
                                                            <asp:TextBox ID="EmpTelefono" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group" style="width: 100%;">
                                                            <label>Dirección</label>
                                                            <textarea style="resize: none" id="EmpDireccion" runat="server" rows="5" cols="5"
                                                                class="form-control" maxlength="200"
                                                                name="textarea"></textarea>
                                                            <div id="textarea_feedback">200 caracteres disponibles</div>
                                                        </div>

                                                                <label>Estado Civil</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:DropDownList CssClass="form-control" ID="ddlEstadosCiviles" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                                </div>
                                                                <label>Nivel Académico</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:DropDownList CssClass="form-control" ID="ddlNivelesAcademicos" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                                </div>
                                                    </div>


                                                    <div class="tab-pane fade " id="datosA">
                                                        <label style="padding: 7px;">Número de Asegurado</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <asp:TextBox ID="EmpSeguroSocial" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                                <label>Fecha de Ingreso</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:TextBox ID="EmpFechaIngreso" runat="server" AutoPostBack="true" type="date" CssClass="form-control" OnTextChanged="EmpFechaIngreso_TextChanged" required="required"></asp:TextBox>
                                                                </div>

                                                                <label>Localidad</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:DropDownList CssClass="form-control" ID="ddlLocalidades" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                                </div>
                                                                <label>Puesto</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:DropDownList CssClass="form-control" ID="ddlPuestos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Puestos_SelectedIndexChanged"></asp:DropDownList>
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
                                                                                <div class="form-group input-group"
                                                                                    style="width: 100%;">
                                                                                    <span class="input-group-addon">C$</span>
                                                                                    <input class="form-control" id="SalarioEmpleado" runat="server"
                                                                                        type="text" disabled="">
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <input id="rdBancoSi" runat="server" type="radio" name="state" value="yes"
                                                                                    style="margin-left: 50px;">Si
                                                        <input type="radio" name="state" value="no"
                                                            style="margin-left: 5px;">No
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>


                                                                <label>Número de Cuenta</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:TextBox ID="EmpCuentaBancaria" runat="server" type="number" CssClass="form-control" required="required"></asp:TextBox>
                                                                </div>
                                                                <div class="form-group" style="width: 100%;">
                                                                    <label>Observaciones</label>
                                                                    <textarea style="resize: none" id="EmpObservaciones" runat="server" rows="5" cols="5"
                                                                        class="form-control" maxlength="200"
                                                                        name="textarea"></textarea>
                                                                    <div id="textarea_feedback1">200 caracteres disponibles</div>
                                                                </div>
                                                                <label>Antigüedad</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input id="antiguedad" runat="server" type="text" class="form-control" disabled="">
                                                                </div>

                                                    </div>
                                                </div>
                                                <div class="form-group" align="center">
                                                    <asp:Button runat="server" ID="Guardar" CssClass="btn btn-success  fondo-verde-aldeas" align="center" Text="Guardar" OnClick="Editar_click"></asp:Button>
                                                    <a href="empleados.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
                                                </div>
                                                <!-- /.row (nested) -->
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

        <script>
            $(function () {
                $("#tabs").tabs();
            });
        </script>

        <script type="text/javascript">
            $(function () {
                $("#cedula").mask("999-999999-9999a", { placeholder: " " });
            });

            $(function () {
                $("#Telefono").mask("9999-9999", { placeholder: " " });
            });
        </script>

        <script>
            $(document).ready(function () {
                var text_max = 200;
                $('#textarea_feedback').html(text_max + ' caracteres disponibles');

                $('#textarea').keyup(function () {
                    var text_length = $('#textarea').val().length;
                    var text_remaining = text_max - text_length;

                    $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
                });
            });
        </script>

        <script>
            $(document).ready(function () {
                var text_max = 200;
                $('#textarea_feedback1').html(text_max + ' caracteres disponibles');

                $('#textarea1').keyup(function () {
                    var text_length = $('#textarea1').val().length;
                    var text_remaining = text_max - text_length;

                    $('#textarea_feedback1').html(text_remaining + ' caracteres disponibles');
                });
            });
        </script>
</asp:Content>
