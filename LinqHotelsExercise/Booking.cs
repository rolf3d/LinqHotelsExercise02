using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHotelsExercise
{
    public class Booking
    {
        public Booking()
        {

        }

        public int BookingId { get; set; }
        public int HotelNo { get; set; }
        public int GuestNo { get; set; }
        public int RoomNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override string ToString()
        {
            return string.Format("BookingId: {0}, HotelNo: {1}, GuestNo: {2}, RoomNo: {3}, FromDate: {4}, ToDate: {5}", BookingId, HotelNo, GuestNo, RoomNo, FromDate.ToString("dd/MM/yyyy"), ToDate.ToString("dd/MM/yyyy"));
        }

    }
}
