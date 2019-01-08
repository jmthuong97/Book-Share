using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace BookShare
{
    /// <summary>
    /// Summary description for TradingService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TradingService : System.Web.Services.WebService
    {
        TradingDAO tradingdao = new TradingDAO();

        [WebMethod]
        public List<Trading> NewFeed(int page)
        {
            int numPage = tradingdao.getPages();
            page = page > numPage ? numPage : page;
            List<Trading> tradings = tradingdao.getLastedTrading(page);
            return tradings;
        }

        [WebMethod]
        public int getPages()
        {
            return tradingdao.getPages();
        }

        [WebMethod]
        public int createTrading(int idOwner, int idBook)
        {
            Trading trading = new Trading() { idOwner = idOwner, idBook = idBook };
            return tradingdao.createTrading(trading);
        }

        [WebMethod]
        public List<Trading> getTradingByIdBook(int idBook, int idOwner)
        {
            return tradingdao.getTradingByIdBook(idBook, idOwner);
        }

        //===================================== for manager trading details=====================================
        [WebMethod]
        public List<TradingDetail> getListBorrow(string type, int userId)
        {
            List<TradingDetail> tradings = new List<TradingDetail>();
            TradingDetailsDAO tradingdao = new TradingDetailsDAO();

            switch (type)
            {
                case "Pending":
                    tradings = tradingdao.getPendingBookBorrower(userId);
                    break;
                case "Borrowing":
                    tradings = tradingdao.getLendingBookBorrower(userId);
                    break;
                case "Complete":
                    tradings = tradingdao.getBorrowComplete(userId);
                    break;
            }

            return tradings;
        }

        [WebMethod]
        public List<TradingDetail> getListLend(string type, int userId)
        {
            List<TradingDetail> tradings = new List<TradingDetail>();
            TradingDetailsDAO tradingdao = new TradingDetailsDAO();

            switch (type)
            {
                case "Available":
                    tradings = tradingdao.getAvailableTrading(userId);
                    break;
                case "Pending":
                    tradings = tradingdao.getPendingBookOwner(userId);
                    break;
                case "Lending":
                    tradings = tradingdao.getLendingBookOwner(userId);
                    break;
                case "Complete":
                    tradings = tradingdao.getLendComplete(userId);
                    break;
            }

            return tradings;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool doActionTrading(string method, int idTrading)
        {
            TradingDAO tradingdao = new TradingDAO();
            switch (method)
            {
                case "Delete": //Delete
                    return tradingdao.deleteTradingBook(idTrading);
                case "Accept": //Accept
                    return tradingdao.acceptTrading(idTrading);
                case "Reject": //Reject
                    return tradingdao.rejectTrading(idTrading);
                case "Complete": //Complete
                    return tradingdao.completeTrading(idTrading);
            }
            return false;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool doBorrowBook(int idTrading, int idUser)
        {
            TradingDAO tradingdao = new TradingDAO();
            return tradingdao.requestTrading(idTrading, idUser);
        }

    }
}
