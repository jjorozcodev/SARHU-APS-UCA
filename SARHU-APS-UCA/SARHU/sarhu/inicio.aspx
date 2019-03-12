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
                        <a href="catalogos/programas.aspx">
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
                        <a href="catalogos/localidades.aspx">
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
            
    
</asp:Content>
