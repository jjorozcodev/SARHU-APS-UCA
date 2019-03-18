<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="agregar-localidad.aspx.cs" Inherits="SARHU.sarhu.catalogos.agregar_localidad" %>

<asp:Content ID="ContentAgregarLocalidad" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agregar Localidad</h1>
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
                                        <asp:Panel ID="panel" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">

                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                            <i class="fa-lg fa fa-exclamation-circle "></i>
                                            <%=Message %>
                                        </asp:Panel>



                                       
                                            <div class="col-md-12">

                                                <label>Programa</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <asp:DropDownList CssClass="form-control" ID="Programa" runat="server" InitialValue="Please select" ErrorMessage="Please select something"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                        ControlToValidate="Programa"
                                                        ErrorMessage="Selecciona un Programa"
                                                        InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                    </asp:RequiredFieldValidator>
                                                </div>

                                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <label>Departamento</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <asp:DropDownList CssClass="form-control" ID="Departamento" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Departamento_SelectedIndexChanged"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="Departamento"
                                                                ErrorMessage="Selecciona un Departamento"
                                                                InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                        <label>Municipio</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <asp:DropDownList CssClass="form-control" ID="Municipio" runat="server"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                ControlToValidate="Municipio"
                                                                ErrorMessage="Selecciona un Municipio"
                                                                InitialValue="0" SetFocusOnError="True" ForeColor="#FF3300">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                                <label>Director</label>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <div  class="form-group input-group" style="width: 100%;" >
                                                         <asp:TextBox ID="Director" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <a data-toggle="modal" data-target="#mediumModal" type="button" class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Lista de Directores"><i class="fa fa-search"></i></span></a>
                                                    </span>
                                                    </div>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="Director"
                                                    ErrorMessage="Director requerido"
                                                    SetFocusOnError="True" ForeColor="#FF3300">
                                                </asp:RequiredFieldValidator>
                                                </div>
                                              
                                                <div>
                                                    <label>Alias</label>
                                                </div>

                                                <div class="form-group input-group" style="width: 100%;">
                                                    <asp:TextBox ID="Alias" runat="server" CssClass="form-control"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="Alias"
                                                    ErrorMessage="Alias requerido"
                                                    SetFocusOnError="True" ForeColor="#FF3300">
                                                </asp:RequiredFieldValidator>
                                                </div>
                                               
                                                <div>
                                                    <label>Teléfono</label>
                                                </div>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <span class="input-group-addon">+505</span>
                                                    <asp:TextBox class="form-control" runat="server" ID="Telefono" ClientIDMode="Static" type="text" placeholder="" TabIndex="8"></asp:TextBox>
                                                   
                                                </div>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                        ControlToValidate="Telefono"
                                                        ErrorMessage="Telefono requerido"
                                                        SetFocusOnError="True" ForeColor="#FF3300">
                                                    </asp:RequiredFieldValidator>
                                                <div class="form-group" style="width: 100%;">
                                                    <label>Dirección</label>
                                                    <textarea style="resize: none" id="textarea" rows="5" cols="5" runat="server" clientidmode="Static" class="form-control" maxlength="200" name="textarea"></textarea>
                                                    <div id="textarea_feedback">200 caracteres disponibles</div>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="textarea"
                                                    ErrorMessage="Direccion requerido"
                                                    SetFocusOnError="True" ForeColor="#FF3300">
                                                </asp:RequiredFieldValidator>
                                                </div>
                                               
                                                <div class="form-group" align="center">
                                                    <asp:Button runat="server" ID="Guardar" CssClass="btn btn-success  fondo-verde-aldeas" align="center" Text="Guardar" OnClick="Guardar_Click"></asp:Button>
                                                    <a href="localidades.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
            var text_max = 200;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });

    </script>

    <script type="text/javascript">
        $(function () {
            $("#Telefono").mask("9999-9999", { placeholder: " " });
        });

        $(document).ready(function () {
            setTimeout(function () {
                $("#panel").fadeOut("slow") //#popupBox is the DIV to fade out
            }, 2000); //5000 equals 5 seconds
        });



    </script>



</asp:Content>
