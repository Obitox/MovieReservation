namespace movieReservationProject
{
    partial class reservationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flpSeats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMovie = new System.Windows.Forms.Label();
            this.lblMovieRating = new System.Windows.Forms.Label();
            this.lblReservation = new System.Windows.Forms.Label();
            this.btnReadReservation = new System.Windows.Forms.Button();
            this.tmrRefreshProgressBar = new System.Windows.Forms.Timer(this.components);
            this.pb1Availability = new System.Windows.Forms.ProgressBar();
            this.lblSeatsAvailableTaken = new System.Windows.Forms.Label();
            this.btnRateAMovie = new System.Windows.Forms.Button();
            this.nudMovieRating = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMovieRating)).BeginInit();
            this.SuspendLayout();
            // 
            // flpSeats
            // 
            this.flpSeats.AutoScroll = true;
            this.flpSeats.Location = new System.Drawing.Point(21, 66);
            this.flpSeats.Name = "flpSeats";
            this.flpSeats.Size = new System.Drawing.Size(322, 167);
            this.flpSeats.TabIndex = 0;
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Location = new System.Drawing.Point(18, 26);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(35, 13);
            this.lblMovie.TabIndex = 1;
            this.lblMovie.Text = "label1";
            // 
            // lblMovieRating
            // 
            this.lblMovieRating.AutoSize = true;
            this.lblMovieRating.Location = new System.Drawing.Point(261, 26);
            this.lblMovieRating.Name = "lblMovieRating";
            this.lblMovieRating.Size = new System.Drawing.Size(35, 13);
            this.lblMovieRating.TabIndex = 2;
            this.lblMovieRating.Text = "label2";
            // 
            // lblReservation
            // 
            this.lblReservation.AutoSize = true;
            this.lblReservation.Location = new System.Drawing.Point(507, 60);
            this.lblReservation.Name = "lblReservation";
            this.lblReservation.Size = new System.Drawing.Size(0, 13);
            this.lblReservation.TabIndex = 3;
            // 
            // btnReadReservation
            // 
            this.btnReadReservation.Location = new System.Drawing.Point(366, 55);
            this.btnReadReservation.Name = "btnReadReservation";
            this.btnReadReservation.Size = new System.Drawing.Size(135, 23);
            this.btnReadReservation.TabIndex = 4;
            this.btnReadReservation.Text = "Read All Reservations";
            this.btnReadReservation.UseVisualStyleBackColor = true;
            this.btnReadReservation.Click += new System.EventHandler(this.btnReadReservation_Click);
            // 
            // tmrRefreshProgressBar
            // 
            this.tmrRefreshProgressBar.Enabled = true;
            this.tmrRefreshProgressBar.Tick += new System.EventHandler(this.tmrRefreshProgressBar_Tick);
            // 
            // pb1Availability
            // 
            this.pb1Availability.Location = new System.Drawing.Point(354, 16);
            this.pb1Availability.Name = "pb1Availability";
            this.pb1Availability.Size = new System.Drawing.Size(266, 23);
            this.pb1Availability.TabIndex = 5;
            // 
            // lblSeatsAvailableTaken
            // 
            this.lblSeatsAvailableTaken.AutoSize = true;
            this.lblSeatsAvailableTaken.Location = new System.Drawing.Point(638, 21);
            this.lblSeatsAvailableTaken.Name = "lblSeatsAvailableTaken";
            this.lblSeatsAvailableTaken.Size = new System.Drawing.Size(35, 13);
            this.lblSeatsAvailableTaken.TabIndex = 6;
            this.lblSeatsAvailableTaken.Text = "label1";
            // 
            // btnRateAMovie
            // 
            this.btnRateAMovie.Location = new System.Drawing.Point(375, 123);
            this.btnRateAMovie.Name = "btnRateAMovie";
            this.btnRateAMovie.Size = new System.Drawing.Size(121, 23);
            this.btnRateAMovie.TabIndex = 8;
            this.btnRateAMovie.Text = "Rate a Movie";
            this.btnRateAMovie.UseVisualStyleBackColor = true;
            this.btnRateAMovie.Click += new System.EventHandler(this.btnRateAMovie_Click);
            // 
            // nudMovieRating
            // 
            this.nudMovieRating.Location = new System.Drawing.Point(375, 97);
            this.nudMovieRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMovieRating.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMovieRating.Name = "nudMovieRating";
            this.nudMovieRating.ReadOnly = true;
            this.nudMovieRating.Size = new System.Drawing.Size(120, 20);
            this.nudMovieRating.TabIndex = 9;
            this.nudMovieRating.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Movie Rating:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hall seats:";
            // 
            // reservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 369);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMovieRating);
            this.Controls.Add(this.btnRateAMovie);
            this.Controls.Add(this.lblSeatsAvailableTaken);
            this.Controls.Add(this.pb1Availability);
            this.Controls.Add(this.btnReadReservation);
            this.Controls.Add(this.lblReservation);
            this.Controls.Add(this.lblMovieRating);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.flpSeats);
            this.Name = "reservationForm";
            this.Text = "reservationForm";
            this.Load += new System.EventHandler(this.reservationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMovieRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSeats;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.Label lblMovieRating;
        private System.Windows.Forms.Label lblReservation;
        private System.Windows.Forms.Button btnReadReservation;
        private System.Windows.Forms.Timer tmrRefreshProgressBar;
        private System.Windows.Forms.ProgressBar pb1Availability;
        private System.Windows.Forms.Label lblSeatsAvailableTaken;
        private System.Windows.Forms.Button btnRateAMovie;
        private System.Windows.Forms.NumericUpDown nudMovieRating;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}