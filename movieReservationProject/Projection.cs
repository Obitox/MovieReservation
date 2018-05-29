using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieReservationProject
{
    [Serializable]
    class Projection
    {
        private static int counter = 0;
        private int idProjection = ++counter;
        private string projectionTime { get; set; }
        private Movie movie { get; set; }
        private Hall hall { get; set; }
        public Projection(string projectionTime, Movie movie,Hall hall)
        {
            this.projectionTime = projectionTime;
            this.movie = movie;
            this.hall = hall;
        }

        public Movie getMovie()
        {
            return movie;
        }

        public Hall getHall()
        {
            return hall;
        }

        public string getTime()
        {
            return projectionTime;
        }
        public override string ToString()
        {
            return "Projection ID:" + idProjection +" Time:"+ projectionTime +" "+ movie +" "+ hall;
        }
        public int getProjectionID()
        {
            return idProjection;
        }
        public void setProjectionID(int projectionID)
        {
            this.idProjection = projectionID;
        }
    }
}
