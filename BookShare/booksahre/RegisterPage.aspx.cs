using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace booksahre
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // set title for page
            Page.Title = "Register - BookShare";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            UserService.UserService service = new UserService.UserService();
            string username = Request.Form["username"];
            string email = Request.Form["email"];
            string fullname = Request.Form["fullname"];
            string password = Request.Form["password"];
            DateTime birthOfDate = DateTime.ParseExact(Request.Form["birthOfDate"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string message = service.register(username, email, fullname, password, birthOfDate);
            if (message != null)
            {
                errorTxt.Text = message;
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
        }
    }
}