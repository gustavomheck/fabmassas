using LiveCharts;
using LiveCharts.Wpf;
using System;

namespace Unisc.Massas.Client.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel()
        {
            ViewName = "PAINEL DE CONTROLE";

            // Vendas
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "",
                    Values = new ChartValues<double> { 4, 6, 5, 2, 4, 8 }
                }
            };

            Labels = new[] 
            {
                DateTime.Now.AddMonths(-6).ToString("MMM"),
                DateTime.Now.AddMonths(-5).ToString("MMM"),
                DateTime.Now.AddMonths(-4).ToString("MMM"),
                DateTime.Now.AddMonths(-3).ToString("MMM"),
                DateTime.Now.AddMonths(-2).ToString("MMM"),
                DateTime.Now.AddMonths(-1).ToString("MMM"),
            };
            YFormatter = value => value.ToString("C");
        }

        // Vendas
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}
