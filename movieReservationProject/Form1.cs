using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movieReservationProject
{
    public partial class Form1 : Form
    {
        private List<Movie> listOfAllMovies;
        private List<Hall> listOfAllHalls;
        private List<Projection> listOfAllProjections;
        private List<Tickets> listOfAllTickets;

        public Form1()
        {
            InitializeComponent();
            listOfAllMovies = new List<Movie>();
            listOfAllHalls = new List<Hall>();
            listOfAllProjections = new List<Projection>();
            listOfAllTickets = new List<Tickets>();

            if (File.Exists("Movies.bin"))
            {
                try
                {
                    using (Stream stream = File.Open("Movies.bin", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        {
                            List<Movie> movies = (List<Movie>)bin.Deserialize(stream);
                            foreach (Movie item in movies)
                            {
                                listOfAllMovies.Add(item);
                                lbMovies.Items.Add(item);
                                lbProjectionMovies.Items.Add(item);
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, deserilizing from the list");
                }
            }
            if (File.Exists("Halls.bin"))
            {
                try
                {
                    using (Stream stream = File.Open("Halls.bin", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        {
                            List<Hall> halls = (List<Hall>)bin.Deserialize(stream);
                            foreach (Hall item in halls)
                            {
                                listOfAllHalls.Add(item);
                                lbHalls.Items.Add(item);
                                lbProjectionHalls.Items.Add(item);
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, deserilizing from the list");
                }
            }
            if (File.Exists("Projections.bin"))
            {
                try
                {
                    using (Stream stream = File.Open("Projections.bin", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        {
                            List<Projection> projections = (List<Projection>)bin.Deserialize(stream);
                            foreach (Projection item in projections)
                            {
                                listOfAllProjections.Add(item);
                                lbTicketProjections.Items.Add(item);
                                lbAllProjections.Items.Add(item);
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, deserilizing from the list");
                }
            }
            if (File.Exists("Ticket.bin"))
            {
                try
                {
                    using (Stream stream = File.Open("Ticket.bin", FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        {
                            List<Tickets> tickets = (List<Tickets>)bin.Deserialize(stream);
                            foreach (Tickets item in tickets)
                            {
                                listOfAllTickets.Add(item);
                                lbProjections.Items.Add(item.getTicketID() + " " + item.getProjection().getTime() + " " + item.getProjection().getMovie().getMovieName() + " " + item.getProjection().getHall().getHallName() + " " + item.getTicketPrice());
                                lbTickets.Items.Add(item);
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, deserilizing from the list");
                }
            }
        }

        private void btnAddAMovie_Click(object sender, EventArgs e)
        {
            if (listOfAllMovies.Count() != 0)
            {
                int movieID = movieID = listOfAllMovies.ElementAt(listOfAllMovies.Count-1).getMovieId();
                int rating;
                bool checkInput = int.TryParse(txtMovieRating.Text, out rating);
                bool isItSameMovie = false;
                foreach (Movie movie in listOfAllMovies)
                {
                    if (txtMovieName.Text.Equals(movie.getMovieName())) {
                        isItSameMovie = true;
                    }
                }
                if (!checkInput || rating < 1 || rating > 5)
                {
                    MessageBox.Show("Wrong Entry!");
                }
                else {
                    Movie moviez = new Movie(txtMovieName.Text, txtMovieGenre.Text, txtMovieDescription.Text, rating);
                    moviez.setMovieId(movieID + 1);
                    if (!isItSameMovie)
                    {
                        listOfAllMovies.Add(moviez);
                        lbMovies.Items.Clear();
                        lbProjectionMovies.Items.Clear();
                        foreach (Movie movie in listOfAllMovies)
                        {
                            lbMovies.Items.Add(movie);
                            lbProjectionMovies.Items.Add(movie);
                        }

                            try
                            {
                                using (Stream stream = File.Open("Movies.bin", FileMode.Create))
                                {
                                    BinaryFormatter bin = new BinaryFormatter();
                                    bin.Serialize(stream, listOfAllMovies);
                                }
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("Error, can't serialize to file.");
                            }
                    }
                    else
                    {
                        MessageBox.Show("The following movie: "+moviez+" already exists in database.");
                    }
                }
            }
            else
            {
                int rating;
                bool checkInput = int.TryParse(txtMovieRating.Text, out rating);
                if (!checkInput || rating < 1 || rating > 5)
                {
                    MessageBox.Show("Wrong Entry!");
                }
                else {
                    listOfAllMovies.Add(new Movie(txtMovieName.Text, txtMovieGenre.Text, txtMovieDescription.Text, rating));
                    lbMovies.Items.Clear();
                    lbProjectionMovies.Items.Clear();
                    foreach (Movie movie in listOfAllMovies)
                    {
                        lbMovies.Items.Add(movie);
                        lbProjectionMovies.Items.Add(movie);
                    }

                    {
                        try
                        {
                            using (Stream stream = File.Open("Movies.bin", FileMode.Create))
                            {
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream, listOfAllMovies);
                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Error, can't serialize to file.");
                        }
                    }
                }
            }
        }

        private void btnDeleteAMovie_Click(object sender, EventArgs e)
        {
            int valueOfIdbr;
            bool isEntryValueProper = int.TryParse(txtDeleteUpdate.Text, out valueOfIdbr);
            if (isEntryValueProper)
            {
                for (int i = 0; i < listOfAllMovies.Count; i++)
                {
                    if (valueOfIdbr.Equals(listOfAllMovies.ElementAt(i).getMovieId()))
                    {
                        listOfAllMovies.RemoveAt(i);
                    }
                }
                lbMovies.Items.Clear();
                lbProjectionMovies.Items.Clear();
                foreach (Movie movie in listOfAllMovies)
                {
                    lbMovies.Items.Add(movie);
                    lbProjectionMovies.Items.Add(movie);
                }
                try
                {
                    using (Stream stream = File.Open("Movies.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllMovies);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
            else {
                MessageBox.Show("Please, enter a proper value into the textbox.");
            }
        }

        private void btnUpdateAMovie_Click(object sender, EventArgs e)
        {
            int rating;
            bool checkInput = int.TryParse(txtMovieRating.Text, out rating);
            int movieID;
            bool isEntryValueProper = int.TryParse(txtDeleteUpdate.Text, out movieID);
            if (!checkInput || rating < 1 || rating > 5 || !isEntryValueProper)
            {
                MessageBox.Show("Wrong Entry!");
            }
            else
            {
                for (int i = 0; i < listOfAllMovies.Count; i++)
                {
                    if (movieID.Equals(listOfAllMovies.ElementAt(i).getMovieId()))
                    {
                        Movie movie = new Movie(txtMovieName.Text, txtMovieGenre.Text, txtMovieDescription.Text, rating);
                        movie.setMovieId(listOfAllMovies.ElementAt(i).getMovieId());
                        listOfAllMovies.RemoveAt(i);
                        listOfAllMovies.Insert(i, movie);
                    }
                }                
                lbMovies.Items.Clear();
                lbProjectionMovies.Items.Clear();
                foreach (Movie movie in listOfAllMovies)
                {
                    lbMovies.Items.Add(movie);
                    lbProjectionMovies.Items.Add(movie);
                }
                try
                {
                    using (Stream stream = File.Open("Movies.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllMovies);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
        }

        private void btnAddAHall_Click(object sender, EventArgs e)
        {
            if (listOfAllHalls.Count() != 0)
            {
                int hallID = listOfAllHalls.ElementAt(listOfAllHalls.Count - 1).getHallID();
                int totalSeatNumber;
                bool checkInput = int.TryParse(txtTotalSeatNumber.Text, out totalSeatNumber);
                bool isItSameHall = false;
                foreach (Hall hall in listOfAllHalls)
                {
                    if (txtHallName.Text.Equals(hall.getHallName()))
                    {
                        isItSameHall = true;
                    }
                }
                if (!checkInput)
                {
                    MessageBox.Show("Wrong Entry!");
                }
                else {
                    Hall hallz = new Hall( txtHallName.Text, totalSeatNumber);
                    hallz.setHallID(hallID + 1);
                    if (!isItSameHall)
                    {
                        listOfAllHalls.Add(hallz);
                        lbHalls.Items.Clear();
                        lbProjectionHalls.Items.Clear();
                        foreach (Hall hall in listOfAllHalls)
                        {
                            lbHalls.Items.Add(hall);
                            lbProjectionHalls.Items.Add(hall);
                        }

                        try
                        {
                            using (Stream stream = File.Open("Halls.bin", FileMode.Create))
                            {
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream, listOfAllHalls);
                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Error, can't serialize to file.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The following hall: " + hallz + " already exists in database.");
                    }
                }
            }
            else
            {
                int totalSeatNumber;
                bool checkInput = int.TryParse(txtTotalSeatNumber.Text, out totalSeatNumber);
                if (!checkInput)
                {
                    MessageBox.Show("Wrong Entry!");
                }
                else {
                    listOfAllHalls.Add(new Hall(txtHallName.Text,totalSeatNumber));
                    lbHalls.Items.Clear();
                    lbProjectionHalls.Items.Clear();
                    foreach (Hall hall in listOfAllHalls)
                    {
                        lbHalls.Items.Add(hall);
                        lbProjectionHalls.Items.Add(hall);
                    }

                    {
                        try
                        {
                            using (Stream stream = File.Open("Halls.bin", FileMode.Create))
                            {
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream, listOfAllHalls);
                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Error, can't serialize to file.");
                        }
                    }
                }
            }
        }

        private void btnDeleteAHall_Click(object sender, EventArgs e)
        {
            int valueOfIdbr;
            bool isEntryValueProper = int.TryParse(txtUpdateDeleteHall.Text, out valueOfIdbr);
            if (isEntryValueProper)
            {
                for (int i = 0; i < listOfAllHalls.Count; i++)
                {
                    if (valueOfIdbr.Equals(listOfAllHalls.ElementAt(i).getHallID()))
                    {
                        listOfAllHalls.RemoveAt(i);
                    }
                }
                lbHalls.Items.Clear();
                lbProjectionHalls.Items.Clear();
                foreach (Hall hall in listOfAllHalls)
                {
                    lbHalls.Items.Add(hall);
                    lbProjectionHalls.Items.Add(hall);
                }
                try
                {
                    using (Stream stream = File.Open("Halls.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllHalls);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
            else {
                MessageBox.Show("Please, enter a proper value into the textbox.");
            }

        }

        private void btnUpdateAHall_Click(object sender, EventArgs e)
        {
            int totalSeatNumber;
            bool checkInput = int.TryParse(txtTotalSeatNumber.Text, out totalSeatNumber);
            int hallID;
            bool isEntryValueProper = int.TryParse(txtUpdateDeleteHall.Text, out hallID);
            if (!checkInput || !isEntryValueProper)
            {
                MessageBox.Show("Wrong Entry!");
            }
            else
            {
                for (int i = 0; i < listOfAllHalls.Count; i++)
                {
                    if (hallID.Equals(listOfAllHalls.ElementAt(i).getHallID()))
                    {
                        Hall hallz = new Hall(txtHallName.Text,totalSeatNumber);
                        hallz.setHallID(listOfAllHalls.ElementAt(i).getHallID());
                        listOfAllHalls.RemoveAt(i);
                        listOfAllHalls.Insert(i, hallz);
                    }
                }
                lbHalls.Items.Clear();
                lbProjectionHalls.Items.Clear();
                foreach (Hall hallz in listOfAllHalls)
                {
                    lbHalls.Items.Add(hallz);
                    lbProjectionHalls.Items.Add(hallz);
                }
                try
                {
                    using (Stream stream = File.Open("Halls.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllHalls);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
        }

        private void btnAddAProjection_Click(object sender, EventArgs e)
        {
            int selectedMovie;
            bool movieInput = int.TryParse(txtSelectedMovie.Text, out selectedMovie);
            int selectedHall;
            bool hallInput = int.TryParse(txtSelectedHall.Text, out selectedHall);
            int choosenMovie = 0;
            bool isMovieFound = false;
            for (int i = 0; i < listOfAllMovies.Count; i++)
            {
                if (selectedMovie.Equals(listOfAllMovies.ElementAt(i).getMovieId()))
                {
                    choosenMovie = i;
                    isMovieFound = true;
                }
            }
            int choosenHall = 0;
            bool isHallFound = false;
            for (int i = 0; i < listOfAllHalls.Count; i++)
            {
                if (selectedHall.Equals(listOfAllHalls.ElementAt(i).getHallID()))
                {
                    choosenHall = i;
                    isHallFound = true;
                }
            }
            bool isTimeAndHallEqual = false;
            foreach (Projection item in listOfAllProjections)
            {
                if (dtpProjectionTime.Text.Equals(item.getTime()) && listOfAllHalls.ElementAt(choosenHall).getHallName().Equals(item.getHall().getHallName()))
                {
                    isTimeAndHallEqual = true;
                }
            }
            if (listOfAllProjections.Count() != 0 && movieInput && hallInput && isMovieFound && isHallFound)
            {
                int projectionID = listOfAllProjections.ElementAt(listOfAllProjections.Count - 1).getProjectionID();
                Projection projectionz = new Projection(dtpProjectionTime.Text, listOfAllMovies.ElementAt(choosenMovie), listOfAllHalls.ElementAt(choosenHall));
                if (!isTimeAndHallEqual)
                {
                    projectionz.setProjectionID(projectionID + 1);
                    listOfAllProjections.Add(projectionz);
                    lbTicketProjections.Items.Clear();
                    lbAllProjections.Items.Clear();
                    foreach (Projection projections in listOfAllProjections)
                    {
                        lbTicketProjections.Items.Add(projections);
                        lbAllProjections.Items.Add(projections);
                    }
                    try
                    {
                        using (Stream stream = File.Open("Projections.bin", FileMode.Create))
                        {
                            BinaryFormatter bin = new BinaryFormatter();
                            bin.Serialize(stream, listOfAllProjections);
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error, can't serialize to file.");
                    }
                }
                else
                {
                    MessageBox.Show("The Following: "+projectionz+" already exists.");
                }
            }
            else if(movieInput && hallInput && isMovieFound && isHallFound)
            {   
                    listOfAllProjections.Add(new Projection(dtpProjectionTime.Text, listOfAllMovies.ElementAt(choosenMovie),listOfAllHalls.ElementAt(choosenHall)));
                    lbTicketProjections.Items.Clear();
                    lbAllProjections.Items.Clear();
                    foreach (Projection projection in listOfAllProjections)
                    {
                        lbTicketProjections.Items.Add(projection);
                        lbAllProjections.Items.Add(projection);
                    }
                        try
                        {
                            using (Stream stream = File.Open("Projections.bin", FileMode.Create))
                            {
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream, listOfAllProjections);
                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Error, can't serialize to file.");
                        }
            }
            else
            {
                MessageBox.Show("Please, enter a proper value into textbox.");
            }
        }

        private void btnDeleteAProjection_Click(object sender, EventArgs e)
        {
            int inputProjectionID;
            bool isEntryProper = int.TryParse(txtDeleteUpdateProjection.Text, out inputProjectionID);
            if (!isEntryProper)
            {
                MessageBox.Show("Please, enter a proper value into the textbox.");
            }
            else
            {
                for (int i = 0; i < listOfAllProjections.Count; i++)
                {
                    if (inputProjectionID.Equals(listOfAllProjections.ElementAt(i).getProjectionID()))
                    {
                        listOfAllProjections.RemoveAt(i);
                    }
                }
                lbTicketProjections.Items.Clear();
                lbAllProjections.Items.Clear();
                foreach (Projection projections in listOfAllProjections)
                {
                    lbTicketProjections.Items.Add(projections);
                    lbAllProjections.Items.Add(projections);
                }

                try
                {
                    using (Stream stream = File.Open("Projections.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllProjections);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
        }

        private void btnUpdateAProjection_Click(object sender, EventArgs e)
        {
            int projectionID;
            bool isEntryProper = int.TryParse(txtDeleteUpdateProjection.Text, out projectionID);
            int selectedMovie;
            bool isMovieIDEntryProper = int.TryParse(txtSelectedMovie.Text, out selectedMovie);
            int selectedHall;
            bool isHallIDEntryProper = int.TryParse(txtSelectedHall.Text, out selectedHall);
            int choosenMovie = 0;
            bool isMovieFound = false;
            for (int i = 0; i < listOfAllMovies.Count; i++)
            {
                if (selectedMovie.Equals(listOfAllMovies.ElementAt(i).getMovieId()))
                {
                    choosenMovie = i;
                    isMovieFound = true;
                }
            }
            int choosenHall = 0;
            bool isHallFound = false;
            for (int i = 0; i < listOfAllHalls.Count; i++)
            {
                if (selectedHall.Equals(listOfAllHalls.ElementAt(i).getHallID()))
                {
                    choosenHall = i;
                    isHallFound = true;
                }
            }
            if (!isEntryProper && !isMovieIDEntryProper && !isHallIDEntryProper && !isMovieFound && !isHallFound)
            {
                MessageBox.Show("Value entered at textbox isn't proper or movie and hall don't exist with that ID");
            }
            else
            {
                for (int i = 0; i < listOfAllProjections.Count; i++)
                {
                    if (projectionID.Equals(listOfAllProjections.ElementAt(i).getProjectionID()))
                    {
                        Projection projecionz = new Projection(dtpProjectionTime.Text, listOfAllMovies.ElementAt(choosenMovie), listOfAllHalls.ElementAt(choosenHall));
                        projecionz.setProjectionID(listOfAllProjections.ElementAt(i).getProjectionID());
                        listOfAllProjections.RemoveAt(i);
                        listOfAllProjections.Insert(i, projecionz);
                    }
                }
                lbTicketProjections.Items.Clear();
                lbAllProjections.Items.Clear();
                foreach (Projection projections in listOfAllProjections)
                {
                    lbTicketProjections.Items.Add(projections);
                    lbAllProjections.Items.Add(projections);
                }
                try
                {
                    using (Stream stream = File.Open("Projections.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllProjections);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
        }

        private void btnShowDetailsProjection_Click(object sender, EventArgs e)
        {
            int selectedTicketID;
            bool isSelectedIDFound = int.TryParse(txtChooseAProjection.Text, out selectedTicketID);
            int ticketID=0;
            bool isTicketFound = false;
            for (int i = 0; i < listOfAllTickets.Count; i++)
            {
                if (selectedTicketID.Equals(listOfAllTickets.ElementAt(i).getTicketID()))
                {
                    ticketID = i;
                    isTicketFound = true;
                }
            }
            if(isSelectedIDFound && isTicketFound)
            {
                lbProjectionDetails.Items.Clear();
                lbProjectionDetails.Items.Add(listOfAllTickets.ElementAt(ticketID).getProjection().getMovie().getDescription() +" "+ listOfAllTickets.ElementAt(ticketID).getProjection().getMovie().getMovieGrade());

            }
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            int selectedTicketID;
            bool isSelectedIDFound = int.TryParse(txtChooseAProjection.Text, out selectedTicketID);
            int ticketID = 0;
            bool isTicketFound = false;
            for (int i = 0; i < listOfAllTickets.Count; i++)
            {
                if (selectedTicketID.Equals(listOfAllTickets.ElementAt(i).getTicketID()))
                {
                    ticketID = i;
                    isTicketFound = true;
                }
            }
            if (isSelectedIDFound && isTicketFound)
            {
                try
                {
                    using (Stream stream = File.Open("TicketData.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllTickets.ElementAt(ticketID));
                        bin.Serialize(stream, numAmountOfTickets.Value);
                    }
                    using (Stream stream = File.Open("TicketNumber.bin", FileMode.Create))
                    {
                        int value = (int)numAmountOfTickets.Value;
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, value);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
                reservationForm reservationform = new reservationForm();
                reservationform.ShowDialog();
            }

        }

        private void btnAddATicket_Click(object sender, EventArgs e)
        {
            int projectionID;
            bool isEntryProper = int.TryParse(txtAddDeleteTicket.Text, out projectionID);
            int ticketPrice;
            bool isPriceEntryProper = int.TryParse(txtTicketPrice.Text, out ticketPrice);
            int isProjectionIDFound=0;
            bool isProjectionFound = false;
            for (int i = 0; i < listOfAllProjections.Count; i++)
            {
                if (projectionID.Equals(listOfAllProjections.ElementAt(i).getProjectionID()))
                {
                    isProjectionIDFound = i;
                    isProjectionFound = true;
                }
            }
            if(listOfAllTickets.Count() != 0 && isEntryProper && isPriceEntryProper && isProjectionFound)
            {
                int lastTicketID = listOfAllTickets.ElementAt(listOfAllTickets.Count - 1).getTicketID();
                Tickets ticketz = new Tickets(ticketPrice,listOfAllProjections.ElementAt(isProjectionIDFound));
                ticketz.setTicketID(lastTicketID + 1);
                listOfAllTickets.Add(ticketz);
                lbProjections.Items.Clear();
                lbTickets.Items.Clear();
                foreach (Tickets item in listOfAllTickets)
                {
                    lbProjections.Items.Add(item.getTicketID()+" "+item.getProjection().getTime()+" "+item.getProjection().getMovie().getMovieName() + " "+item.getProjection().getHall().getHallName()+" "+item.getTicketPrice());
                    lbTickets.Items.Add(item);
                }
                try
                {
                    using (Stream stream = File.Open("Ticket.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllTickets);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
            else if(isEntryProper && isPriceEntryProper && isProjectionFound)
            {
                listOfAllTickets.Add(new Tickets(ticketPrice,listOfAllProjections.ElementAt(isProjectionIDFound)));
                lbProjections.Items.Clear();
                lbTickets.Items.Clear();
                foreach (Tickets item in listOfAllTickets)
                {
                    lbProjections.Items.Add(item.getTicketID() + " "+item.getProjection().getTime() + " " + item.getProjection().getMovie().getMovieName() + " " + item.getProjection().getHall().getHallName() + " " + item.getTicketPrice());
                    lbTickets.Items.Add(item);
                }
                try
                {
                    using (Stream stream = File.Open("Ticket.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllTickets);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
            else
            {
                MessageBox.Show("Please, enter a proper value into the textbox.");
            }
        }

        private void btnDeleteATicket_Click(object sender, EventArgs e)
        {
            int selectedTicketID;
            bool isTicketIdEntryProper = int.TryParse(txtAddDeleteTicket.Text, out selectedTicketID);
            int foundTicketID=0;
            bool isTicketIDFound=false;
            for (int i = 0; i < listOfAllTickets.Count; i++)
            {
                if (selectedTicketID.Equals(listOfAllTickets.ElementAt(i).getTicketID()))
                {
                    foundTicketID = i;
                    isTicketIDFound = true;
                }
            }
            if (isTicketIdEntryProper && isTicketIDFound)
            {
                for (int i = 0; i < listOfAllTickets.Count; i++)
                {
                    listOfAllTickets.RemoveAt(foundTicketID);
                }
                lbProjections.Items.Clear();
                lbTickets.Items.Clear();
                foreach (Tickets item in listOfAllTickets)
                {
                    lbProjections.Items.Add(item.getTicketID() + " "+item.getProjection().getTime()+" "+item.getProjection().getMovie().getMovieName()+" "+item.getProjection().getHall().getHallName()+" "+item.getTicketPrice());
                    lbTickets.Items.Add(item);
                }
                try
                {
                    using (Stream stream = File.Open("Ticket.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllTickets);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
            else
            {
                MessageBox.Show("Value entered in textbox isn't proper or the ticket with that id doesn't exist.");
            }
        }

        private void btnUpdateATicket_Click(object sender, EventArgs e)
        {
            int selectedTicketID;
            bool isTicketIdEntryProper = int.TryParse(txtAddDeleteTicket.Text, out selectedTicketID);

            int UpdateTicketID;
            bool isUpdateTicketEntryProper = int.TryParse(txtTicketProjectionUpdate.Text, out UpdateTicketID);

            int updatedTicketPrice;
            bool isUpdatedTicketPriceProper = int.TryParse(txtTicketPriceUpdate.Text, out updatedTicketPrice);

            int projectionUpdateID=0;
            bool isUpdateTicketFound=false;
            for (int i = 0; i < listOfAllProjections.Count; i++)
            {
                if (UpdateTicketID.Equals(listOfAllProjections.ElementAt(i).getProjectionID()))
                {
                    projectionUpdateID = i;
                    isUpdateTicketFound = true;
                }
            }

            if(isTicketIdEntryProper && isUpdateTicketFound && isUpdatedTicketPriceProper)
            {
                for (int i = 0; i < listOfAllTickets.Count; i++)
                {
                    if (selectedTicketID.Equals(listOfAllTickets.ElementAt(i).getTicketID()))
                    {
                        Tickets ticketz = new Tickets(updatedTicketPrice,listOfAllProjections.ElementAt(projectionUpdateID));
                        ticketz.setTicketID(listOfAllTickets.ElementAt(i).getTicketID());
                        listOfAllTickets.RemoveAt(i);
                        listOfAllTickets.Insert(i, ticketz);
                    }
                }
                lbProjections.Items.Clear();
                lbTickets.Items.Clear();
                foreach (Tickets tickets in listOfAllTickets)
                {
                    lbProjections.Items.Add(tickets.getTicketID() + " " + tickets.getProjection().getTime() + " " + tickets.getProjection().getMovie().getMovieName() + " " + tickets.getProjection().getHall().getHallName() + " " + tickets.getTicketPrice());
                    lbTickets.Items.Add(tickets);
                }
                try
                {
                    using (Stream stream = File.Open("Ticket.bin", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listOfAllTickets);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, can't serialize to file.");
                }
            }
            else
            {
                MessageBox.Show("Value entered in textbox isn't proper or the ticket with that id doesn't exist.");
            }
        }
    }
    }


