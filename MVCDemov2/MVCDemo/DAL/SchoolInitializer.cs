using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCDemo.Models;

namespace MVCDemo.DAL
{
    //public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    //{
    //protected override void Seed(SchoolContext context)
    //{
    //    var students = new List<Student>
    //    {
    //    //new Student{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
    //    //new Student{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
    //    //new Student{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
    //    //new Student{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
    //    //new Student{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
    //    //new Student{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
    //    //new Student{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
    //    //new Student{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
    //    };

    //    students.ForEach(s => context..Add(s));
    //    context.SaveChanges();
    //    var courses = new List<Course>
    //    {
    //    new Course{CourseID=1050,Title="Chemistry",Credits=3,},
    //    new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
    //    new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
    //    new Course{CourseID=1045,Title="Calculus",Credits=4,},
    //    new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
    //    new Course{CourseID=2021,Title="Composition",Credits=3,},
    //    new Course{CourseID=2042,Title="Literature",Credits=4,}
    //    };
    //    courses.ForEach(s => context.Courses.Add(s));
    //    context.SaveChanges();
    //    var enrollments = new List<Enrollment>
    //    {
    //    new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
    //    new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
    //    new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
    //    new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
    //    new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
    //    new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
    //    new Enrollment{StudentID=3,CourseID=1050},
    //    new Enrollment{StudentID=4,CourseID=1050,},
    //    new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
    //    new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
    //    new Enrollment{StudentID=6,CourseID=1045},
    //    new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
    //    };
    //    enrollments.ForEach(s => context.Enrollments.Add(s));
    //    context.SaveChanges();
    //}

    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
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