using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
    public class ProductOrder
    {
        public int ID { get; set; }
        [JsonIgnore]

        public virtual Order Order { get; set; }
        [JsonIgnore]

        public virtual Product Product { get; set; }
    }
}
