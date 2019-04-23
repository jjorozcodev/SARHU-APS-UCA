<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="adelantos.aspx.cs" Inherits="SARHU.sarhu.ingresos.adelantos" %>
<asp:Content ID="ContentAdelantos" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Listado de Adelantos</h1>
                <a href="agregar-adelanto.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Adelanto</a>
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
                                            <th>Empleado</th>
                                            <th>Fecha Entrega</th>
                                            <th>Fecha Deduccion</th>
                                            <th>Descripcion</th>
                                            <th>Monto</th>
                                            <th width="200px">Operaciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td><%#Eval("Empleado")%></td>
                                    <td><%#Eval("FechaEntrega", "{0:d}")%></td>
                                    <td><%#Eval("FechaDeduccion", "{0:d}")%></td>
                                    <td><%#Eval("Descripcion")%></td>
                                    <td><%#Eval("Monto")%></td>
                                    <td align="center">
                                        <%--<asp:LinkButton ID="Detalle" runat="server" CommandArgument='<%# Eval("Id")%>' CssClass="btn btn-default" OnClick="VerDetalle_Click" Style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Adelanto"><i class="fa fa-eye fa-fw"></i></span></asp:LinkButton>--%>
                                        <a href="editar-adelanto.aspx?id=<%# Eval("Id")%>" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Adelanto"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <asp:LinkButton OnCommand="Borrar_Click" CommandArgument='<%#Eval("Id")%>' runat="server" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos LocaAdelantolidad"><i class="fa fa-trash-o fa-fw"></i></span></asp:LinkButton>
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
                    <h2 class="modal-title" id="mediumModalLabel">Detalle del Adelanto</h2>

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
                                                            <label>Empleado</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:DropDownList CssClass="form-control" ID="Empleado" runat="server" InitialValue="Please select" Enabled="False"></asp:DropDownList>
                                                            </div>

                                                            <div class="form-group" style="width: 100%">
                                                                <label>Fecha Entrega</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input type="date" id="idFechaEntrega" class="form-control" runat="server" name="FechaEntrega" step="1" format="yyyy-mm-dd" min="2019-01-01" max="2019-12-31">
                                                                </div>
                                                            </div>

                                                            <div class="form-group" style="width: 100%">
                                                                <label>Fecha Deduccion</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input type="date" id="idFechaDeduccion" class="form-control" runat="server" name="FechaDeduccion" step="1" format="yyyy-mm-dd" min="2019-01-01" max="2019-12-31">
                                                                </div>
                                                            </div>

                                                            <label>Fecha Deduccion</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:Calendar CssClass="form-control" ID="FechaDeduccion" runat="server" InitialValue="Please select" Enabled="False"></asp:Calendar>
                                                            </div>
                                                            <div class="form-group" style="width: 100%;">
                                                                <label>Descripcion</label>
                                                                <textarea style="resize: none" id="textarea" rows="5" cols="5" runat="server" class="form-control" disabled="disabled"></textarea>
                                                            </div>
                                                            <label>Monto</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:TextBox CssClass="form-control" ID="Monto" type="decimal" runat="server" InitialValue="Please select" Enabled="False"></asp:TextBox>
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
                    <a href="adelantos.aspx" type="button" class="btn btn-default">OK</a>

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