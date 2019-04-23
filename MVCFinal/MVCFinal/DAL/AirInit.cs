using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCFinal.Models;

namespace MVCFinal.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseAlways<AirContext>
    {
        protected override void Seed(AirContext context)
        {
            var pilot = new List<Pilot>
            {
                new Pilot {PilotID=1001, FirstName="Wyatt", LastName="Miller", FlightID=3001, AircraftID=2001},
            };

            pilot.ForEach(s => context.Pilots.Add(s));
            context.SaveChanges();

            var aircraft = new List<Aircraft>
            {
                new Aircraft {AircraftID=2001, Make="Cessna", Model="172", Year="2016", Callsign="N465AD", PilotID=1001, FlightID=3001}
            };
            aircraft.ForEach(s => context.Aircraft.Add(s));
            context.SaveChanges();

            var flight = new List<Flight>
            {
                new Flight {FlightID=3001, DepartingAirport="Y89", ArrivingAirport="KTVC", AircraftID=2001, PilotID=1001},
            };
            flight.ForEach(s => context.Flights.Add(s));
            context.SaveChanges();
        }
    }
}