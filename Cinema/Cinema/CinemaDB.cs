using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class CinemaDB : DbContext 
    {
         /// <summary>
        /// Inheritance and calling main Entity constructor with connetion to DB named "Test"
        /// </summary>
        public CinemaDB()
            : base("Cinema")
        { 
            
        }

        /// <summary>
        /// Collection of table rows, Model of our table
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<HallType> HallTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }



        public void addHallType(int sizeX, int sizeY){
            var x = sizeX;
            var y = sizeY;
            int[,] places = new int[y,x];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    places[y, x] = 0;
                }
            }
            var hall = new HallType(){ View = places };
            
            HallTypes.Add(hall);
            this.SaveChanges();
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
        public void createSession(int movieId, int hallId)
        {
            Session session = new Session() { MovieId = movieId, HallId = hallId };

            Sessions.Add(session);
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
        public int[,] View { set; get; }
    }

    class Session {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public List<int> SoldTickets { set; get; }
        public int HallId { set; get; }
        public int MovieId { set; get; }
    }
}
