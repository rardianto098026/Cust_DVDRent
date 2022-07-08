using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cust_DVDRent.Models
{
    public class HomeDVDModels
    {
        public class HomeIndex
        {
            public string ID { get; set; }
            public string AgeRating { get; set; }
            public string[] GenreList { get; set; }
            public string Genre { get; set; }
            public string Title { get; set; }
            public string PictureUrl { get; set; }
            public string Duration { get; set; }
            public string ReleaseYear { get; set; }
        }

        public class HomeIndex<T>
        {
            public IEnumerable<T> listMovieAvailable { get; set; }
            //public List<T> listGenre { get; set; }
            //public string PictureURL { get; set; }
            //public string TrailerURL { get; set; }
        }
    }
}