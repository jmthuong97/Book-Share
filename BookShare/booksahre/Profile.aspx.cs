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
    public partial class Profile : System.Web.UI.Page
    {
        public bool readOnly = true;
        public User viewUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            // set title for page
            Page.Title = "Profile - BookShare";

            int idUser = 0;

            if (Request.QueryString["id"] == null)
            {
                if (checkCurrentUser() != 0)
                {
                    idUser = checkCurrentUser();
                    readOnly = false;
                }
            }
            else
            {
                int.TryParse(Request.QueryString["id"], out idUser);
                readOnly = checkCurrentUser() == idUser ? false : true;
            }

            UserService.UserService userservice = new UserService.UserService();
            viewUser = userservice.getUserById(idUser);

        }

        public int checkCurrentUser()
        {
            int id = 0;
            if (Session["currentUser"] != null)
            {
                User user = (User)Session["currentUser"];
                id = user.id;
            }
            return id;
        }

        protected void uploadAvatar_Click(object sender, EventArgs e)
        {
            int maxSizeFile = 1024 * 1024 * 4;

            if (avatar.FileContent.Length > maxSizeFile)
            {
                errorUpload.Text = "The upload avatar must be less than 4mb !";
            }
            else if (checkType(Path.GetExtension(avatar.FileName)) == false)
            {
                errorUpload.Text = "The upload avatar must be an image !";
            }
            else if (Session["currentUser"] != null)
            {
                User user = (User)Session["currentUser"];
                UserService.UserService userservice = new UserService.UserService();

                BinaryReader br = new BinaryReader(avatar.PostedFile.InputStream);
                byte[] bytes = br.ReadBytes((int)avatar.PostedFile.InputStream.Length);

                string filename = string.Format("{0}{1}", user.userName, Path.GetExtension(avatar.FileName));
                userservice.updateAvatar(Server.MapPath("~"), filename, user.id, bytes);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        public bool checkType(string type)
        {
            if (type.Equals(".jpg") || type.Equals(".png") || type.Equals(".jpeg")) return true;
            else return false;
        }
    }
}