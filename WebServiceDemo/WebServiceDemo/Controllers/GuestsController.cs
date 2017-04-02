﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServiceDemo;

namespace WebServiceDemo.Controllers
{
    public class GuestsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Guests
        public IQueryable<Guest> GetGuest()
        {
            return db.Guest;
        }

        // GET: api/Guests/5
        [ResponseType(typeof(Guest))]
        public IHttpActionResult GetGuest(int id)
        {
            Guest guest = db.Guest.Find(id);
            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        // PUT: api/Guests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuest(int id, Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guest.Guest_No)
            {
                return BadRequest();
            }

            db.Entry(guest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
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

        // POST: api/Guests
        [ResponseType(typeof(Guest))]
        public IHttpActionResult PostGuest(Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guest.Add(guest);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GuestExists(guest.Guest_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guest.Guest_No }, guest);
        }

        // DELETE: api/Guests/5
        [ResponseType(typeof(Guest))]
        public IHttpActionResult DeleteGuest(int id)
        {
            Guest guest = db.Guest.Find(id);
            if (guest == null)
            {
                return NotFound();
            }

            db.Guest.Remove(guest);
            db.SaveChanges();

            return Ok(guest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestExists(int id)
        {
            return db.Guest.Count(e => e.Guest_No == id) > 0;
        }
    }
}