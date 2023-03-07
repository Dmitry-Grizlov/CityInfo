using Newtonsoft.Json;

namespace CityInfo.Models
{
    public class WeatherModel
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        [JsonProperty("current_weather")]
        public CurrentWeatherModel CurrentWeather { get; set; }

        public DailyWeatherModel Daily { get; set; }

        public List<OneDayWeatherModel> OneDayWeather
        {
            get
            {
                var result = new List<OneDayWeatherModel>();
                OneDayWeatherModel current = null;
                for (int i = 0; i < Daily.Time.Count; i++)
                {
                    current = new()
                    {
                        Date = DateTime.Parse(Daily.Time[i]),
                        MaxTemp = Daily.Temperature2mMax[i],
                        MinTemp = Daily.Temperature2mMin[i],
                        WeatherState = Daily.Weathercode[i]
                    };

                    result.Add(current);
                }

                return result;
            }
        }

        public static string WeatherIcon(int num) => num switch
        {
            0 => "clear.svg",
            1 or 2 or 3 => "partlyCloudy.svg",
            45 or 48 => "fog.svg",
            51 or 53 or 55 or 56 or 57 or 61 or 63 or 65 or 66 or 67 or 80 or 81 or 82 => "rain.svg",
            71 or 3 or 75 or 77 or 80 or 81 or 82 or 85 or 86 => "snow.svg",
            _ => "storm.svg"
        };
    }

    public class CurrentWeatherModel
    {
        public decimal Temperature { get; set; }

        public decimal WindSpeed { get; set; }

        public decimal WindDirection { get; set; }

        public int WeatherCode { get; set; }

        public string Direction =>
           WindDirection > 11 && WindDirection < 34 ? "North-Notrh-East" :
           WindDirection > 34 && WindDirection < 56 ? "Notrh-East" :
           WindDirection > 56 && WindDirection < 79 ? "East-Notrh-East" :
           WindDirection > 79 && WindDirection < 101 ? "East" :
           WindDirection > 101 && WindDirection < 124 ? "East-South-East" :
           WindDirection > 124 && WindDirection < 146 ? "South-East" :
           WindDirection > 146 && WindDirection < 169 ? "South-South-East" :
           WindDirection > 169 && WindDirection < 192 ? "South" :
           WindDirection > 192 && WindDirection < 214 ? "South-South-West" :
           WindDirection > 214 && WindDirection < 237 ? "South-West" :
           WindDirection > 237 && WindDirection < 259 ? "West-South-West" :
           WindDirection > 259 && WindDirection < 282 ? "West" :
           WindDirection > 282 && WindDirection < 305 ? "West-North-West" :
           WindDirection > 305 && WindDirection < 327 ? "North-West" :
           WindDirection > 327 && WindDirection < 349 ? "North-North-West" :
           "North";
    }

    public class DailyWeatherModel
    {
        public List<string> Time { get; set; }

        [JsonProperty("temperature_2m_max")]
        public List<decimal> Temperature2mMax { get; set; }

        [JsonProperty("temperature_2m_min")]
        public List<decimal> Temperature2mMin { get; set; }

        public List<int> Weathercode { get; set; }
    }

    public class OneDayWeatherModel
    {
        public DateTime Date { get; set; }

        public decimal MaxTemp { get; set; }

        public decimal MinTemp { get; set; }

        public int WeatherState { get; set; }
    }
}