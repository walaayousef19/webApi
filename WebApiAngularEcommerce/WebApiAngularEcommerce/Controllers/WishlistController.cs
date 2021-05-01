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
    public class WishlistController : ApiController
    {
        private DbContext db = new DbContext();

        // GET: api/Wishlist
        public IQueryable<Wishlist> GetWishList()
        {
            return db.WishList;
        }

        // GET: api/Wishlist/5
        [ResponseType(typeof(Wishlist))]
        public IHttpActionResult GetWishlist(int id)
        {
            Wishlist wishlist = db.WishList.Find(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return Ok(wishlist);
        }

        // PUT: api/Wishlist/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWishlist(int id, Wishlist wishlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wishlist.ID)
            {
                return BadRequest();
            }

            db.Entry(wishlist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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

        // POST: api/Wishlist
        [ResponseType(typeof(Wishlist))]
        public IHttpActionResult PostWishlist(Wishlist wishlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WishList.Add(wishlist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wishlist.ID }, wishlist);
        }

        // DELETE: api/Wishlist/5
        [ResponseType(typeof(Wishlist))]
        public IHttpActionResult DeleteWishlist(int id)
        {
            Wishlist wishlist = db.WishList.Find(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            db.WishList.Remove(wishlist);
            db.SaveChanges();

            return Ok(wishlist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WishlistExists(int id)
        {
            return db.WishList.Count(e => e.ID == id) > 0;
        }
    }
}