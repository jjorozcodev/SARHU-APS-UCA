<%@ Page Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="SARHU.sarhu.inicio" %>

<asp:Content ID="ContentInicio" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="page-wrapper"> 
        <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Inicio</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>      
        <div class="row">
                <div class="col-lg-6 col-md-6">
                   <div class="panel panel-primary">
                        <div class="panel-heading pad-10">
                            Nuestra Misión
                        </div>
                        <div class="panel-body">
                            <p>Trabajamos por el derecho de los niños a vivir en familia.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6">
                   <div class="panel panel-primary">
                        <div class="panel-heading pad-10">
                            Nuestra Visión
                        </div>
                        <div class="panel-body">
                            <p>Cada niño y cada niña pertenecen a una familia y crece con amor.</p>
                        </div>
                    </div>
                </div>
            </div>
        <div class="row">
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading2">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-tasks fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">7</div>
                                    <div>Programas Activos</div>
                                </div>
                            </div>
                        </div>
                        <a data-toggle="modal" data-target="#mediumModal" type="button" >
                            <div class="panel-footer">
                                <span class="pull-left">Ver Detalles</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-green">
                        <div class="panel-heading2">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-users fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">450</div>
                                    <div>Empleados Activos</div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">Ver Detalles</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading2">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-map-marker fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">56</div>
                                    <div>Localidades</div>
                                </div>
                            </div>
                        </div>
                        <a data-toggle="modal" data-target="#localidadesModal" type="button">
                            <div class="panel-footer">
                                <span class="pull-left">Ver Detalles</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        <div class="row">
            <div class="col-lg-6">
             <div class="panel panel-default">
                <div class="panel-heading">
                        Pie Chart Example
                </div>

                <div class="panel-body">
                <div class="flot-chart">
                    <div class="flot-chart-content" id="flot-pie-chart" style="padding: 0px; position: relative;"><canvas class="base" width="472" height="400"></canvas><canvas class="overlay" width="472" height="400" style="position: absolute; left: 0px; top: 0px;"></canvas><div class="legend"><div style="position: absolute; width: 57px; height: 64px; top: 5px; right: 5px; background-color: rgb(255, 255, 255); opacity: 0.85;"> </div><table style="position:absolute;top:5px;right:5px;;font-size:smaller;color:#545454"><tbody><tr><td class="legendColorBox"><div style="border:1px solid #ccc;padding:1px"><div style="width:4px;height:0;border:5px solid rgb(237,194,64);overflow:hidden"></div></div></td><td class="legendLabel">Series 0</td></tr><tr><td class="legendColorBox"><div style="border:1px solid #ccc;padding:1px"><div style="width:4px;height:0;border:5px solid rgb(175,216,248);overflow:hidden"></div></div></td><td class="legendLabel">Series 1</td></tr><tr><td class="legendColorBox"><div style="border:1px solid #ccc;padding:1px"><div style="width:4px;height:0;border:5px solid rgb(203,75,75);overflow:hidden"></div></div></td><td class="legendLabel">Series 2</td></tr><tr><td class="legendColorBox"><div style="border:1px solid #ccc;padding:1px"><div style="width:4px;height:0;border:5px solid rgb(77,167,77);overflow:hidden"></div></div></td><td class="legendLabel">Series 3</td></tr></tbody></table></div></div>
                </div>
                </div>
            </div>  
            </div>





<div class="col-lg-6">
<div class="panel panel-default">
<div class="panel-heading">
Bar Chart Example
</div>

<div class="panel-body">
<div class="flot-chart">
<div class="flot-chart-content" id="flot-bar-chart" style="padding: 0px; position: relative;"><canvas class="base" width="472" height="400"></canvas><canvas class="overlay" width="472" height="400" style="position: absolute; left: 0px; top: 0px;"></canvas><div class="tickLabels" style="font-size:smaller"><div class="xAxis x1Axis" style="color:#545454"><div class="tickLabel" style="position:absolute;text-align:center;left:61px;top:384px;width:59px">12/5</div><div class="tickLabel" style="position:absolute;text-align:center;left:130px;top:384px;width:59px">12/7</div><div class="tickLabel" style="position:absolute;text-align:center;left:198px;top:384px;width:59px">12/9</div><div class="tickLabel" style="position:absolute;text-align:center;left:267px;top:384px;width:59px">12/11</div><div class="tickLabel" style="position:absolute;text-align:center;left:336px;top:384px;width:59px">12/13</div><div class="tickLabel" style="position:absolute;text-align:center;left:404px;top:384px;width:59px">12/15</div></div><div class="yAxis y1Axis" style="color:#545454"><div class="tickLabel" style="position:absolute;text-align:right;top:369px;right:446px;width:26px">0</div><div class="tickLabel" style="position:absolute;text-align:right;top:316px;right:446px;width:26px">1000</div><div class="tickLabel" style="position:absolute;text-align:right;top:262px;right:446px;width:26px">2000</div><div class="tickLabel" style="position:absolute;text-align:right;top:209px;right:446px;width:26px">3000</div><div class="tickLabel" style="position:absolute;text-align:right;top:156px;right:446px;width:26px">4000</div><div class="tickLabel" style="position:absolute;text-align:right;top:103px;right:446px;width:26px">5000</div><div class="tickLabel" style="position:absolute;text-align:right;top:49px;right:446px;width:26px">6000</div><div class="tickLabel" style="position:absolute;text-align:right;top:-4px;right:446px;width:26px">7000</div></div></div></div>
</div>
</div>

</div>

</div>



</div>
     </div>

         <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                     <button style="font-size:35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Lista de Programas</h2>     
                </div>
                <div class="modal-body">
                    <div id="page-wrapper1">
                        <div class="row">
                        <div class="col-md-12">
        <div class="panel panel-formulario">
                <div class="panel-body">
                   <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default2">
                    <div class="panel-body tooltip-demo">
                       <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>Nombre</th>
                                    <th>Descripción</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td>Programa de Fortalecimiento Familiar Somoto</td>
                                    <td>Trabajamos con las familias para garantizar protección y amor a niñas, niños y adolescentes y promovemos el derecho a la educación.</td>
                                </tr>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td>Centro de Formación Hermann Gmeiner Estelí</td>
                                    <td> Programa de educación para niños desde los 3 años de edad.</td>
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
     <div class="modal fade" id="localidadesModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                     <button style="font-size:35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="localidadesModalLabel">Lista de Programas</h2>     
                </div>
                <div class="modal-body">
                    <div id="page-wrapper2">
                        <div class="row">
                        <div class="col-md-12">
        <div class="panel panel-formulario">
                <div class="panel-body">
                   <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default2">
                    <div class="panel-body tooltip-demo">
                       <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>Programa</th>
                                    <th>Departamento</th>
                                    <th>Director</th>
                                    <th>Teléfono</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td>Fortalecimiento Familiar</td>
                                    <td>Somoto</td>
                                    <td>María Espinoza</td>
                                    <td>2224-5897</td>
                                </tr>
                                <tr class="even gradeC" style='border: inset 0pt'>
                                    <td>Centro de Formación Hermann Gmeiner</td>
                                    <td>Estelí</td>
                                    <td>Luis Morales</td>
                                    <td>8880-7543</td>
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
</asp:Content>
