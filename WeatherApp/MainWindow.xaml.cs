using System.Net.Http;

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

using Newtonsoft.Json;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string apiKey = "ece62dd137a40eea7dfe566d540a36c1";

        private string requestUrl = "https://api.openweathermap.org/data/2.5/weather";

        public MainWindow()
        {
            InitializeComponent();

            WeatherMapResponse result = GetWeatherData("Doha");

            string finalImage = "sun.png";
            string currentWeather = result.weather[0].main.ToLower();

            if (currentWeather.Contains("cloud"))
            {
                finalImage = "cloud.png";
            } else if (currentWeather.Contains("rain"))
            {
                finalImage = "rain.png";
            } else if (currentWeather.Contains("snow"))
            {
                finalImage = "snow.png";
            } 

            // UriKind.Relative = looks for the path from the .exe file
            backgroundImage.ImageSource = new BitmapImage(new Uri("Images/" + finalImage, UriKind.Relative));

            // for °  => alt + 0176 => 22 °C
            labelTemperature.Content = result.main.temp.ToString("F1") + "°C";

            labelInfo.Content = result.weather[0].main;

            labelDescription.Content = result.weather[0].description;

        }

        public WeatherMapResponse GetWeatherData(string city)
        {
            HttpClient httpClient = new HttpClient();

            var finalUri = requestUrl + "?q=" + city + "&appid=" + apiKey + "&units=metric";

            HttpResponseMessage httpResponse = httpClient.GetAsync(finalUri).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;

            WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response);


            return weatherMapResponse;

        }
    }
}