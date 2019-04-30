using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Aircraft
    {
        public int AircraftID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Callsign { get; set; }
        public bool IsActive { get; set; }
        public int? PilotID { get; set; }
        public int? FlightID { get; set; }

        public virtual Pilot Pilot { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}