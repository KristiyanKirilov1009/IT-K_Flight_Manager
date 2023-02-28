using System.Diagnostics.Contracts;
using System.Numerics;

namespace Flight_Manager.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string? loacationStart { get; set; }
        public string? loacationEnd { get; set; }
        public DateTime takeOffTime { get; set; }
        public DateTime landingTime { get; set; }
        public Plane? plane { get; set; }
    }
}
