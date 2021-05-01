using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
  public  class Wishlist
    {
        public int ID { get; set; }
        [JsonIgnore]

        public virtual User User { get; set; }
        [JsonIgnore]

        public virtual List<ProductWishlist> Products { get; set; }
    }
}
