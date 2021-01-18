using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Application.ViewModels
{
    public class WeatherDto
    {
        public coord coord { get; set; }
        public List<weatherItem> weather { get; set; }
        public string @base { get; set; }
        public main main { get; set; }
        public int visibility { get; set; }
        public wind wind { get; set; }
        public clouds clouds { get; set; }
        public int dt { get; set; }
        public sys sys { get; set; }
        public string timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    public class clouds
    {
        public int all { get; set; }
    }
    public class wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
    }

    public class main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }
    public class weatherItem
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class coord
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }
}
