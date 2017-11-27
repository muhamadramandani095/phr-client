using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace PhrClient.Wpf.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ClientContext _ctx;
        private WpfClientContext _wpfContext;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _ctx = new ClientContext();
            _wpfContext = new WpfClientContext();
            _ctx.OnRecieveDetailEcg += CtxOnOnRecieveDetailEcg;
            _ctx.OnRecieveMessage +=CtxOnOnRecieveMessage;
            _ctx.GetDetailEcg("d05a1a33-159b-47f7-9766-e6f5ca984b36", "9e7bcd3c-e252-4ff1-866d-a449590365b4");

        }

        private void CtxOnOnRecieveMessage(object sender, MessageArgs messageArgs)
        {
            var context = sender as ClientContext;
            if (messageArgs.Type == MessageType.PelayananEcgId)
            {
                context.HasReadMessage(messageArgs.Message);
            }
        }

        public static void Timeout(Dispatcher dispatcher, Action func, DispatcherPriority dispatcherPriority = DispatcherPriority.ContextIdle)
        {
            if (!dispatcher.CheckAccess())
            {
                dispatcher.BeginInvoke(dispatcherPriority, func);
            }
            else
                func.Invoke();

        }
        private void CtxOnOnRecieveDetailEcg(object sender, DetailEcgArgs detailEcgArgs)
        {
            Timeout(Dispatcher, () =>
            {
                var grid = 20;
                foreach (var bufferEcgViewModel in detailEcgArgs.Result.Data.Signals)
                {
                    var chart = new CoreChartFlat();
                    wrapPanel.Children.Add(chart);
                    chart.Height = 300;
                    chart.Width = ActualWidth - 200;
                    chart.Y = 8 * grid;
                    chart.X = 250 * grid;

                    chart.Points = new List<Point>();
                    chart.UseAnimation = true;
                    var data = JsonConvert.DeserializeObject<List<object>>(bufferEcgViewModel.Decode);
                    var decode = string.Join(",", data.Select(n => n.ToString()));
                    var item = decode.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var max = item.Skip(1).Max(n => Convert.ToInt16(n)) + 20;
                    var scale = chart.Y / max;
                    chart.BackgroundChartBrush = new SolidColorBrush(Color.FromArgb(63, 73, 112, 189));
                    var i = 0;
                    foreach (var s in item.Skip(1))
                    {
                        chart.Points.Add(new Point(i, scale * Convert.ToInt16(s)));
                        i++;
                    }
                    var a = chart.Points.FirstOrDefault();
                    var X = chart.Points.Max(n => n.X);
                    chart.Points.Add(new Point(X, 0));
                    chart.Points.Add(new Point(0, 0));
                    chart.Draw(chart.LastSize);
                }

            });

        }
    }
}
