using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHotelsExercise
{
    class Hotel
    {
        public int HotelNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("HotelNo: {0}, Name: {1}, Address: {2}", HotelNo, Name, Address);
        }
    }
}
