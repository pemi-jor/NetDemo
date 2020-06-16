using System;
using System.Collections.Generic;

namespace NetDemo.Models
{
    public partial class Temperature
    {
        public int Id { get; set; }
        public int HumidityValue { get; set; }
        public float TemperatureValue { get; set; }
        public DateTime TimeValue { get; set; }
        public string ThingyName { get; set; }
    }
}
