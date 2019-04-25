using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContentDeliveryBoy.AirTable
{
    public class AirTableClient : IContentConsumer
    {
        public string AirTableKey = ConfigurationSettings.AppSettings["AirTableKey"];
        public string AirTableURL = ConfigurationSettings.AppSettings["AirTableURL"];
        public string AirTable_TableName = ConfigurationSettings.AppSettings["AirTable_TableName"];
        public string URL;
        public AirTableClient()
        {
            URL = AirTableURL + AirTable_TableName;
        }
        public bool AddJSONContent(object content)
        {
            AirTableRecord record = content as AirTableRecord;
            if (record == null)
                throw new AggregateException("Передан неверный объект");

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Authorization", $"Bearer {AirTableKey}");
                wc.Headers.Add("Content-Type", "application/json");
                
                string json = JsonConvert.SerializeObject(record);

                var response = wc.UploadString(URL, json);
                return true;
            }
        }
    }
}
