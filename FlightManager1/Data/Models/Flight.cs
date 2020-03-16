using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlightManager1.Models
{
    public class Flight
    {
        [Key]
        public string Id { get; set; }
        public String From { get; set; }
        public String To { get; set; }
        public DateTime ArivalTime { get; set; }
        public DateTime LeaveTime { get; set; }
        public String TypeOfPlane { get; set; }
        public int PlaneId { get; set; }
        public string PilotName { get; set; }
        public int PlaneCapacity { get; set; }
        public int BuisnessClassCapacity { get; set; }

    }
}
