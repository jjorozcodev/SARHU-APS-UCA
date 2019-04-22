<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="procesar-planilla.aspx.cs" Inherits="SARHU.sarhu.planilla.procesar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">


    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Procesar Planilla</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-formulario">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-md-12" id="tabs">
                                                    <div class="col-md-12" style="padding: 8px;">
                                                        <asp:Panel ID="panel" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                            <i class="fa-lg fa fa-exclamation-circle "></i>
                                                            <%=Message %>
                                                        </asp:Panel>

                                                        <asp:Panel ID="existence" ClientIDMode="static" CssClass="alert alert-danger alert-dismissable" runat="server" Visible="false">
                                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                            <i class="fa-lg fa fa-exclamation-circle "></i>
                                                            Ya existe un registro igual
                                                        </asp:Panel>

                                                        <table class="table">
                                                            <thead>
                                                                <tr>
                                                                    <th>Programa</th>
                                                                    <th>Localidad</th>
                                                                    <th>Director</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td class="col-md-4">
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <asp:DropDownList CssClass="form-control" ID="ddlProgramas" runat="server"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                                ControlToValidate="ddlProgramas"
                                                                                ErrorMessage="Selecciona un Programa"
                                                                                InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                                            </asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </td>
                                                                    <td class="col-md-4">
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlLocalidad" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                                ControlToValidate="ddlLocalidad"
                                                                                ErrorMessage="Selecciona una Localidad"
                                                                                InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                                            </asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </td>
                                                                    <td class="col-md-4">
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <asp:TextBox runat="server" ID="director" CssClass="form-control" type="text" Enabled="false" />
                                                                            <span class="input-group-btn">
                                                                                <a data-toggle="modal" data-target="#mediumModal" type="button" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Lista de Directores"><i class="fa fa-search"></i></span></a>
                                                                            </span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table class="table">
                                                            <thead>
                                                                <tr>
                                                                    <th>Inss Patronal</th>
                                                                    <th>Inss Laboral</th>
                                                                    <th>Inatec</th>
                                                                    <th>Techo Salarial</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td class="col-md-3">
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <asp:TextBox runat="server" ID="inssPatronal" CssClass="form-control" Enabled="false" />
                                                                            <span class="input-group-addon">%</span>
                                                                        </div>
                                                                    </td>
                                                                    <td class="col-md-3">
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <asp:TextBox runat="server" ID="inssLaboral" CssClass="form-control" Enabled="false" />
                                                                            <span class="input-group-addon">%</span>
                                                                        </div>
                                                                    </td>
                                                                    <td class="col-md-3">
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <asp:TextBox runat="server" ID="inatec" CssClass="form-control" Enabled="false" />
                                                                            <span class="input-group-addon">%</span>
                                                                        </div>
                                                                    </td>
                                                                    <td class="col-md-3">
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>
                                                                            <asp:TextBox runat="server" ID="techoSalarial" CssClass="form-control" Enabled="false" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <label>Observaciones</label>
                                                        <textarea style="resize: none" runat="server" clientidmode="static" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                        <div id="textarea_feedback">150 caracteres disponibles</div>
                                                    </div>
                                                </div>
                                                <ul class="nav nav-tabs">
                                                    <li class="active"><a href="#datosP" data-toggle="tab">Detalle de Empleados</a></li>
                                                </ul>
                                                <div class="tab-content">

                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing"
                                                                OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" CellPadding="10" EmptyDataText="No Hay Datos Disponibles">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Editar" CssClass="btn btn-success  fondo-verde-aldeas" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Actualizar" CssClass="btn btn-success  fondo-verde-aldeas" />

                                                                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancelar" CssClass="btn btn-danger fondo-rojo-aldeas" />
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Codigo_Empleado" HeaderText="Código del Empleado" InsertVisible="False" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Nombres_Empleado" HeaderText="Nombres del Empleado" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Apellidos_Empleado" HeaderText="Apellidos del Empleado" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Salario_base" HeaderText="Salario Base" ReadOnly="True" />
                                                                    <asp:TemplateField HeaderText="Horas Extra">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Text='<%#Eval("Horas_Extra") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="horas" Style="width: 100%" runat="server" Text='<%#Eval("Horas_Extra")%>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Pago_Inss_Laboral" HeaderText="Pago INSS Laboral" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Pago_Inss_Patronal" HeaderText="Pago INSS Patronal" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Pago_IR" HeaderText="Pago IR" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Monto_de_Ingreso" HeaderText="Monto de Bonos" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Monto_de_Deducciones" HeaderText="Monto de Deducciones" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Salario_Devengado" HeaderText="Salario Devengado" ReadOnly="True" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </div>

                                                <!-- /.row (nested) -->
                                            </div>
                                            <!-- /.panel-body -->
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="form-group" align="center">
                                    <asp:Button runat="server" ID="Guardar" type="button" class="btn btn-success  fondo-verde-aldeas" Text="Guardar" align="center" OnClick="Guardar_Click"></asp:Button>
                                    <a href="historial-planillas.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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

    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Lista de Directores</h2>
                </div>
                <div class="modal-body">
                    <div id="page-wrapper1">
                        <div class="row">
                            <div class="col-md-6 col-md-offset-6">
                                <div class="panel panel-formulario">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="panel panel-default2">
                                                    <div>
                                                        <h5 class="modalLittle" id="littleModalLabel">Seleccione</h5>
                                                    </div>
                                                    <div class="panel-body tooltip-demo">

                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="EmpleadosView" runat="server" ClientIDMode="Static" AutoGenerateColumns="False" DataKeyNames="Id" EmptyDataText="No hay datos disponibles." CssClass="table table-striped table-bordered table-hover"
                                                                    CellPadding="0" Width="100%" OnSelectedIndexChanged="EmpleadosView_SelectedIndexChanged" OnRowDataBound="EmpleadosView_RowDataBound">
                                                                    <Columns>
                                                                        <asp:CommandField ControlStyle-CssClass="btn btn-success  fondo-verde-aldeas" ShowSelectButton="True" />
                                                                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                                                                        <asp:BoundField DataField="Nombres" HeaderText="Nombre del Empleado" />
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

        $(document).ready(function () {
            setTimeout(function () {
                $("#panel").fadeOut("slow", function () {
                    window.location.replace("historial-planillas.aspx");
                });

            }, 250);
        });

        $(document).ready(function () {
            setTimeout(function () {
                $("#existence").fadeOut("slow");
            }, 300);
        });
    </script>
</asp:Content>
