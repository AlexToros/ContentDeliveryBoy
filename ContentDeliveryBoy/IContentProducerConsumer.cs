using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentDeliveryBoy
{
    public interface IContentProducer
    {
        object GetJSONContent();
    }
    public interface IContentConsumer
    {
        bool AddJSONContent(object content);
    }
}
