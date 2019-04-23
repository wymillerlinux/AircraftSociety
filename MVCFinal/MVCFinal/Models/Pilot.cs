using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinal.Models
{
    public class Pilot
    {
        public int PilotID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? FlightID { get; set; }
        public int? AircraftID { get; set; }
        
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Aircraft> Aircraft { get; set; }
    }
}