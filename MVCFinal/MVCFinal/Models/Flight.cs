using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinal.Models
{
    public class Flight
    {
        public int FlightID { get; set; }
        public string DepartingAirport { get; set; }
        public string ArrivingAirport { get; set; }
        public int? AircraftID { get; set; }
        public int? PilotID { get; set; }

        public virtual Aircraft Aircraft { get; set; }
        public virtual Pilot Pilot { get; set; }
    }
}