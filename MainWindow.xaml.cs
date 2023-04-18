using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace Don_tKnowHowToNameThis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Calc calc = new Calc();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            step.Text = calc._step.ToString();
            W.Text = calc._W.ToString();
            H.Text = calc._H.ToString();
            L.Text = calc._L.ToString();
            p.Text = calc._p.ToString();
            c.Text = calc._c.ToString();
            T0.Text = calc._T0.ToString();
            Vu.Text = calc._Vu.ToString();
            Tu.Text = calc._Tu.ToString();
            mu0.Text = calc._mu0.ToString();
            Ea.Text = calc._Ea.ToString();
            Tr.Text = calc._Tr.ToString();
            n.Text = calc._n.ToString();
            alphaU.Text = calc._alphaU.ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
            calc = new Calc(Convert.ToDouble(W.Text), Convert.ToDouble(H.Text), Convert.ToDouble(L.Text), Convert.ToDouble(step.Text), Convert.ToDouble(p.Text), Convert.ToDouble(c.Text),
                    Convert.ToDouble(T0.Text), Convert.ToDouble(Vu.Text), Convert.ToDouble(Tu.Text), Convert.ToDouble(mu0.Text), Convert.ToDouble(Ea.Text), Convert.ToDouble(Tr.Text),
                    Convert.ToDouble(n.Text), Convert.ToDouble(alphaU.Text));          
            
            calc.MaterialShearStrainRate();
            calc.SpecificHeatFluxes();
            calc.VolumeFlowRateOfMaterialFlowInTheChannel();
            List<double> zCoord = new List<double>();
            List<double> temperature = new List<double>();
            List<double> viscosity = new List<double>();
            for (double z = 0; z <= calc._L; z = Math.Round(z + calc._step, 1))
            {
                zCoord.Add(z);
                double T = calc.Temperature(z);
                temperature.Add(T);
                double n = calc.Viscosity(T);
                viscosity.Add(n);
            }
            Table table = new Table(zCoord, temperature, viscosity);
            table.Show();
            eff.Content = calc.Efficiency().ToString();
            T.Content = Math.Round(temperature[temperature.Count - 1], 2).ToString();
            visc.Content = Math.Round(viscosity[viscosity.Count - 1], 2).ToString();

            Window winPlots = new Plots(zCoord, temperature, viscosity);
            // winPlots.draw();
            winPlots.Show();
        }

        private void CheckInputChange(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox a = (System.Windows.Controls.TextBox)e.Source;
            //a.Foreground = Brushes.Red;
            double temp;
            if (double.TryParse(a.Text, out temp))
            {
                a.Foreground = Brushes.Black;
                tableValueButton.IsEnabled = true;
            }
            else
            {
                a.Foreground = Brushes.Red;
                //tableValueButton.IsEnabled = false;
            }
        }
    }
}
