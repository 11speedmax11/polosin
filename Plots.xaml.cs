using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Don_tKnowHowToNameThis
{
    /// <summary>
    /// Логика взаимодействия для Plots.xaml
    /// </summary>
    public partial class Plots : Window
    {
        public Plots(List<double> zCoord, List<double> temperature, List<double> viscosity)
        {
            InitializeComponent();
            drawPlot(zCoord, temperature, viscosity);
        }

        public void drawPlot(List<double> zCoord, List<double> temperature, List<double> viscosity)
        {
            //this.leftPlot = new ScottPlot.Plot(400, 300);
            var zArray = zCoord.Select(item => Convert.ToDouble(item)).ToArray();
            var temperatureArray = temperature.Select(item => Convert.ToDouble(item)).ToArray();
            var viscosityArray = viscosity.Select(item => Convert.ToDouble(item)).ToArray();

            var myScatter = this.leftPlot.Plot.AddScatter(zArray, temperatureArray);
            leftPlot.Plot.Title("График распределения температуры материала по длине канала", size: 12);
            leftPlot.Plot.XLabel("Координата по длине канала, м");
            leftPlot.Plot.YLabel("Температура, °C");
            this.leftPlot.Refresh();

            this.rightPlot.Plot.AddScatter(zArray, viscosityArray);
            rightPlot.Plot.Title("График распределения вязкости материала по длине канала", size: 12);
            rightPlot.Plot.YLabel("Вязкость, Па * c");
            rightPlot.Plot.XLabel("Координата по длине канала, м");
            this.rightPlot.Refresh();
        }
    }
}
