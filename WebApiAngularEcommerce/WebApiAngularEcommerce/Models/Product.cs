using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
    public class Product
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public int ID { get; set; }
        [Required]
        [MinLength(13)]
        public string Description { get; set; }
        [Range(5, int.MaxValue)]
        [Required]
        public double Discount { get; set; }
        [Required]
        [Range(5, int.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
        public string Color { get; set; }
        [Required]
        public int Quantity { get; set; }
        [ForeignKey("category")]
        public Nullable<int> CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category category { get; set; }
        [JsonIgnore]

        public virtual List<Review> Reviews { get; set; }
        [JsonIgnore]

        public virtual List<ProductCart> Carts { get; set; }
        [JsonIgnore]

        public virtual List<ProductOrder> Orders { get; set; }
        [JsonIgnore]

        public virtual List<ProductWishlist> WhishLists{get;set;}

    }
}