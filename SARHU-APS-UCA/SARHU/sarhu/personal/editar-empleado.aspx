<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="editar-empleado.aspx.cs" Inherits="SARHU.sarhu.personal.editar_empleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper"> 
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Empleado</h1>
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
                                           <ul class="nav nav-tabs">
                                                <li class="active"><a href="#datosP" data-toggle="tab">Datos Personales</a></li>
                                                <li ><a href="#datosA" data-toggle="tab">Datos Administrativos</a></li>
                                           </ul>
                                           <div class="tab-content">
                                                <div class="tab-pane fade in active" id="datosP">
                                                    <label>Código</label>
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
                                                                     <input type="radio" name="gender" value="Female" style="margin-left: 5px;" checked="">Femenino
                                                                </td>
                                                                <td><input class="form-control" style="margin-left: 83px;width: 45px;" type="text" placeholder="" id="edad" value="48" disabled=""></td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>
                                                        <label>Nombres</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control" value="Maria Juana">
                                                            </div>
                                                        <label>Apellidos</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control" value="Maldonado Palacios">
                                                            </div>
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
                                                                     <input class="form-control" type="text"  id="cedula" placeholder="000-000000-0000T" tabindex="14" value="001-171180-0005B">
                                                                </td>
                                                                <td>
                                                                     <input class="form-control" type="text"  id="fechaN" placeholder="00/00/0000" tabindex="8" value="24/02/1971">
                                                                </td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>                                         
                                                        <div>
                                                            <label>Teléfono</label>
                                                        </div>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <span class="input-group-addon">+505</span>
                                                            <input class="form-control" type="text"  id="Telefono" placeholder="8888-8888" tabindex="8" value="8256-7651">
                                                        </div>
                                                    <div class="form-group" style="width: 100%;">
                                                        <label>Dirección</label>
                                                        <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="200" name="textarea">B° Juana Elena Mendoza, costado Este Escuela Maria Llanes</textarea>
                                                        <div id="textarea_feedback">200 caracteres disponibles</div>
                                                    </div>  
                                                    <label>Estado Civil</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <select class="form-control" >
                                                                <option selected>Soltero/a</option>
                                                                <option>Acompañado/a</option>
                                                                <option>Casado/a</option>
                                                                <option>Viudo/a</option>
                                                            </select>
                                                        </div>
                                                    <label>Nivel Académico</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <select class="form-control" >
                                                                <option>Primaria</option>
                                                                <option>Secundaria</option>
                                                                <option selected>Técnico</option>
                                                                <option>Universitario</option>
                                                            </select>
                                                        </div>
                                                     <div class="form-group" align="center">
                                                        <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Editar</button>
                                                        <a href="empleados.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
                                                    </div>
                                            </div> 
                                                <div class="tab-pane fade " id="datosA">                                   
                                                     <label>Inss</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input class="form-control" type="text"  id="inss" placeholder="0000000-0" tabindex="8" value="5132706-0">
                                                            </div>
                                                     <label>Fecha de Ingreso</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input class="form-control" type="text"  id="fechaI" placeholder="00/00/0000" tabindex="8" value="07/04/2018">
                                                            </div>
                                                    <label>Programa</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <select class="form-control" >
                                                                <option selected>Centro de Formación Hermann Gmeiner Estelí</option>
                                                                <option>Programa de Fortalecimiento Familiar Somoto</option>
                                                                <option>Colegio SOS Hermann Gmeiner Estelí</option>
                                                                <option>Recaudación de Fondos FDC</option>
                                                            </select>
                                                        </div>
                                                    <label>Puesto</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <select class="form-control" >
                                                                <option selected>Bibliotecario/a</option>
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
                                                                        <input class="form-control" id="Monto" type="text" value="10,000">
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group input-group" style="width: 100%;">
                                                                        <select class="form-control" >
                                                                            <option>Si</option>
                                                                            <option selected>No</option>
                                                                        </select>
                                                                    </div>    
                                                                </td>
                                                            </tr>                                              
                                                        </tbody>
                                                    </table>
                                                    <div class="form-group" style="width: 100%;">
                                                        <label>Observaciones</label>
                                                        <textarea style="resize:none" id="textarea1" rows="5" cols="5" class="form-control" maxlength="200" name="textarea">Su nuevo salario a partir del primero de Octubre del 2019 es de C$8,900</textarea>
                                                        <div id="textarea_feedback1">200 caracteres disponibles</div>
                                                    </div>  
                                                        <label>Antigüedad</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control" disabled="" value="0 Años con 11 Meses y 16 Días">
                                                            </div>
                                                        <label>Fecha de Egreso/Cambio</label>
                                                                <div class="form-group input-group" style="width: 100%;">
                                                                    <input class="form-control" type="text"  id="fechaE" placeholder="00/00/0000" tabindex="8" value="13/08/2019">
                                                                </div>
                                                        <div class="form-group" style="width: 100%;">
                                                            <label>Observaciones de Egreso</label>
                                                            <textarea style="resize:none" id="textarea2" rows="5" cols="5" class="form-control" maxlength="200" name="textarea">Asuntos personales</textarea>
                                                            <div id="textarea_feedback2">200 caracteres disponibles</div>
                                                        </div> 
                                                    <div class="form-group" align="center">
                                                        <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Editar</button>
                                                        <a href="empleados.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
                $("#fechaN").mask("99/99/9999", { placeholder: " " });
            });

            $(function () {
                $("#fechaI").mask("99/99/9999", { placeholder: " " });
            });

            $(function () {
                $("#fechaE").mask("99/99/9999", { placeholder: " " });
            });

            $(function () {
                $("#Telefono").mask("9999-9999", { placeholder: " " });
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

    <script>
            $(document).ready(function () {
                var text_max = 200;
                $('#textarea_feedback2').html(text_max + ' caracteres disponibles');

                $('#textarea2').keyup(function () {
                    var text_length = $('#textarea2').val().length;
                    var text_remaining = text_max - text_length;

                    $('#textarea_feedback2').html(text_remaining + ' caracteres disponibles');
                });
            });
        </script>
</asp:Content>
