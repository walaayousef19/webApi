using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
   public class Cart
    {
        public int ID { get; set; }
        [JsonIgnore]
        public virtual List<ProductCart> Products { get; set; } = new List<ProductCart>();
        [ForeignKey("user")]
        public string userId { get; set; }
        public virtual User user { get; set; }

    }
}
