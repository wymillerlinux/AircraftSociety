using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Membership
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string fname { get; set; }

        [Display(Name = "Last Name")]
        public string lname { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Age")]
        public int age { get; set; } = 30;
    }
}