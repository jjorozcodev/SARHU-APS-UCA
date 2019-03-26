<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="editar-adelanto.aspx.cs" Inherits="SARHU.sarhu.ingresos.editar_adelanto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">


            <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Adelanto</h1>
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
                           


                               <label>Empleado</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <select class="form-control" >                                                                         
                                    <option>Marlon Peraza</option>
                                    <option>-</option>                                    
                                </select>
                            </div>
 
                             <div>
                                <label>Monto</label>
                            </div>
                            <div class="form-group input-group" style="width: 100%;">
                                <span class="input-group-addon">C$</span>
                                <input class="form-control" id="Monto" value="2500.60" type="number" >
                            </div>


                              <label>Fecha de Entrega</label>
                            <div class="form-group input-group" style="width: 100%;">
                                  <input class="form-control" type="date" name="fechaEntrega" value="2019-03-27" step="1" min="1959-01-01" max="2090-01-01">   
                            </div>



                              <label>Fecha de Deduccion</label>
                            <div class="form-group input-group" style="width: 100%;">
                                  <input class="form-control" type="date" name="fechaDeduccion" value="2019-08-04" step="1" min="1959-01-01" max="2090-01-01">   
                            </div>
                            
                             


                            <div class="form-group" style="width: 100%;">
                                <label>Descripción</label>
                                <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea">Se ha realizado un adelanto al empleado correspondiente</textarea>
                                <div id="textarea_feedback">150 caracteres disponibles</div>
                            </div>





                            <div class="form-group" align="center">
                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Guardar</button>
                                <a href="adelantos.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
            var text_max = 200;
            $('#textarea_feedback').html(text_max + ' caracteres disponibles');

            $('#textarea').keyup(function () {
                var text_length = $('#textarea').val().length;
                var text_remaining = text_max - text_length;

                $('#textarea_feedback').html(text_remaining + ' caracteres disponibles');
            });
        });


        
    </script>










</asp:Content>
