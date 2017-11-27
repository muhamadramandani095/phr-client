using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace PhrClient.Wpf.Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            var token =
                "BP+Sn+NbLoLaK8uNkfax9B5TzDRNxvfCtdbB44duLcRF3IfymF1tCydVq3CSiyp50286VP0s3NFcR0zGc/Ev289skYSdS1g2h+9Th+7fGoKBS+RcpW0Bj+VOmr+48ROqAsjofD+CmRxJn8ZX8WLNoMQA9g1aWKx8H5jCz4tk2ezlILsr3I+E+uJU01Y/nP0B/NsKrgNgj9uAnLlBltU37E8H+xM5bxNG0fG/YPpmbVcWTK8Kc7aVcE6rFU/rbkYvzuHfOe2oQIgTOxLPlLwb0JfLdzB52UXg8qXcDGBpMm7J36ozizXmEHKTsqrAcEZCCgKzbgk4NdTpv0NXHqjoNx/HKUdp96zZZBUqIQ6w0OY1jKIjgA23xvWeywrqMtvKwiUFflcGgSY7Jyux0pzBILWAsUTCdKRVT8Rn2q132W9wLYRRRTdOM/VNLmysFWE2hhjOucAi7CFV3wAHibTwllOaHPYEvHo4+k3WSJS4n/4UVsN2fdUyy8rz3e61WhkAUMcn1dvhJtCdD485qqMwqifoTgpu2wi384FHgKJAcqraqkX3Vq4RnLj0whP/gDqZ4DlSRu05Cb5z7OCAYXYwiKpPu6H57UzCG1YeDO+GLHjFS6yiluOoyiK8f7F9ztzCufL+ZTtO8UpMkBPhkkACYiG0wsTbiaQZksq0pgBgztHpnc/n4mGnpjmF6FB15L58ws6khQejslBdH7J5mUHW6jeBOWawrG00JAGVvg2om/hVszet48s1WUrZASzSSU9oelhWpivCO0HSOuHNYLJ//SJOznC7s27GdYlZdTTZgXoHZTgMXZfYPn0ZpVULt9A+g0mzzacFCWdlPYC7OOczqaJMzgr1ExCVsptpYUAgZjVxVI7Afdc//ND88JY98T4jlFaNXgbRX6TH9GxtSymrhp+GsCi000kkXvp9ce0s3/frGzjl/MxluYhFoKgWUVwsYN3lkD8jbmNynvjDQmnryLQ0lSgVSXB8gtm0OmlYIGXOjZoX864/uc57fvk8BcaZ5dO6ShzLCD74/xGeYE+i+otkziHvvMsx0gzneF56BMAgiSN/mCIvWKcIN6IuzCrOE17xlKnk6lTNtGAOo0LEV9kkM1NFqWeMNYxzAvJW2ku1scLRnfbyZLLaXMPrNO71c+y35zDAjic48IaPKRs72e+dEBTM49k2LR4TwrV62XgVTq7GacSd3/PbHErA6p9V7hvadVEkZIpYRkekKlAZKUtgeYaIZALariletAMrY8UxQLbSwYZ0JFx9c7TgpBFo+5qizggsQqRuT/lQCFwJMQ==";

            ClientContext.AddConfiguration(new PatientConfigurationItem()
            {
                Token = token

            });
            ClientContext.Start();
        }
    }
}
