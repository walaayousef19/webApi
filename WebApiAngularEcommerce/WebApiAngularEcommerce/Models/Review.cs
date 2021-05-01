using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
    public class Review
    {
        public int ID { get; set; }
        [Required]
        [MinLength(14)]
        public string Description { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [JsonIgnore]

        public virtual User User { get; set; }
        [JsonIgnore]

        public virtual Product Product { get; set; }
    }
}
