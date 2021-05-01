using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiAngularEcommerce;

namespace WebApiAngularEcommerce.Controllers
{
    public class CartController : ApiController
    {
        private DbContext db = new DbContext();

        // GET: api/Cart
        public IQueryable<Cart> Getcart()
        {
            return db.cart;
        }

        // GET: api/Cart/5
     //   [Route("api/Cart/23")]
      
        public void postAddProductToCart(int id)
        {
            //get cart of current logged user
            var userID = User.Identity.GetUserId();
               
            var cartID = Getcart().Where(c => c.userId == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            var productCart = new ProductCart() {  cartId = cartID, productId = id };
           
         
               
            db.productCart.Add(productCart);
         
            //return RedirectToAction("Index");

        }
        [ResponseType(typeof(Cart))]

        public IHttpActionResult GetCart(int id)
        {
            Cart cart = db.cart.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // PUT: api/Cart/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.ID)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        ////// POST: api/Cart
        ////[ResponseType(typeof(Cart))]
        ////public IHttpActionResult PostCart(Cart cart)
        ////{
        ////    if (!ModelState.IsValid)
        ////    {
        ////        return BadRequest(ModelState);
        ////    }

        ////    db.cart.Add(cart);
        ////    db.SaveChanges();

        ////    return CreatedAtRoute("DefaultApi", new { id = cart.ID }, cart);
        ////}

        // DELETE: api/Cart/5
        [ResponseType(typeof(Cart))]
        public IHttpActionResult DeleteCart(int id)
        {
            Cart cart = db.cart.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.cart.Remove(cart);
            db.SaveChanges();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.cart.Count(e => e.ID == id) > 0;
        }
    }
}