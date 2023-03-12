using FlightManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class ReservationsPassangers
    {
        public ReservationsPassangers(int reservationID, int passangerID)
        {
            ReservationID = reservationID;
            PassangerID = passangerID;
        }

        public Reservation Reservation { get; set; }
        public int ReservationID { get; set; }

        public Passanger Passanger { get; set; }
        public int PassangerID { get; set; }
    }
}
