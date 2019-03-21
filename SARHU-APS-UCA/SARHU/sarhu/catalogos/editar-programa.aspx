<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="editar-programa.aspx.cs" Inherits="SARHU.sarhu.catalogos.editar_programa" %>
<asp:Content ID="ContentEditarPrograma" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Programa</h1>
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

                             <asp:HiddenField runat="server" ID="idPrograma" />


                                    <label>Nombre</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <asp:TextBox ID="Nombre" type="text" runat="server" CssClass="form-control"></asp:TextBox>
                                
                            </div>

                   <asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre"
                   ErrorMessage="El campo Nombre es Requerido" Display="None">                     
                   </asp:RequiredFieldValidator>


                            <div class="form-group" style="width: 100%;">
                                <label>Descripción</label>
                                <textarea style="resize: none" id="textarea" rows="5" cols="5" runat="server" clientidmode="Static" class="form-control" maxlength="150" name="textarea"></textarea>
                                <div id="textarea_feedback">150 caracteres disponibles</div>
                            </div>

                            <div class="form-group" align="center">

                                <asp:Button runat="server" type="button" class="btn btn-success  fondo-verde-aldeas" ID ="btnGuardar" Text="Editar" OnClick="btnEditar_programa"></asp:Button>

                              
                                <a href="programas.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
