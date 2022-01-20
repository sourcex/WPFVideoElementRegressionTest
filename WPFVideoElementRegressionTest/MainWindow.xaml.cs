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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFVideoElementRegressionTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mediaElement1.Source = new Uri("Content/production ID_5084526.mp4", UriKind.Relative);

            scrollingtextBox.Text = "Massa placerat duis ultricies lacus sed turpis tincidunt. Nulla malesuada pellentesque elit eget gravida cum sociis. Elit duis tristique sollicitudin nibh sit amet. Sit amet est placerat in egestas erat. Scelerisque mauris pellentesque pulvinar pellentesque habitant morbi. Pharetra diam sit amet nisl. At urna condimentum mattis pellentesque id nibh tortor. Bibendum enim facilisis gravida neque convallis a cras semper auctor. Laoreet non curabitur gravida arcu ac tortor dignissim convallis. Ultrices mi tempus imperdiet nulla malesuada. Morbi non arcu risus quis varius quam. Massa placerat duis ultricies lacus sed turpis tincidunt id. Ultricies tristique nulla aliquet enim tortor at. Maecenas pharetra convallis posuere morbi leo urna. Posuere lorem ipsum dolor sit amet consectetur adipiscing.";
            scrollingtextBox.Text = scrollingtextBox.Text + "Praesent tristique magna sit amet purus gravida. Sed arcu non odio euismod. Elementum nisi quis eleifend quam adipiscing vitae proin sagittis nisl. Quis ipsum suspendisse ultrices gravida dictum fusce ut. Nunc faucibus a pellentesque sit amet porttitor eget dolor. Vel quam elementum pulvinar etiam non quam lacus suspendisse faucibus. Maecenas sed enim ut sem viverra aliquet eget sit. Viverra nam libero justo laoreet sit amet cursus. Cursus risus at ultrices mi tempus. At urna condimentum mattis pellentesque id nibh.  Sed viverra ipsum nunc aliquet bibendum enim.Cursus metus aliquam eleifend mi in. Tincidunt vitae semper quis lectus nulla at volutpat diam.Elit eget gravida cum sociis.Felis eget nunc lobortis mattis aliquam faucibus.In pellentesque massa placerat duis ultricies lacus sed turpis tincidunt. Tortor pretium viverra suspendisse potenti.Purus faucibus ornare suspendisse sed nisi lacus sed viverra tellus. Eget magna fermentum iaculis eu non. Neque convallis a cras semper.Arcu non odio euismod lacinia at quis risus sed vulputate. Commodo odio aenean sed adipiscing diam donec.Lobortis feugiat vivamus at augue eget arcu dictum. Ut placerat orci nulla pellentesque.";
            var timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();
        }

        int line = 0;

        int currentVideo = 0;
        List<string> Playlist = new List<string>
        {
            "Content/production ID_5084531.mp4",
            "Content/production ID_5084526.mp4"
        };

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (line == scrollingtextBox.LineCount)
            {
                line = 0;
                scrollingtextBox.ScrollToHome();
            }

            scrollingtextBox.LineDown();
            line++;
        }

        private void mediaElement1_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (currentVideo == 1)
            {
                currentVideo = 0;
            }
            else
            {
                currentVideo = 1;
            }

            mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Source = new Uri(Playlist[currentVideo], UriKind.Relative);
            mediaElement1.Position = TimeSpan.Zero;
            mediaElement1.Play();
        }
    }
}
