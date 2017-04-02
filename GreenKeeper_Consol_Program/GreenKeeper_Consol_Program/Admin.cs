using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenKeeper_Consol_Program
{
    public sealed class Admin : IPerson
    {

        public bool _isadmin { get; set; }
        public int _telefon { get; set; }
        public string _navn { get; set; }
        public string _email { get; set; }
        public string _password { get; set; }
        public double Anciennitet()
        {
            throw new NotImplementedException();
        }

        public int TotelTimer()
        {
            throw new NotImplementedException();
        }
    }
}
