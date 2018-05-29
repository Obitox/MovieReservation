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
    public partial class reservationForm : Form
    {
        private Button[] arrayOfButtons;
        private int totalHallSeatNumber;
        private int numberOfTicketz;
        private int counter=0;
        private string ticketReservationData="";
        private List<double> listOfAllMovieRatings;
        private double movieRating;
        private delegate void movieRatingMethod(string file);

        public reservationForm()
        {
            InitializeComponent();
            listOfAllMovieRatings = new List<double>();
            try
            {
                using (Stream stream = File.Open("TicketData.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    {
                        Tickets ticket = (Tickets)bin.Deserialize(stream);
                        ticketReservationData += ""+ ticket.getProjection().getTime()+" "+ticket.getProjection().getMovie().getMovieName()+" "+ticket.getProjection().getHall().getHallName()+"\n";
                        lblMovie.Text = "Movie: " + ticket.getProjection().getMovie().getMovieName();
                        lblMovieRating.Text = "Rating: " + ticket.getProjection().getMovie().getMovieGrade();
                        totalHallSeatNumber = ticket.getProjection().getHall().getTotalSeatNumber();
                    }
                }
                using (Stream stream = File.Open("TicketNumber.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    {
                        int numberOfTickets = (int)bin.Deserialize(stream);
                        numberOfTicketz = numberOfTickets;
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error, deserilizing from the list");
            }
        }

        private void reservationForm_Load(object sender, EventArgs e)
        {
            arrayOfButtons = new Button[totalHallSeatNumber];
            for (int i = 0; i < totalHallSeatNumber; i++)
            {
                arrayOfButtons[i] = new Button();
                arrayOfButtons[i].Width = 100;
                arrayOfButtons[i].Height = 30;
                arrayOfButtons[i].Click += new EventHandler(ButtonClick);
                arrayOfButtons[i].Text = "Seat: " + i;
                arrayOfButtons[i].Parent = flpSeats;
                arrayOfButtons[i].Enabled = true;
                flpSeats.Controls.Add(arrayOfButtons[i]);
                this.Controls.Add(flpSeats);
            }
        }
        void ButtonClick(object sender, EventArgs e)
        {
            if (counter == numberOfTicketz)
            {
                MessageBox.Show("You have no more tickets!");
            }
            else
            {
                Button b = (Button)sender;
                ticketReservationData += b.Text + "\n";
                b.Enabled = false;
                counter++;
            }
            try
            {
                using (Stream stream = File.Open("TicketReservation.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, ticketReservationData);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error, can't serialize to file.");
            }
        }

        private void btnReadReservation_Click(object sender, EventArgs e)
        {
            movieRatingMethod mrm = new movieRatingMethod(readReservation);
            mrm("TicketReservation.bin");
        }
        public void readReservation(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    using (Stream stream = File.Open(file, FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        {
                            string data = (string)bin.Deserialize(stream);
                            lblReservation.Text = data;
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error, deserilizing from the list");
                }
            }
        }
        private void tmrRefreshProgressBar_Tick(object sender, EventArgs e)
        {
            pb1Availability.Refresh();
            int percent = (int)(((double)counter / (double)totalHallSeatNumber) * 100);
            pb1Availability.CreateGraphics().DrawString(percent.ToString() + "%",
                new Font("Arial", (float)8.25, FontStyle.Regular),
                Brushes.Black, new PointF(pb1Availability.Width / 2 - 10,
                pb1Availability.Height / 2 - 7));
            pb1Availability.Value = percent;
            lblSeatsAvailableTaken.Text = "Seats taken: " + counter + "/" + totalHallSeatNumber;
        }

        private void btnRateAMovie_Click(object sender, EventArgs e)
        {
            double temp = 0;
            if (listOfAllMovieRatings.Count < numberOfTicketz)
            {
                double value = (double)nudMovieRating.Value;
                listOfAllMovieRatings.Add(value);
                foreach (int item in listOfAllMovieRatings)
                {
                    temp += item;
                }
                movieRating = temp / listOfAllMovieRatings.Count;
                lblMovieRating.Text = "Rating: " + movieRating.ToString("G4");
            }
            else
            {
                MessageBox.Show("You've finished your movie rating.");
            }
        }
    }
}
