using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentDeliveryBoy.AirTable;
using ContentDeliveryBoy.Trello;

namespace ContentDeliveryBoy
{
    static class ConvertExtensions
    {
        public static AirTableRecord ConvertToAirTableRecord(this Card card)
        {
            return new AirTableRecord()
            {
                fields = new Fields()
                {
                    CardName = card.name
                }
            };
        }
    }
}
