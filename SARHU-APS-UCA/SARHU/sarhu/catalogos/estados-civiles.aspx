<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="estados-civiles.aspx.cs" Inherits="SARHU.sarhu.catalogos.estado_civil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Listado de Estados Civiles</h1>
                <a href="agregar-estadoc.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Estado Civil</a>
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
                                            <th>Nombre</th>
                                            <th width="200px">Operaciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td><%#Eval("Nombre")%></td>
                                    <td align="center">
                                        <a href="editar-estadoc.aspx?id=<%# Eval("Id")%>" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Estado Civil"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <asp:LinkButton OnCommand="Borrar_Click" CommandArgument='<%#Eval("Id")%>' runat="server" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Estado Civil"><i class="fa fa-trash-o fa-fw"></i></span></asp:LinkButton>
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
                    <a href="estados-civiles.aspx" type="button" class="btn btn-default">OK</a>
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
</asp:Content>
