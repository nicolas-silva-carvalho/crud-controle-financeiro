using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;

namespace CRUD.Funcoes
{
    public class GoogleChart
    {
        public static string GerarGraficoPizza(string titulo, string dados)
        {
            string grafico = @"<script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>
                             <script type = 'text/javascript'>
                                google.charts.load('current', {packages:['corechart']});
                                google.charts.setOnLoadCallback(drawChart);
                                    function drawChart()
                                    {
                                        var data = google.visualization.arrayToDataTable([
                                            ['', ''],
                                            " + dados + @"
                                    ]);

                                var options = {
                                    title: '" + titulo + @"',
                                    backgroundColor: 'transparent',
                                    is3D: true,
                                    titleTextStyle: {
                                        color: '#ffffff'
                                    }

                                };

                                var chart = new google.visualization.PieChart(document.getElementById('piechart_" + titulo.Replace(" ", "") + @"'));
                                chart.draw(data, options);
                                }
                                </script>
                               <div id = 'piechart_" + titulo.Replace(" ", "") + @"' style='width: 600px; height: 500px;'></div>";
            return grafico;
        }
    }
}
