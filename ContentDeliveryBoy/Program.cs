using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentDeliveryBoy.Trello;
using ContentDeliveryBoy.AirTable;

namespace ContentDeliveryBoy
{
    class Program
    {
        static void Main(string[] args)
        {
            IContentProducer Tclient = new CardTrelloClient();
            IContentConsumer Aclient = new AirTableClient();

            Card[] cards = (Card[])Tclient.GetJSONContent();

            foreach (AirTableRecord record in cards.Select(c => c.ConvertToAirTableRecord()))
            {
                Aclient.AddJSONContent(record);
            }
        }
    }
}
