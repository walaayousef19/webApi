using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
   public class Order
    {
        public int ID { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [JsonIgnore]

        public virtual List<ProductOrder> Products { get; set; } = new List<ProductOrder>();
        //public virtual User user { get; set; }

    }
}
