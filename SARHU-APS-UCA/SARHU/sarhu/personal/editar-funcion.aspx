<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="editar-funcion.aspx.cs" Inherits="SARHU.sarhu.personal.editar_funcion" %>
<asp:Content ID="ContentEditarFuncion" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Área</h1>
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
                                            <asp:Panel ID="panel" ClientIDMode="static" CssClass="alert alert-success alert-dismissable" runat="server" Visible="false">
                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                <i class="fa-lg fa fa-exclamation-circle "></i>
                                                <%=Message %>
                                            </asp:Panel>


                                            <asp:HiddenField runat="server" ID="idFuncion" />
                                            <label>Nombre</label>
                                            <div class="form-group input-group" style="width: 100%;">

                                                <asp:TextBox ID="Nombre" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 100%;">
                                                <label>Descripción</label>
                                                <textarea style="resize: none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea"><%=Value %></textarea>
                                                <div id="textarea_feedback">150 caracteres disponibles</div>
                                            </div>

                                            <div class="form-group" align="center">
                                                <asp:Button ID="Editar" Text="Editar" runat="server" CssClass="btn btn-success  fondo-verde-aldeas" align="center" OnClick="Editar_click"></asp:Button>
                                                <a href="funciones.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
        function DeletePopup() {
            $('#delete').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

    </script>


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
                    window.location.replace("funciones.aspx");
                });
                //#popupBox is the DIV to fade out
            }, 2000); //5000 equals 5 seconds
        });



    </script>
</asp:Content>
