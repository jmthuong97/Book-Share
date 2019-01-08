using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int input =1;


            TradingDAO tr = new TradingDAO();

            Trading a = new Trading();
            a.idOwner = 1;
            a.idBook = 46;

            Console.WriteLine(tr.rejectTrading(3));

            Console.ReadKey();
        }
    }
}
