using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations.Resources;

namespace CA2S00092756RAD1.Models
{
    class MovieDBInitialiser : DropCreateDatabaseAlways<FilmsDB>
    {

        protected override void Seed(FilmsDB context)
        {
            var Movie = new List<Movies>()
            {
                new Movies() { MovieID = 1, Title = "Crouching Tiger, Hidden Dragon", //ReleaseYear = DateTime.Parse("2000"), 
                    RunTime = DateTime.Parse("2:00"), MovieType = Movies.Genres.Action.ToString(),
                    actors = new List<Actors>()
                    {
                        new Actors()
                        {
                            ActorID = 1, FirstName = "Chow", Surname = "Yun-Fat",
                            //DOB = DateTime.Parse("18/05/1955"), 
                            gender = Actors.Gender.M,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 1, ActorID = 1, screenName = "Master Li Mu Bai"                                   
                                }
                            }
                        },                       
                        new Actors()
                        {
                            ActorID = 2, FirstName = "Michelle", Surname = "Yeoh",
                            //DOB = DateTime.Parse("06/08/1962"), 
                            gender = Actors.Gender.F,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 1, ActorID = 2, screenName = "Yu Shu Lien"
                                }
                            }
                        }
                    }},

                new Movies() { MovieID = 2, Title = "O Brother, Where Art Thou?", //ReleaseYear = DateTime.Parse("2000"), 
                    RunTime = DateTime.Parse("1:46"), MovieType = Movies.Genres.Comedy.ToString(),
                    actors = new List<Actors>()
                    {
                        new Actors
                        {
                            ActorID = 3, FirstName = "George", Surname = "Clooney",
                            //DOB = DateTime.Parse("06/05/1961"),
                            gender = Actors.Gender.M,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 2, ActorID = 3, screenName = "Ulysses Everett"
                                }
                            }
                        },
                        
                        new Actors
                        {
                            ActorID = 4, FirstName = "John", Surname = "Turturro",
                           // DOB = DateTime.Parse("28/02/1957"), 
                           gender = Actors.Gender.M,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 2, ActorID = 4, screenName = "Pete Hogwallop"
                                }
                            }
                        }
                    }},
                new Movies() { MovieID = 3, Title = "Psycho", //ReleaseYear = DateTime.Parse("1960"),
                    RunTime = DateTime.Parse("2:26"), MovieType = Movies.Genres.Horror.ToString(),
                    actors = new List<Actors>()
                    {
                        new Actors
                        {
                            ActorID = 5, FirstName = "Anthony", Surname = "Perkins",
                            //DOB = DateTime.Parse("04/04/1932"), 
                            gender = Actors.Gender.M,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 3, ActorID = 5, screenName = "Norman Bates"
                                }
                            }
                        },
                        new Actors
                        {
                            ActorID = 6, FirstName = "Janet", Surname = "Leigh",
                            //DOB = DateTime.Parse("06/07/1927"), 
                            gender = Actors.Gender.F,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 3, ActorID = 6, screenName = "Marion Crane"
                                }
                            }
                        }
                    }},
                new Movies(){ MovieID = 4, Title = "The Shawshank Redemption", //ReleaseYear = DateTime.Parse("1994"),
                    RunTime = DateTime.Parse("2:22"), MovieType = Movies.Genres.Drama.ToString(),
                    actors = new List<Actors>()
                    {
                        new Actors
                        {
                            ActorID = 7, FirstName = "Tim", Surname = "Robbins",
                            //DOB = DateTime.Parse("16/10/1958"), 
                            gender = Actors.Gender.M,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 4, ActorID = 7, screenName = "Andy Dufresne"
                                }
                            }
                        },
                        new Actors
                        {
                            ActorID = 8, FirstName = "Morgan", Surname = "Freeman",
                            //DOB = DateTime.Parse("01/06/1937"), 
                            gender = Actors.Gender.M,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 4, ActorID = 8, screenName = "Ellis Boyd Redding"
                                }
                            }
                        }
                    }},
                new Movies(){ MovieID = 5, Title = "Alien", //ReleaseYear = DateTime.Parse("1979"),
                    RunTime = DateTime.Parse("1:57"), MovieType = Movies.Genres.SciFi.ToString(),
                    actors = new List<Actors>()
                    {
                        new Actors
                        {
                            ActorID = 9, FirstName = "Sigourney", Surname = "Weaver",
                            //DOB = DateTime.Parse("08/10/1949"), 
                            gender = Actors.Gender.F,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 5, ActorID = 9, screenName = "Ellen Ripley"
                                }
                            }
                        },
                        new Actors
                        {
                            ActorID = 10, FirstName = "Tom", Surname = "Skerritt",
                            //DOB = DateTime.Parse("25/08/1933"), 
                            gender = Actors.Gender.M,
                            ScreenName = new List<ScreenName>()
                            {
                                new ScreenName()
                                {
                                    MoviesID = 5, ActorID = 10, screenName = "Dallas"
                                }
                            }
                        }
                    }}
            };
                 Movie.ForEach(mov => context.movies.Add(mov));
                 context.SaveChanges();

                base.Seed(context);
            }   
        }   

    public class Movies
    {
        [Key]
        public int MovieID { get; set; }
        [Required] [DisplayName("Title")]
        public string Title { get; set; }
        //[DisplayName("Release Year"), DataType(DataType.Date), 
        // DisplayFormat(DataFormatString = "{0:yyyy}")]
        //public DateTime ReleaseYear { get; set; }
        [DisplayName("Run Time"), DataType(DataType.Time),
         DisplayFormat(DataFormatString = "{0:h:mm tt}")]
        public DateTime RunTime { get; set; }
        public Genres Genre { get; set; }
        public enum Genres { Horror, Comedy, Drama, SciFi, Action, Other }
        [DisplayName("Genre")]
        public string MovieType { get; set; }
        public virtual List<Actors> actors { get; set; }
    }

    public class Actors
    {
        [Key]
        public int ActorID { get; set; }
        [Required] [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required] [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Actor Name")]
        private string FullName { get { return String.Format("{0} {1}", FirstName, Surname); }}
        //[DisplayName("Date Of Birth"), DataType(DataType.Date),
        //DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        //public DateTime DOB { get; set; }
        [DisplayName("Sex")]
        public Gender gender { get; set; }
        public enum Gender { M,F}
        //public virtual Dictionary<int, String> ScreenName { get; set; }
        public Movies Movie { get; set;}
        public virtual List<Movies> movies { get; set; }
        public virtual List<ScreenName> ScreenName { get; set; }
        [NotMapped]
        public virtual List<Movies> actorMovie
        {
            get { return (ScreenName == null) ? null : ScreenName.Select(matr => matr.Movies).ToList(); }
        }
    }

    public class ScreenName
    {
        [Key, Column(Order = 0)]
        public int MoviesID { get; set; }
        [Key, Column(Order = 1)]
        public int ActorID { get; set; }

        [Required]
        [DisplayName("Screen Name")]
        public string screenName { get; set; }
        
        //public virtual Dictionary<int, screenName> CharacterName { get; set; }

        //[ForeignKey("MovieID")]
        public Movies Movies { get; set; }
        //[ForeignKey("ActorID")]
        public Actors Actor { get; set; }

            
    }

    public class FilmsDB : DbContext
    {
        public DbSet<Movies> movies { get; set; }
        public DbSet<Actors> actors { get; set; }
        public DbSet<ScreenName> screenname { get; set; }
        public FilmsDB(): base("FilmConnStrings"){}
    }  
}
