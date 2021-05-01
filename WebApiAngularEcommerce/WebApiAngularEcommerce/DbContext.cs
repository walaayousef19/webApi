using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace WebApiAngularEcommerce
{
  public  class DbContext:IdentityDbContext<User>
    {
        public DbContext():base("AngularWebApiEcommerce")
        {

        }

        public virtual DbSet<Product> product { get; set; }
        public virtual DbSet<Cart> cart { get; set; }
        public virtual DbSet<ProductCart> productCart { get; set; }
        public virtual DbSet<Order> order { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<Wishlist> WishList { get; set; }
        public virtual DbSet<ProductWishlist> ProductWishlist { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Category>category { get; set; }

      
        public virtual DbSet<Review>reviews{ get; set; }

       
    }
   
}
