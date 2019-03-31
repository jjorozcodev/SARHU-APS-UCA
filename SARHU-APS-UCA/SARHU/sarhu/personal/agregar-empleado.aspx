<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="agregar-empleado.aspx.cs" Inherits="SARHU.sarhu.personal.agregar_empleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <link href="css/bootstrap.min.css" rel="stylesheet">
    <div id="page-wrapper"> 
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agregar Empleado</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
         <div class="row">
            <div class="col-lg-12">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6 col-md-offset-6">
                            <div class="panel panel-formulario">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-12" id="tabs">
                                             <div class="col-md-4" style="padding:5px;">
                                                   <img src="/Content/Imagenes/profile.png" width="130" height="140" title="De Clic Para Cambiar">
                                             </div>
                                            <div class="col-md-8" style="padding:5px;">
                                                <label>Nombres</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control">
                                                            </div>
                                                <label>Apellidos</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control">
                                                            </div>
                                                </div>
                                           <ul class="nav nav-tabs">
                                                <li class="active"><a href="#datosP" data-toggle="tab">Datos Personales</a></li>
                                                <li ><a href="#datosA" data-toggle="tab">Datos Administrativos</a></li>
                                           </ul>
                                           <div class="tab-content">
                                                <div class="tab-pane fade in active" id="datosP">
                                                     <label style="padding:7px;">Código</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="number" class="form-control" value="230319" disabled="">
                                                            </div>
                                                   <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th>Sexo</th>
                                                                <th>Edad</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                     <input type="radio" name="gender" value="male" style="margin-left: 50px;">Masculino
                                                                     <input type="radio" name="gender" value="Female" style="margin-left: 5px;">Femenino
                                                                </td>
                                                                <td><input class="form-control" style="margin-left: 83px;width: 45px;" type="text" id="edad" disabled=""></td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>
                                                        
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th>Cédula</th>
                                                                <th>Fecha de Nacimiento</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                     <input class="form-control" type="text"  id="cedula" placeholder="000-000000-0000T" tabindex="14">
                                                                </td>
                                                                <td>
                                                                     <input class="form-control" type="date" name="nacimiento" step="1" min="1959-01-01" max="2001-01-01">
                                                                </td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>                                         
                                                        <div>
                                                            <label>Teléfono</label>
                                                        </div>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <span class="input-group-addon">+505</span>
                                                            <input class="form-control" type="text"  id="Telefono" placeholder="8888-8888" tabindex="8">
                                                        </div>
                                                    <div class="form-group" style="width: 100%;">
                                                        <label>Dirección</label>
                                                        <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="200" name="textarea"></textarea>
                                                        <div id="textarea_feedback">200 caracteres disponibles</div>
                                                    </div>  
                                                    <label>Estado Civil</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <select class="form-control" >
                                                                <option >Seleccione..</option>
                                                                <option>Soltero/a</option>
                                                                <option>Acompañado/a</option>
                                                                <option>Casado/a</option>
                                                                <option>Viudo/a</option>
                                                            </select>
                                                        </div>
                                                    <label>Nivel Académico</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <select class="form-control" >
                                                                <option >Seleccione..</option>
                                                                <option>Primaria</option>
                                                                <option>Secundaria</option>
                                                                <option>Técnico</option>
                                                                <option>Universitario</option>
                                                            </select>
                                                        </div>
                                                     <div class="form-group" align="center">
                                                        <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Guardar</button>
                                                        <a href="empleados.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
                                                    </div>
                                            </div> 
                                                <div class="tab-pane fade " id="datosA">                                   
                                                     <label style="padding:7px;">Número de Asegurado</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input class="form-control" type="text"  id="inss" placeholder="0000000-0" tabindex="8">
                                                            </div>
                                                     <label>Fecha de Ingreso</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input class="form-control" type="date" name="ingreso" step="1" min="1949-01-01" max="2019-01-01">
                                                            </div>
                                                    <label>Programa</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <select class="form-control" >
                                                                <option >Seleccione..</option>
                                                                <option>Centro de Formación Hermann Gmeiner Estelí</option>
                                                                <option>Programa de Fortalecimiento Familiar Somoto</option>
                                                                <option>Colegio SOS Hermann Gmeiner Estelí</option>
                                                                <option>Recaudación de Fondos FDC</option>
                                                            </select>
                                                        </div>
                                                    <label>Puesto</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <select class="form-control" >
                                                                <option >Seleccione..</option>
                                                                <option>Bibliotecario/a</option>
                                                                <option>Madre.SOS</option>
                                                                <option>Conductor</option>
                                                                <option>Resp.Cocina</option>
                                                            </select>
                                                        </div>                                    
                                                   <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th>Salario</th>
                                                                <th>Banco</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                     <div class="form-group input-group" style="width: 100%;">
                                                                        <span class="input-group-addon">C$</span>
                                                                        <input class="form-control" id="Monto" type="text" disabled="">
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <input type="radio" name="state" value="yes" style="margin-left: 50px;">Si
                                                                    <input type="radio" name="state" value="no" style="margin-left: 5px;">No
                                                                </td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>
                                                    <label>Número de Cuenta</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control" id="numeroC" placeholder="00000000000000" tabindex="14">
                                                            </div>
                                                    <div class="form-group" style="width: 100%;">
                                                        <label>Observaciones</label>
                                                        <textarea style="resize:none" id="textarea1" rows="5" cols="5" class="form-control" maxlength="200" name="textarea"></textarea>
                                                        <div id="textarea_feedback1">200 caracteres disponibles</div>
                                                    </div>  
                                                        <label>Antigüedad</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control" disabled="">
                                                            </div>
                                                     <div class="form-group" align="center">
                                                        <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Guardar</button>
                                                        <a href="empleados.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
                                                    </div>
                                            </div> 
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
    

        <script>
        $(function () {
            $("#tabs").tabs();
        });
        </script>

        <script type="text/javascript">
            $(function () {
                $("#cedula").mask("999-999999-9999a", { placeholder: " " });
            });

            $(function () {
                $("#inss").mask("9999999-9", { placeholder: " " });
            });

            $(function () {
                $("#Telefono").mask("9999-9999", { placeholder: " " });
            });

            $(function () {
                $("#numeroC").mask("99999999999999", { placeholder: " " });
            });
        </script>

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

    <script>
            $(document).ready(function () {
                var text_max = 200;
                $('#textarea_feedback1').html(text_max + ' caracteres disponibles');

                $('#textarea1').keyup(function () {
                    var text_length = $('#textarea1').val().length;
                    var text_remaining = text_max - text_length;

                    $('#textarea_feedback1').html(text_remaining + ' caracteres disponibles');
                });
            });
        </script>

</asp:Content>
