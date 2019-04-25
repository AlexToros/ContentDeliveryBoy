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
    public class AirTableClient : Client<AirTableRecord>
    {
        public string AirTableKey = ConfigurationSettings.AppSettings["AirTableKey"];
        public string AirTableURL = ConfigurationSettings.AppSettings["AirTableURL"];
        public string AirTable_TableName = ConfigurationSettings.AppSettings["AirTable_TableName"];
        public string URL;
        public AirTableClient()
        {
            URL = AirTableURL + AirTable_TableName;
        }
        public override bool AddJSONContent(AirTableRecord content)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Authorization", $"Bearer {AirTableKey}");
                wc.Headers.Add("Content-Type", "application/json");

                string json = JsonConvert.SerializeObject(content);

                var response = wc.UploadString(URL, json);
                return true;
            }
        }

        public override AirTableRecord GetJSONContent()
        {
            throw new NotImplementedException();
        }
    }
}
