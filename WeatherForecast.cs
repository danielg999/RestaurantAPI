using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class WeatherForecast
    {
        private DateTime date;
        private int temperatureC;
        private string summary;

        public DateTime Date { 
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public int TemperatureC
        {
            get
            {
                return temperatureC;
            }
            set
            {
                temperatureC = value;
            }
        }
        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                summary = value;
            }
        }
        public WeatherForecast()
        {

        }
        public WeatherForecast(DateTime date, int temperatureC, string summary)
        {
            this.Date = date;
            this.TemperatureC = temperatureC;
            this.Summary = summary;
            Console.WriteLine($"Jestem w konstruktorze: {Date}, {TemperatureC}, {Summary}");
        }
    }
}
