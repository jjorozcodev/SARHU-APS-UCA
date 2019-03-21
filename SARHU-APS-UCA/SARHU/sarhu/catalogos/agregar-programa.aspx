<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="agregar-programa.aspx.cs" Inherits="SARHU.sarhu.catalogos.agregar_programa" %>
<asp:Content ID="ContentAgregarPrograma" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agregar Programa</h1>
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


                            <label>Nombre</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <asp:TextBox ID="nombreprog" type="text" runat="server" CssClass="form-control"></asp:TextBox>
                                
                            </div>

                   <asp:RequiredFieldValidator runat="server" ControlToValidate="nombreprog"
                   ErrorMessage="El campo Nombre es Requerido" Display="None">                     
                   </asp:RequiredFieldValidator>


                            <div class="form-group" style="width: 100%;">
                                <label>Descripción</label>                                                               

                                   <asp:TextBox ID="descripcionprog" runat="server" Wrap = "true" type="text" TextMode="multiline" style="resize:none" rows="5" cols="5"  CssClass="form-control" maxlength="150" name="descripcionprog"></asp:TextBox>
                               
                                <div id="descripcionprog_feedback">150 caracteres disponibles</div>
                            </div>



                            <div class="form-group" align="center">

                                  <asp:Button runat="server" type="button" class="btn btn-success  fondo-verde-aldeas" ID ="btnGuardar" Text="Guardar" OnClick="btnGuardar_programa"></asp:Button>
                                            
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
