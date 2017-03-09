using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHotelsExercise
{
    class Room
    {
        public int RoomNo { get; set; }
        public Hotel Hotel { get; set; }
        public char Types { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return string.Format("HotelNo: {0}, HotelName: {1}, RoomNo: {2}, Types: {3}, Price: {4}", Hotel.HotelNo, Hotel.Name, RoomNo, Types, Price);
        }
    }
}
