using Entity;
using System;
using System.Drawing;

namespace booksahre
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // set title for page
            Page.Title = "Login - BookShare";

            if (Session["username"] != null && Request.QueryString["command"] != null)
            {
                Session.RemoveAll();
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            UserService.UserService service = new UserService.UserService();
            UserService.User user = service.checkLogin(Request.Form["usernameTxt"], Request.Form["passwordTxt"]);

            if (user == null) errorTxt.Text = "Username or Password is incorrect";
            else
            {
                errorTxt.Text = user.fullName;
                Session.Add("currentUser", user);
                Session.Add("username", user.userName);
                Response.Redirect("Home.aspx");
            }
        }
    }
}