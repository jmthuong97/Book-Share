using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Review
    {
        public int id { get; set; }
        public int idBook { get; set; }
        public int idUser { get; set; }
        public string content { get; set; }
        public DateTime CreateDate { get; set; }
        public string username { get; set; }
    }

    public class Rate
    {
        public int id { get; set; }
        public int idBook { get; set; }
        public int idUser { get; set; }
        public int rate { get; set; }
    }
}
