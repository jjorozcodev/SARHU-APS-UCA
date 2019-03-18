<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="impuestos.aspx.cs" Inherits="SARHU.sarhu.parametros.impuestos" %>
<asp:Content ID="ContentImpuestos" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
   
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <div id="page-wrapper"> 
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Parametrización de Impuestos</h1>
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
                                                <li class="active"><a href="#inss" data-toggle="tab">INSS</a></li>
                                                <li ><a href="#ir" data-toggle="tab">IR</a></li>
                                                <li><a href="#inatec" data-toggle="tab">INATEC</a></li>
                                           </ul>
                                       <div class="tab-content">
                                            <div class="tab-pane fade in active" id="inss">
                                                <div>
                                                    <label>Laboral</label>
                                                </div>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input class="form-control" id="porcentajeL" type="number" value="6.25" >
                                                    <span class="input-group-addon">%</span>
                                                </div>
                                                <div>
                                                    <label>Patronal</label>
                                                </div>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input class="form-control" id="porcentajeP" type="number" value="19" >
                                                    <span class="input-group-addon">%</span>
                                                </div>
                                                <div>
                                                    <label>Techo Salarial</label>
                                                </div>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <span class="input-group-addon">C$</span>
                                                    <input class="form-control" id="techoSalaralInss" type="text" value="88,005.78" >
                                                </div>
                                                 <div class="form-group" align="center">
                                                    <span id="btnActualizarInss" class="btn btn-success  fondo-verde-aldeas" align="center">Actualizar</span>
                                                </div>
                                        </div> 
                                            <div class="tab-pane fade " id="ir">                                   
                                                <table class="table">
                                                    <thead>
                                                      <tr>
                                                        <th>Desde</th>
                                                        <th>Hasta</th>
                                                        <th>Base</th>
                                                        <th>Exceso</th>
                                                        <th>Porcentaje</th>
                                                      </tr>
                                                    </thead>
                                                    <tbody>
                                                      <tr>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="1.0">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="75,000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="0.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="0">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                                <input type="number" class="form-control" value="0">
                                                        </td>
                                                      </tr>
                                                      <tr>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" onkeypress="return validatenumerics1(event);" value="50,001.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="100,000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="0.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="75,000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                                <input type="number" class="form-control" value="10">
                                                        </td>
                                                      </tr>
                                                      <tr>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="100.001.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="200.000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="2.500.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="100.000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                                <input type="number" class="form-control" value="15">
                                                        </td>
                                                      </tr>
                                                      <tr>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="200.000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="300.000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="17.500.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="200.000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                                <input type="number" class="form-control" value="20">
                                                        </td>
                                                      </tr>
                                                      <tr>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="300.001.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="500.000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="37.500.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>
                                                                <input type="text" class="form-control" value="30.,000.00">
                                                            </div>
                                                        </td>
                                                        <td> 
                                                                <input type="number" class="form-control" value="25">
                                                        </td>
                                                      </tr>
                                                    </tbody>
                                                  </table>
                                                 <div class="form-group" align="center">
                                                    <span id="btnActualizarIr" class="btn btn-success  fondo-verde-aldeas" align="center">Actualizar</span>
                                                </div>
                                        </div>   
                                            <div class="tab-pane fade " id="inatec">
                                                <div>
                                                    <label>Porcentaje</label>
                                                </div>
                                                <div class="form-group input-group" style="width: 100%;">
                                                    <input class="form-control" id="porcentajeIna" type="number" value="6.25" >
                                                </div>

                                                 <div class="form-group" align="center">
                                                    <span id="btnActualizarInatec" class="btn btn-success  fondo-verde-aldeas" align="center">Actualizar</span>
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

<script>      
        function validatenumerics1(key) {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            //comparing pressed keycodes
            if (keycode > 31 && (keycode < 48 || keycode > 57)) {
                if ((keycode > 31 && keycode <= 43) || (keycode > 43 && keycode <= 45) || keycode > 57 || keycode == 47) {
                    if ((keycode > 31 && keycode <= 43) || (keycode > 45 && keycode <= 47) || keycode > 57 || keycode == 45) {
                        snackbarNumber();
                        return false;
                    }
                }
            }
            else return true;
        }
    </script>
       
</asp:Content>
