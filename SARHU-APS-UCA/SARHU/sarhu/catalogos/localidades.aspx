<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="localidades.aspx.cs" Inherits="SARHU.sarhu.catalogos.localidades" %>

<asp:Content ID="ContentLocalidades" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Listado de Localidades</h1>
                <a href="agregar-localidad.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Localidad</a>
            </div>
            <!-- /.col-lg-12 -->
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
                                                <th>Programa</th>
                                                <th>Departamento</th>
                                                <th>Director</th>
                                                <th>Teléfono</th>
                                                <th width="200px">Operaciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="even gradeC" style='border: inset 0pt'>
                                        <td><%#Eval("Programa")%></td>
                                        <td><%#Eval("Departamento")%></td>
                                        <td><%#Eval("Director")%></td>
                                        <td><%#Eval("Telefono")%></td>
                                        <td align="center">
                                            <asp:LinkButton ID="Detalle" runat="server" CommandArgument='<%# Eval("Id")%>' CssClass="btn btn-default" OnClick="Detalle_Click" Style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Localidad"><i class="fa fa-eye fa-fw"></i></span></asp:LinkButton>
                                            <a href="editar-localidad.aspx?id=<%# Eval("Id")%>" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Localidad"><i class="fa fa-edit fa-fw"></i></span></a>
                                            <asp:LinkButton OnCommand="Borrar_Click" CommandArgument='<%#Eval("Id")%>' runat="server" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Localidad"><i class="fa fa-trash-o fa-fw"></i></span></asp:LinkButton>
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
                    <h2 class="modal-title" id="mediumModalLabel">Detalle de la Localidad</h2>

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
                                                            <label>Programa</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:DropDownList CssClass="form-control" ID="Programa" runat="server" InitialValue="Please select" Enabled="False"></asp:DropDownList>

                                                            </div>
                                                            <label>Departamento</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:DropDownList CssClass="form-control" ID="Departamento" runat="server" Enabled="False"></asp:DropDownList>

                                                            </div>
                                                            <label>Municipio</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:DropDownList CssClass="form-control" ID="Municipio" runat="server" Enabled="False"></asp:DropDownList>
                                                            </div>

                                                            <label>Director</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:TextBox ID="Director" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label>Alias</label>
                                                            </div>

                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:TextBox ID="Alias" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>

                                                            </div>

                                                            <div>
                                                                <label>Teléfono</label>
                                                            </div>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">+505</span>
                                                                <asp:TextBox runat="server" CssClass="form-control" ID="Telefono" Enabled="False"></asp:TextBox>

                                                            </div>

                                                            <div class="form-group" style="width: 100%;">
                                                                <label>Dirección</label>
                                                                <textarea style="resize: none" id="textarea" rows="5" cols="5" runat="server" class="form-control" disabled="disabled"></textarea>
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
                    <asp:LinkButton ID="Confirm" runat="server" OnClick="Confirmar_Click" CssClass="btn btn-danger fondo-rojo-aldeas" Text="Borrar"></asp:LinkButton>
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
                    <a href="localidades.aspx" type="button" class="btn btn-default">OK</a>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <asp:HiddenField runat="server" ID="idSeleccionado" />
    <script>
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
    <script>
        function ShowDetail() {
            $('#mediumModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        }
        $('.tooltip-demo').tooltip({
            selector: "[data-toggle=tooltip]",
            container: "body"
        })
    </script>
</asp:Content>
