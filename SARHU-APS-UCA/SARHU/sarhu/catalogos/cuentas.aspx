﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="cuentas.aspx.cs" Inherits="SARHU.sarhu.catalogos.cuentas" %>

<asp:Content ID="ContentCuentas" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Listado de Cuentas</h1>
                <a href="agregar-cuenta.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Cuenta</a>
            </div>
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default2">
                    <div class="panel-body tooltip-demo">
                        <asp:Panel ID="panelNotificacion" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                            <i class="fa-lg fa fa-exclamation-circle "></i>
                            <% =Mensaje %>
                        </asp:Panel>
                        <asp:Repeater runat="server" ID="rptTable">
                            <HeaderTemplate>
                                <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-datos">
                                    <thead>
                                        <tr>
                                            <th>Código Contable</th>
                                            <th>Descripción</th>
                                            <th width="200px">Operaciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td><%#Eval("CodigoContable")%></td>
                                    <td><%#Eval("Descripcion")%></td>
                                    <td align="center">
                                        <asp:LinkButton runat="server" ID="Detalle" CssClass="btn btn-default" Style="margin-right: 10px;" CommandArgument='<%# Eval("Id") %>' OnClick="Detalle_Click"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Cuenta"><i class="fa fa-eye fa-fw"></i></span></asp:LinkButton>
                                        <a href="editar-cuenta.aspx?id=<%# Eval("Id")%>" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Cuenta"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <asp:LinkButton OnCommand="Borrar_Click" CommandArgument='<%#Eval("Id")%>' runat="server" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Cuenta"><i class="fa fa-trash-o fa-fw"></i></span></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                        </table>
                            </FooterTemplate>
                        </asp:Repeater>
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
                    <h2 class="modal-title" id="mediumModalLabel">Detalle de Cuenta</h2>

                </div>
                <div class="modal-body">

                    <div id="page-wrapper1">
                        <div class="row">
                            <div class="col-md-6 col-md-offset-6">
                                <div class="panel panel-formulario">
                                    <div class="panel-body">
                                        <div class="row">
                                            <asp:Panel ID="panel1" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <i class="fa-lg fa fa-exclamation-circle "></i>
                                                <% =Mensaje %>
                                            </asp:Panel>
                                            <label>Código Contable</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox disabled="" ID="codigoContable" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <label>Cuenta Salario</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox disabled="" ID="cuentaSalario" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <label>Cuenta Impuesto</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox disabled="" ID="cuentaImpuesto" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <label>Cuenta Seguro</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox disabled="" ID="cuentaSeguro" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <div  class="form-group input-group" style="width: 100%;">
                                                <label>Cuenta Planilla</label>
                                                <asp:CheckBox Enabled="false" ID="cuentaPlanilla" runat="server" CssClass="form-control" required="required" />                                                 
                                            </div>
                                                <label>Descripción</label>
                                                <textarea disabled="" style="resize: none" id="cuentaDescripcion" runat="server" rows="5" cols="5" class="form-control" maxlength="25" name="textarea"></textarea>                                     
                                            <!-- /.col-lg-6 (nested) -->
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
                    <button style="font-size: 30px" type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">¡Atención!</h4>
                </div>
                <div class="modal-body">
                    <%=Mensaje %>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" OnClick="Confirmar_Click" Text="Borrar" class="btn btn-danger fondo-rojo-aldeas"></asp:LinkButton>
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
                    <%=Mensaje %>
                </div>
                <div class="modal-footer">
                    <a href="cuentas.aspx" type="button" class="btn btn-default">OK</a>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <asp:HiddenField runat="server" ID="idSeleccionado" />
    <script>

        function ShowDetail() {
            $('#mediumModal').modal({ backdrop: 'static', keyboard: false }, 'show');
            
        }
        function PopupConfirmacion() {
            $('#myModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

        function PopupNotificacion() {
            $('#delete').modal({ backdrop: 'static', keyboard: false }, 'show');
        }
        
        $('#closemodal').click(function () {
            $('#mymodal').modal('hide');

        });

        $(document).ready(function () {
            $('#dataTables-datos').DataTable({
                responsive: true
            });
        });
    </script>

</asp:Content>
