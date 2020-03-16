using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager1.Data.Models
{
    public class Reservation
    {
        [Key]
        public string Id { get; set; }
        
        [ForeignKey("Flight")]

        public string FlightId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string PIN { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string TypeOfTicket { get; set; }
    
    }
}
