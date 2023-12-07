using HavaDurumuUygulamasi;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

await GetWeatherForecast("https://goweather.herokuapp.com/weather/istanbul", "Istanbul");
await GetWeatherForecast("https://goweather.herokuapp.com/weather/izmir", "Izmir");
await GetWeatherForecast("https://goweather.herokuapp.com/weather/ankara", "Ankara");

async Task GetWeatherForecast(string apiUrl, string cityName)
{
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(jsonResponse);

            Console.WriteLine($"------ {cityName} Hava Durumu ------");
            Console.WriteLine("Tahmini Hava Durumu:");
            Console.WriteLine($"Sıcaklık: {weatherData.temperature}");
            Console.WriteLine($"Rüzgar: {weatherData.wind}");
            Console.WriteLine($"Açıklama: {weatherData.description}");

            
            Console.WriteLine("Sonraki 3 Günün Tahmini Hava Durumu:");

            foreach (var forecast in weatherData.forecast)
            {
                Console.WriteLine($"{forecast.day}: Sıcaklık: {forecast.temperature}, Durum: {forecast.description}");
            }

            
            if (weatherData.daily != null)
            {
                foreach (var dailyForecast in weatherData.daily)
                {
                    Console.WriteLine($"{dailyForecast.day}: Sıcaklık: {dailyForecast.temperature}, Durum: {dailyForecast.description}");
                }

            }


            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"Hava durumu bilgisi alınamıyor. Durum Kodu: {response.StatusCode}");
        }
    }
}

