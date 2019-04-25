using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentDeliveryBoy.AirTable
{
    public class Fields
    {
        [JsonProperty(PropertyName = "Card From Trello")]
        public string CardName { get; set; }
    }

    public class AirTableRecord
    {
        public Fields fields { get; set; }
    }
}
