using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieReservationProject
{
    [Serializable]
    class Tickets
    {
        private static int counter = 0;
        private int idTickets = ++counter;
        private int ticketPrice { get; set; }
        private Projection projection { get; set; }

        public Tickets(int ticketPrice,Projection projection)
        {
            this.ticketPrice = ticketPrice;
            this.projection = projection;
        }

        public Projection getProjection()
        {
            return projection;
        }

        public int getTicketPrice()
        {
            return ticketPrice;
        }
        public int getTicketID()
        {
            return idTickets;
        }
        public void setTicketID(int ticketID)
        {
            this.idTickets = ticketID;
        }
        public override string ToString()
        {
            return "Tickets ID:"+idTickets+" "+projection+" Price:"+ticketPrice;
        }

    }
}
