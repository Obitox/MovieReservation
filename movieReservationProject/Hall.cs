using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieReservationProject
{
    [Serializable]
    class Hall
    {
        private static int counter = 0;
        private int idHall = ++counter;
        private string hallName { get; set; }
        private int totalSeatNumber;

        public Hall(string hallName,int totalSeatNumber)
        {
            this.hallName = hallName;
            this.totalSeatNumber = totalSeatNumber;
        }

        public string getHallName()
        {
            return hallName;
        }
        public int getHallID()
        {
            return idHall;
        }
        public void setHallID(int hallID)
        {
            this.idHall = hallID;
        }
        public int getTotalSeatNumber()
        {
            return totalSeatNumber;
        }
        public override string ToString()
        {
            return "Hall ID:"+idHall+" " + "Name:"+ hallName +" Total seats:"+ totalSeatNumber;
        }

    }
}
