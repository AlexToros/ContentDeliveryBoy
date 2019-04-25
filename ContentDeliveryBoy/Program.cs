using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentDeliveryBoy.Trello;
using ContentDeliveryBoy.AirTable;
using System.Timers;

namespace ContentDeliveryBoy
{
    class Program
    {
        static void Main(string[] args)
        {
            var Tclient = new CardTrelloClient();
            var Aclient = new AirTableClient();
            Timer timer = new Timer(4000);
            timer.Elapsed += (s, e) =>
            {
                Card[] cards = Tclient.GetJSONContent();

                foreach (AirTableRecord record in cards.Select(c => c.ConvertToAirTableRecord()))
                {
                    Aclient.AddJSONContent(record);
                }
            };
            timer.Start();
            Console.WriteLine("Бот интеграции стартовал");
            Console.WriteLine("Нажмите любую клавишу для завершения");
            Console.ReadKey();
        }
    }
}
