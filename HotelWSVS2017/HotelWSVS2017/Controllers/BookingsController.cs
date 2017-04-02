﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HotelWSVS2017;

namespace HotelWSVS2017.Controllers
{
    public class BookingsController : ApiController
    {
        private HotelContextvs2017 db = new HotelContextvs2017();

        // GET: api/Bookings
        public IQueryable<Booking> GetBooking()
        {
            return db.Booking;
        }

        // GET: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public async Task<IHttpActionResult> GetBooking(int id)
        {
            Booking booking = await db.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/Bookings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBooking(int id, Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.Booking_id)
            {
                return BadRequest();
            }

            db.Entry(booking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        [ResponseType(typeof(Booking))]
        public async Task<IHttpActionResult> PostBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Booking.Add(booking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = booking.Booking_id }, booking);
        }

        // DELETE: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public async Task<IHttpActionResult> DeleteBooking(int id)
        {
            Booking booking = await db.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.Booking.Remove(booking);
            await db.SaveChangesAsync();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(int id)
        {
            return db.Booking.Count(e => e.Booking_id == id) > 0;
        }
    }
}