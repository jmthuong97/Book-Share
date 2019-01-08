using booksahre.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace booksahre
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // set title for page
            Page.Title = "Change password - BookShare";

            if (Session["username"] == null) Response.Redirect("Login.aspx");
        }

        protected void changeBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["currentUser"];
            UserService.UserService userservice = new UserService.UserService();

            string oldPassword = Request.Form["oldPassword"];
            string newPasswrod = Request.Form["password"];

            if (userservice.changePassword(user.id, oldPassword, newPasswrod)) Response.Redirect("Profile.aspx");
            else
            {
                errorTxt.Text = "Old password is incorrect ! Try again !";
            }
        }
    }
}