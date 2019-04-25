using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentDeliveryBoy
{
    public abstract class Client<T> : IContentConsumer<T>, IContentProducer<T> 
        where T : class        
    {
        public abstract bool AddJSONContent(T content);

        public abstract T GetJSONContent();
    }
}
