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
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-12" id="tabs">
                                            <div class="col-md-12" style="padding: 8px;">
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
                                                                    <asp:DropDownList runat="server"  CssClass="form-control" ID="ddlLocalidad" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                        ControlToValidate="ddlLocalidad"
                                                                        ErrorMessage="Selecciona una Localidad"
                                                                        InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-4">
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:TextBox runat="server" ID="director" CssClass="form-control" type="text" Enabled="false"/>
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
                                                                    <asp:TextBox runat="server" ID="inssPatronal" CssClass="form-control" type="number" Enabled="false" />
                                                                    <span class="input-group-addon">%</span>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-3">
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:TextBox runat="server" ID="inssLaboral" CssClass="form-control" type="number" Enabled="false" />
                                                                    <span class="input-group-addon">%</span>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-3">
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <asp:TextBox runat="server" ID="inatec" CssClass="form-control" type="number" Enabled="false" />
                                                                    <span class="input-group-addon">%</span>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-3">
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <span class="input-group-addon">C$</span>
                                                                    <asp:TextBox runat="server" ID="techoSalarial" CssClass="form-control" type="number" Enabled="false" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <label>Observaciones</label>
                                                <textarea style="resize: none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"></textarea>
                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                            </div>
                                        </div>
                                        <ul class="nav nav-tabs">
                                            <li class="active"><a href="#datosP" data-toggle="tab">Detalle de Empleados</a></li>
                                        </ul>
                                        <div class="tab-content">
                                             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                                            <asp:TextBox ID="horas" style="width:100%" runat="server" Text='<%#Eval("Horas_Extra")%>'></asp:TextBox>
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
                                <div class="form-group" align="center">
                                    <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Guardar</button>
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
                                                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                                                            <thead>
                                                                <tr>
                                                                    <th>ID</th>
                                                                    <th>Nombre</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr class="odd gradeX">
                                                                    <td>001</td>
                                                                    <td>María Espinoza</td>
                                                                </tr>
                                                                <tr class="even gradeC" style='border: inset 0pt'>
                                                                    <td>002</td>
                                                                    <td>Luis Morales</td>
                                                                </tr>
                                                                <tr class="even gradeD" style='border: inset 0pt'>
                                                                    <td>003</td>
                                                                    <td>Andrea Mendez</td>
                                                                </tr>
                                                                <tr class="even gradeE" style='border: inset 0pt'>
                                                                    <td>004</td>
                                                                    <td>Rodrigo Hernandez</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
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
    </script>
</asp:Content>
