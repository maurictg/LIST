using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIST.Areas.Leerling.Models
{
    public class Profiel
    {
        public string lijn { get; set; }
        public bool gekozen { get; set; }
        public int status { get; set; } //is: 0 (niets) 1 (wijziging opgeslagen) 2(wijziging mislukt)
    }
}