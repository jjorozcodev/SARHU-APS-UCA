<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="puestos.aspx.cs" Inherits="SARHU.sarhu.personal.puestos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Listado de Puestos</h1>
                <a href="agregar-puesto.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Puesto</a>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default2">
                    <div class="panel-body tooltip-demo">
                     
                        <asp:Repeater runat="server" ID="rptFunciones">
                            <HeaderTemplate>
                                <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>

                                            <th>Nombre</th>
                                            <th>Descripción</th>
                                            <th>Salario Base</th>
                                            <th width="200px">Operaciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="odd gradeX">
                                    <td><%#Eval("Nombre")%></td>
                                    <td><%#Eval("Descripcion")%></td>
                                    <td><%#Eval("SalarioBase")%> </td>
                                    <td align="center">
                                        <asp:LinkButton runat="server" ID="Detalle" CssClass="btn btn-default" Style="margin-right: 10px;" CommandArgument='<%# Eval("Id") %>' OnClick="Detalle_Click"><span data-toggle="tooltip" data-placement="top" title="Ver Detalle Puesto"><i class="fa fa-eye fa-fw"></i></span></asp:LinkButton>
                                        <a href="editar-puesto.aspx?id=<%# Eval("Id")%>" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Puesto"><i class="fa fa-edit fa-fw"></i></span></a>
                                        <asp:LinkButton runat="server" ID="Eliminar" class="btn btn-default" CommandArgument='<%# Eval("Id") +";"+ Eval("Nombre")%>' OnClick="Eliminar_Click"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Puesto"><i class="fa fa-trash-o fa-fw"></i></span></asp:LinkButton>
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
                    <h2 class="modal-title" id="mediumModalLabel">Detalle del Puesto</h2>

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
                                                            <label>Nombre</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:TextBox runat="server" disabled="disabled" ID="NombrePuesto" CssClass="form-control" />

                                                            </div>
                                                            <div class="form-group" style="width: 100%;">
                                                                <label>Descripción</label>
                                                                <textarea disabled="disabled" runat="server"  style="resize: none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                                            </div>

                                                            <label>Salario Base</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>

                                                                <asp:TextBox runat="server" disabled="disabled" ID="Salario" CssClass="form-control" />
                                                            </div>
                                                            <label>Cuenta</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:DropDownList runat="server" Enabled="false" CssClass="form-control" ID="ddlCuentas">                                                                   
                                                                </asp:DropDownList>
                                                            </div>

                                                            <label>Área</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <asp:DropDownList runat="server" Enabled="false" ID="ddlarea" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="form-group input-group">
                                                                <label>Funciones Asociadas a Este Puesto</label>
                                                                <span class="input-group-btn"></span>
                                                            </div>
                                                            <asp:Repeater runat="server" ID="rptFuncion">
                                                                <HeaderTemplate>
                                                                    <table width="100%" class="table table-striped table-bordered table-hover">
                                                                        <thead>
                                                                            <tr>
                                                                                <th class="tableHeader">Funcion</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr class="odd gradeX">
                                                                        <td class="tableData"><%# Eval("Nombre")%></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    </tbody>
                                                              </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>


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
                    ¿Está seguro que desea borrar <%=Nombre%>?
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="Confirm" runat="server" OnClick="Confirm_Click" Text="Borrar" class="btn btn-danger fondo-rojo-aldeas"></asp:LinkButton>
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
                    <%=Message %>
                </div>
                <div class="modal-footer">
                    <a href="puestos.aspx" type="button" class="btn btn-default">Cerrar</a>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <script>


        function ShowDetail() {
            $('#mediumModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

        function ShowPopup() {
            $('#myModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

        function DeletePopup() {
            $('#delete').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

       

        $(document).ready(function () {
            $('#dataTables-example').DataTable({
                responsive: true
            });
        });

    </script>



</asp:Content>
