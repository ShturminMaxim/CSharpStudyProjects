using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cinema
{
    class CinemaDB : DbContext 
    {
         /// <summary>
        /// Inheritance and calling main Entity constructor with connetion to DB named "Test"
        /// </summary>
        public CinemaDB()
            : base("CinemaBase")
        { 
            
        }

        /// <summary>
        /// Collection of table rows, Model of our table
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<HallType> HallTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        public void addHallType(int sizeX, int sizeY){
            try
            {
                HallType hall = new HallType() { PlacesInRow = sizeX, Rows = sizeY };
                HallTypes.Add(hall);
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public void addMovie(string Name) {
            var movie = new Movie() {  Name = Name };
            
            Movies.Add(movie);
            this.SaveChanges();
        }
        public void addHall(string Name, int hallType) {
            var hall = new Hall() { Name = Name , HallType = hallType };
            
            Halls.Add(hall);
            this.SaveChanges();
        }
        public void createSession(int movieId, int hallId, float ticketPrice)
        {
            Session session = new Session() { MovieId = movieId, HallId = hallId, TicketPrice = ticketPrice };

            Sessions.Add(session);
            this.SaveChanges();
        }
        public void addTicket(int placeX, int placeY, int sessionId) {
            var ticket = new Ticket() { PlaceX = placeX, PlaceY = placeY, SessionId = sessionId};

            Tickets.Add(ticket);
            this.SaveChanges();     
        }
    }


    class Movie {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string Name { set; get; }
    }

    class Hall {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string Name { set; get; }
        public int HallType { set; get; }
    }

    class HallType {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public int PlacesInRow { set; get; }
        public int Rows { set; get; }
    }
    class Session {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public int HallId { set; get; }
        public int MovieId { set; get; }
        public float TicketPrice { set; get; }
    }

    class Ticket {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public int SessionId { set; get; }
        public int PlaceX { set; get; }
        public int PlaceY { set; get; }
        public float price { set; get; }
    }
}
