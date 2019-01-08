using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Book
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string ISBN { get; set; }
        public string language { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public bool status { get; set; }
        public string getImage { get; set; }
        public List<string> getImages { get; set; }
    }

    public class ImageBook
    {
        public int id { get; set; }
        public string urlImage { get; set; }
        public int idBook { get; set; }
    }
}
