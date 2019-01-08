using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Trading
    {
        public int id { get; set; }
        public int idOwner { get; set; }
        public int idBorrower { get; set; }
        public int idBook { get; set; }
        public int statusBook { get; set; }
        public bool statusComplete { get; set; }
        public DateTime createDate { get; set; }
        public DateTime completeDate { get; set; }
        public Book getBook { get; set; }
        public User getUser { get; set; }
    }

    public class TradingDetail
    {
        public int id { get; set; }
        public int bookID { get; set; }
        public string title { get; set; }
        public string createDate { get; set; }
        public int status { get; set; }
        public int userID { get; set; }
        public string username { get; set; }
    }
}
