<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="editar-puesto.aspx.cs" Inherits="SARHU.sarhu.personal.editar_puesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Puesto</h1>
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
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:Panel ID="panel" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <i class="fa-lg fa fa-exclamation-circle "></i>
                                                <%=Message %>
                                            </asp:Panel>

                                            <label>Nombre</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:TextBox ID="NombrePuesto" runat="server" CssClass="form-control" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="NombrePuesto"
                                                    ErrorMessage="Campo requerido"
                                                    SetFocusOnError="True" ForeColor="#FF3300">
                                                </asp:RequiredFieldValidator>

                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Descripción</label>
                                                <textarea style="resize: none" id="textarea" runat="server" clientidmode="Static" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                            </div>

                                            <label>Salario Base</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <span class="input-group-addon">C$</span>
                                                <asp:TextBox ID="Salario" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                            </div>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="Salario"
                                                ErrorMessage="Campo requerido"
                                                SetFocusOnError="True" ForeColor="#FF3300">
                                            </asp:RequiredFieldValidator>

                                            <div class="alert alert-danger alert-dismissable" id="errmsg" hidden="hidden"></div>
                                            <div></div>
                                            <label>Cuenta</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCuentas">
                                                    <asp:ListItem Value="0">Seleccione..</asp:ListItem>
                                                    <asp:ListItem Value="1">proveedores SOS </asp:ListItem>
                                                    <asp:ListItem Value="2">Ingresos Diversos </asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="ddlCuentas"
                                                    ErrorMessage="Selecciona una cuenta"
                                                    InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                </asp:RequiredFieldValidator>
                                            </div>

                                            <label>Área</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                <asp:DropDownList runat="server" ID="ddlarea" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="ddlarea"
                                                    ErrorMessage="Selecciona un Área"
                                                    InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                </asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group input-group">
                                                <label>Funciones Asociadas a Este Puesto</label>
                                                <span class="input-group-btn">
                                                    <a data-toggle="modal" data-target="#mediumModal" type="button" style="border-bottom-left-radius: 4px; border-top-left-radius: 4px" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Lista de Función"><i class="fa fa-plus-circle"></i></span></a>
                                                </span>
                                            </div>

                                            <asp:Panel ID="errorTable" ClientIDMode="static" CssClass="alert alert-danger alert-dismissable" runat="server" Visible="false">

                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <i class="fa-lg fa fa-exclamation-circle "></i>
                                                <%=Message %>
                                            </asp:Panel>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:Repeater runat="server" ID="rptFuncion">
                                                        <HeaderTemplate>
                                                            <table width="100%" class="table table-striped table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="tableHeader">Funcion</th>
                                                                        <th class="tableHeader">Eliminar</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr class="odd gradeX">
                                                                <td class="tableData"><%# Eval("Nombre")%></td>

                                                                <td align="center">
                                                                    <asp:LinkButton type="button" ID="ElminarFuncion" runat="server" CommandArgument='<%# Container.ItemIndex + ";" + Eval("Id") + ";" + Eval("Nombre")%>' OnClick="ElminarFuncion_Click" CssClass="btn btn-danger fondo-rojo-aldeast"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Rol"><i class="fa fa-minus-circle fa-fw"></i></span></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>




                                            <div class="form-group" align="center">
                                                <asp:Button ID="Guardar" runat="server" type="button" CssClass="btn btn-success  fondo-verde-aldeas" align="center" Text="Guardar" OnClick="Guardar_Click"></asp:Button>
                                                <a href="puestos.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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


    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Lista de Funciones</h2>
                </div>
                <div class="modal-body">
                    <div id="page-wrapper1">
                        <div class="row">
                            <div class="col-md-8 col-md-offset-2">
                                <div class="panel panel-formulario">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="panel panel-default2">
                                                    <div>
                                                        <h5 class="modalLittle" id="littleModalLabel">Seleccione Funciones</h5>
                                                    </div>
                                                    <div class="panel-body tooltip-demo">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="FuncionesView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" EmptyDataText="No data available." CssClass="table table-striped table-bordered table-hover" CellPadding="0" Width="100%" OnSelectedIndexChanged="FuncionesView_SelectedIndexChanged">
                                                                    <Columns>
                                                                        <asp:CommandField ControlStyle-CssClass="btn btn-success  fondo-verde-aldeas" ShowSelectButton="True" />
                                                                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                                                                        <asp:BoundField DataField="Nombre" HeaderText="Funcion" />
                                                                    </Columns>
                                                                </asp:GridView>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

                                                        <!-- /.table-responsive -->
                                                    </div>
                                                    <!-- /.panel-body -->
                                                </div>
                                                <!-- /.panel -->
                                            </div>
                                            <!-- /.col-lg-12 -->
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

    <script>
        $(document).ready(function () {
            var text_max = 150;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });

        $('#Salario').keypress(function (eve) {
            if ((eve.which != 46 || $(this).val().indexOf('.') != -1) && (eve.which < 48 || eve.which > 57) || (eve.which == 46 && $(this).caret().start == 0)) {
                eve.preventDefault();
                $("#errmsg").html("Solo Digitos").show().fadeOut(800);
            }

            // this part is when left part of number is deleted and leaves a . in the leftmost position. For example, 33.25, then 33 is deleted
            $('#Salario').keyup(function (eve) {
                if ($(this).val().indexOf('.') == 0) {
                    $(this).val($(this).val().substring(1));
                }
            });
        });
        $(document).ready(function () {
            setTimeout(function () {
                $("#panel").fadeOut("slow", function () {
                    window.location.replace("puestos.aspx");
                });
                //#popupBox is the DIV to fade out
            }, 250); //5000 equals 5 seconds
        });
        $(document).ready(function () {
            $('#dataTables-funcion').DataTable({
                responsive: true
            });
        });

    </script>

</asp:Content>
