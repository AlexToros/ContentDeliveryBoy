using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace ContentDeliveryBoy.Trello
{
    public class CardTrelloClient : IContentProducer
    {
        public object GetJSONContent()
        {
            using (WebClient wc = new WebClient())  
            {
                var response = wc.DownloadString(ConfigurationSettings.AppSettings["TrelloURL"]);
                return JsonConvert.DeserializeObject<Card[]>(response);
            }
        }
    }
}
