using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenKeeper_Consol_Program
{
    public interface IPerson
    {
        int _telefon { get; set; }
        string _navn { get; set; }
        string _email { get; set; }
        string _password { get; set; }
        double Anciennitet();
        int TotelTimer();
    }
}
