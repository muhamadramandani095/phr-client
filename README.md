# phr-client

- [1.0](#1.0) <a name='1.0'></a> Konek ke Api Service

  ```cs
  
            var token ="TOKEN-FROM-SERVICE";

            ClientContext.AddConfiguration(new PatientConfigurationItem()
            {
                Token = token

            });
            ClientContext.Start();
  ```
  
- [1.1](#1.1) <a name='1.1'></a> Menerima Message Service

  ```cs
        private ClientContext _ctx;    
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _ctx = new ClientContext();            
            _ctx.OnRecieveDetailEcg += CtxOnOnRecieveDetailEcg;
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

  ```

- [1.2](#1.2) <a name='1.2'></a> Update Flag message

  ```cs
        private ClientContext _ctx;  
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _ctx = new ClientContext();            
            _ctx.OnRecieveMessage +=CtxOnOnRecieveMessage;            
        }

        private void CtxOnOnRecieveMessage(object sender, MessageArgs messageArgs)
        {
            var context = sender as ClientContext;
            if (messageArgs.Type == MessageType.PelayananEcgId)
            {
                context.HasReadMessage(messageArgs.Message);
            }
        }
  ```
  
- [1.3](#1.3) <a name='1.3'></a> Mennggunakan Default Page dan Messaging

  ```cs
      private WpfClientContext _wpfContext;
      private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {      
            _wpfContext = new WpfClientContext();         
        }
  ```  
