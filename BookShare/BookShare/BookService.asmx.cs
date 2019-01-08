using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BookShare
{
    /// <summary>
    /// Summary description for BookService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookService : System.Web.Services.WebService
    {

        [WebMethod]
        public Book checkBookExist(string isbn)
        {
            BookDAO bookdao = new BookDAO();
            if (bookdao.isBookExisted(isbn))
            {
                Book book = bookdao.getBookByISBN(isbn);
                return book;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public int createBook(string ISBN, string title, string author, string tag, string language, string description, int idUser)
        {
            BookDAO dao = new BookDAO();
            Book book = new Book();
            book.title = title;
            book.author = author;
            book.ISBN = ISBN;
            book.language = language;
            book.description = description;
            book.tag = tag;
            book.idUser = idUser;
            return dao.create(book);
        }

        [WebMethod]
        public Book getBookById(int idBook)
        {
            BookDAO dao = new BookDAO();
            return dao.getBookByBookID(idBook);
        }

        [WebMethod]
        public List<Book> searchBook(string query, string filter, int page)
        {
            if (query == null) return null;
            BookDAO dao = new BookDAO();
            List<Book> books = new List<Book>();
            switch (filter)
            {
                case "All":
                    books = dao.getBook(query, page);
                    break;
                case "Title":
                    books = dao.getBooksByName(query, page);
                    break;
                case "Author":
                    books = dao.getBooksByAuthor(query, page);
                    break;
                case "ISBN":
                    books = dao.getBooksByISBN(query, page);
                    break;
                case "Tag":
                    books = dao.getBooksByTag(query, page);
                    break;
            }
            return books;
        }

        [WebMethod]
        public int getTotalPageSearch(string filter, string query)
        {
            BookDAO dao = new BookDAO();
            return dao.getPages(filter, query);
        }


        [WebMethod]
        public void uploadCoverBook(string rootPath, string[] fileName, byte[][] bytes, int idBook)
        {
            CoverBookDAO dao = new CoverBookDAO();

            for (int i = 0; i < 5; i++)
            {
                if (bytes[i] != null && fileName[i] != "")
                {
                    dao.uploadImage(rootPath, fileName[i], bytes[i]);
                    ImageBook imb = new ImageBook() { urlImage = fileName[i], idBook = idBook };
                    dao.insert(imb);
                }
                else
                {
                    ImageBook imb = new ImageBook() { urlImage = "coverbook.jpg", idBook = idBook };
                    dao.insert(imb);
                }
            }
        }

        [WebMethod]
        public List<string> getBookCovers(int idBook)
        {
            CoverBookDAO dao = new CoverBookDAO();
            return dao.getBookImages(idBook);
        }

        [WebMethod]
        public void reviewBook(int idBook, int idUser, string content)
        {
            ReviewBookDAO revewdao = new ReviewBookDAO();
            Review review = new Review();
            review.idBook = idBook;
            review.idUser = idUser;
            review.content = content;

            revewdao.createReviewBook(review);
        }

        [WebMethod]
        public List<Review> getTopReview(int top, int idBook)
        {
            ReviewBookDAO revewdao = new ReviewBookDAO();
            return revewdao.getReviewBookByTop(top, idBook);
        }

    }
}
