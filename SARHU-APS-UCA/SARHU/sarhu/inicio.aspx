<%@ Page Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="SARHU.sarhu.inicio" %>

<asp:Content ID="ContentInicio" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.3/Chart.min.js"></script>

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
                        <p> <% = org.Mision %> </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading pad-10">
                        Nuestra Visión
                    </div>
                    <div class="panel-body">
                        <p> <% = org.Vision %> </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <hr />
            <!-- /.col-lg-12 -->
            <div class="col-lg-4 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading2">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-tasks fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge"> <% = cantProgAct %> </div>
                                <div>Programas Activos</div>
                            </div>
                        </div>
                    </div>
                    <a data-toggle="modal" data-target="#mediumModal" type="button">
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
                                <div class="huge"><% = cantEmpl %></div>
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
                                <div class="huge"><% = cantLocAct %></div>
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
            <hr />

            <div class="col-lg-6">
                <div class="panel panel-primary">
                    <div class="panel-heading pad-10">
                        Género de Colaboradores
                    </div>

                    <div class="panel-body">
                        <canvas id="chartPie"></canvas>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="panel panel-primary">
                    <div class="panel-heading pad-10">
                        Ingresos/Egresos del Mes
                    </div>

                    <div class="panel-body">
                        <canvas id="chartBar"></canvas>
                    </div>

                </div>

            </div>

        </div>
    </div>

    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
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
                                                                    <td>Programa de educación para niños desde los 3 años de edad.</td>
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
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
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

    <script>
        new Chart(document.getElementById("chartPie"),
            {
                "type": "pie",
                "data":
                {
                    "labels":
                    ["Hombres", "Mujeres"],
                    "datasets":
                    [{
                        "data": [<% = cantEmplM %>, <% = cantEmplF %>],
                        "backgroundColor":
                        [   "rgba(92, 184, 92,0.75)",
                            "rgba(240, 173, 78,0.75)"]
                    }]
                }
            });
    </script>
    <script>
        new Chart(document.getElementById("chartBar"),
            {
                "type": "bar",
                "data":
                {
                    "labels":
                    ["Ingresos", "Egresos", "Ademduns"], //Etiquetas
                    "datasets":
                    [{
                        "label": 'Movimientos',
                        "data": [75, 35, 53],
                        "fill": false,
                        "backgroundColor": [
                            "rgba(0, 158, 224, 0.5)",
                            "rgba(231, 67, 97, 0.5)",
                            "rgba(240, 173, 78, 0.5)"],
                        "borderColor": [
                            "rgb(0, 158, 224)",
                            "rgb(231, 67, 97)",
                            "rgb(240, 173, 78)"],
                        "borderWidth": 1
                    }]
                }, "options": {"scales": { "yAxes": [{ "ticks": { "beginAtZero": true } }] } }
            });
    </script>

    
</asp:Content>
