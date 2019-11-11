using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CarDealer.DTO
{
    public class CarsPartsDto
    {
        [JsonProperty("car")]
        public CarDto Car { get; set; }

        [JsonProperty("parts")]
        public PartDto[] Parts { get; set; }
    }
}
