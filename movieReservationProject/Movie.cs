using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieReservationProject
{
    [Serializable]
    class Movie
    {
        private static int counter = 0;
        private int movieID = ++counter;
        private string movieName { get; set; }
        private string movieGenre;
        private string movieDescription;
        private double movieGrade;
    
        public Movie(string movieName,string movieGenre,string movieDescription,double movieGrade)
        {
            this.movieName = movieName;
            this.movieGenre = movieGenre;
            this.movieDescription = movieDescription;
            this.movieGrade = movieGrade;
        }

        public override string ToString()
        {
            return "Movie ID:"+movieID +" Name:"+ movieName+" Genre:" + movieGenre +" Description:"+ movieDescription+ " Rating:" + movieGrade;
        }
        public string getMovieName()
        {
            return movieName;
        }
        public string getDescription()
        {
            return movieDescription;
        }
        public double getMovieGrade()
        {
            return movieGrade;
        }
        public int getMovieId()
        {
            return movieID;
        }
        public void setMovieId(int movieID)
        {
            this.movieID = movieID;
        }
    }
}
