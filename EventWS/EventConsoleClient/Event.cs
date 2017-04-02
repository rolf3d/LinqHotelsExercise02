﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsoleClient
{
    public class Event
    {

        public int id { get; set; }
        
        public string name { get; set; }
        
        public string description { get; set; }
        
        public string place { get; set; }

        public DateTime DateTime { get; set; }
    }
}
