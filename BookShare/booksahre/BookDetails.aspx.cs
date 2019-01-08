using booksahre.BookService;
using booksahre.UserService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace booksahre
{
    public partial class BookDetails : System.Web.UI.Page
    {
        public User user;
        public int idBook;
        public Book book;
        public List<string> covers;
        public List<TradingService.Trading> tradings;
        public DateTime currentDate = DateTime.Today;
        public List<Review> reviews;
        public string rootPath;

        protected void Page_Load(object sender, EventArgs e)
        {
            // set title for page
            Page.Title = "Book Details - BookShare";

            if (Request.QueryString["id"] == null || Session["currentUser"] == null)
            {
                Server.Transfer("ErrorPage.aspx");
            }
            else
            {
                user = (User)Session["currentUser"];
                int.TryParse(Request.QueryString["id"], out idBook); // get idbook
                BookService.BookService bookservice = new BookService.BookService();
                TradingService.TradingService tradingservice = new TradingService.TradingService();

                book = bookservice.getBookById(idBook);
                tradings = tradingservice.getTradingByIdBook(idBook, user.id).ToList();

                covers = bookservice.getBookCovers(idBook).ToList();
                rootPath = Request.ApplicationPath;

                updateReview(10);
            }
        }

        public void updateReview(int top)
        {
            BookService.BookService bookservice = new BookService.BookService();
            reviews = bookservice.getTopReview(top, idBook).ToList();
        }

        protected void selectTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            int top = int.Parse(selectTop.SelectedItem.Value);
            updateReview(top);
        }

        protected void sendReview_Click(object sender, EventArgs e)
        {
            BookService.BookService bookservice = new BookService.BookService();
            bookservice.reviewBook(idBook, user.id, contentReview.Value);
            contentReview.Value = "";
            System.Threading.Thread.Sleep(500);
            int top = int.Parse(selectTop.SelectedItem.Value);
            updateReview(top);
        }
    }
}