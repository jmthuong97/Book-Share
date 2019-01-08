using System;
using System.Collections.Generic;
using System.Linq;

namespace booksahre
{
    public partial class Home : System.Web.UI.Page
    {
        public int pages = 99;
        public int page = 1;
        public List<TradingService.Trading> tradings;
        public string rootPath;
        //public TradingService.Trading[] tradings;

        protected void Page_Load(object sender, EventArgs e)
        {
            // set title for page
            Page.Title = "Home page - BookShare";

            TradingService.TradingService service = new TradingService.TradingService();

            // get page in hype link
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"], out page);
            }

            pages = service.getPages(); // total trading page
            tradings = service.NewFeed(page).ToList(); // get data trading

            rootPath = Request.ApplicationPath;

        }
    }
}