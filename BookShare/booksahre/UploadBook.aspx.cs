using booksahre.BookService;
using booksahre.UserService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace booksahre
{
    public partial class UploadBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // set title for page
            Page.Title = "Upload trading - BookShare";

            if (!IsPostBack)
            {
                if (Session["currentUser"] != null)
                {
                    User user = (User)Session["currentUser"];
                    email.Value = user.email;
                    address.Value = user.address;
                    phonenumber.Value = user.phoneNumber;
                    linkFacebook.Value = user.linkFacebook;
                }
            }
        }

        protected void isbn_TextChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            BookService.BookService service = new BookService.BookService();
            Book book = service.checkBookExist(isbn.Text);
            if (book != null)
            {
                title.Value = book.title;
                author.Value = book.author;
                tag.Value = book.tag;
                language.Value = book.language;
                description.Value = book.description;

                disableInput(true);
                //
                idBookTxt.Value = book.id + "";
            }
            else
            {
                title.Value = "";
                author.Value = "";
                tag.Value = "";
                language.Value = "";
                description.Value = "";

                disableInput(false);
            }
        }

        public void disableInput(bool check)
        {
            title.Disabled = check;
            author.Disabled = check;
            tag.Disabled = check;
            language.Disabled = check;
            description.Disabled = check;
            //
            cover1.Enabled = !check;
            cover2.Enabled = !check;
            cover3.Enabled = !check;
            cover4.Enabled = !check;
            cover5.Enabled = !check;
            //
            isExist.Value = check + "";
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            int idBook = 0;
            int.TryParse(idBookTxt.Value, out idBook);
            if (checkRules.Checked && Session["currentUser"] != null)
            {
                User user = (User)Session["currentUser"];
                TradingService.TradingService tradingService = new TradingService.TradingService();
                BookService.BookService bookService = new BookService.BookService();

                if (bookService.checkBookExist(isbn.Text) == null) // if book not exist then create new book first
                {
                    idBook = bookService.createBook(isbn.Text, title.Value, author.Value, tag.Value, language.Value, description.Value, user.id);
                    uploadCoverBook(user.id, idBook);

                }
                string xx = user.id + "";
                if (idBook != 0)
                {
                    tradingService.createTrading(user.id, idBook);
                    Server.Transfer(string.Format("BookDetails.aspx?id={0}", idBook));
                }
            }
        }

        public void uploadCoverBook(int idUser, int idBook)
        {
            BookService.BookService bookservice = new BookService.BookService();

            int maxSizeFile = 1024 * 1024 * 4;
            byte[][] arrbytes = new byte[5][];
            string[] fileName = new string[5];

            var arr = new FileUpload[] { cover1, cover2, cover3, cover4, cover5 };
            int count = 0;

            foreach (FileUpload file in arr)
            {
                if (file.HasFile && file.FileContent.Length <= maxSizeFile && checkType(Path.GetExtension(file.FileName)))
                {
                    BinaryReader br = new BinaryReader(file.PostedFile.InputStream);
                    byte[] data = br.ReadBytes((int)file.PostedFile.InputStream.Length);
                    arrbytes[count] = data;
                    // 
                    string coverName = string.Format("{0}_{1}_cover{2}{3}", idBook, idUser, count + 1, Path.GetExtension(file.FileName));
                    fileName[count] = coverName;
                    //
                    count++;
                }
            }

            bookservice.uploadCoverBook(Server.MapPath("~"), fileName, arrbytes, idBook);

        }

        public bool checkType(string type)
        {
            if (type.Equals(".jpg") || type.Equals(".png") || type.Equals(".jpeg")) return true;
            else return false;
        }
    }
}