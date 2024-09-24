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

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string apiKey = "ece62dd137a40eea7dfe566d540a36c1";#

        //https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}

        public MainWindow()
        {
            InitializeComponent();

        }
    }
}