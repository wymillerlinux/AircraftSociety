using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;

namespace MVCDemo.Models
{
    public class MemberInitializer : System.Data.Entity.DropCreateDatabaseAlways<MemberDBContext>
    {
        protected override void Seed(MemberDBContext context)
        {
            var member = new List<Membership>
            {
                new Membership{fname="Barney",lname="Rubble",gender="male", age=50},
                //new Membership{fname="Wilma",lname="Flintstone",gender="female", age=45},
                //new Membership{fname="Freddie",lname="Flintstone",gender="male", age=50},
                //new Membership{fname="Pebbles",lname="Flintstone",gender="female", age=25},
                //new Membership{fname="Scooby",lname="Doo",gender="male", age=25}
            };

            member.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
        }
    }
}