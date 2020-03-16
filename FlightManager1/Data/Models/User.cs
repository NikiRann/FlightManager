using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager1.Models
{
    public class User : IdentityUser <string>
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string PIN { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

    }
}
