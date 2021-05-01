﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularEcommerce
{
  public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]

        public virtual List<Product> Products { get; set; }
    }
}
