using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentDeliveryBoy
{
    public interface IContentProducer<T> where T : class
    {
        T GetJSONContent();
    }
    public interface IContentConsumer<T> where T : class
    {
        bool AddJSONContent(T content);
    }
}
