using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavaDurumuUygulamasi;

public class WeatherData
    {
        public string temperature { get; set; }
        public string wind { get; set; }
        public string description { get; set; }
        public Forecast[] forecast { get; set; }
        public DailyForecast[] daily { get; set; }
    }
