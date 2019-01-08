using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace BookShare
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        [WebMethod]
        public User checkLogin(string username, string password)
        {
            UserDAO userdao = new UserDAO();
            return userdao.checkLogin(username, password);
        }

        [WebMethod]
        public string register(string username, string email, string fullname, string password, DateTime date)
        {
            UserDAO userdao = new UserDAO();
            string message = userdao.checkRegistered(username, email);
            if (message == null)
            {
                User user = new User() { userName = username, email = email, fullName = fullname, password = password, birthday = date };
                return userdao.create(user) == 0 ? "Account creation error! retry" : null;
            }
            else
            {
                return message;
            }
        }

        [WebMethod]
        public User getUserById(int id)
        {
            UserDAO userdao = new UserDAO();
            return userdao.getUserById(id);
        }

        [WebMethod]
        public string updateAvatar(string rootPath, string filename, int idUser, byte[] bytes)
        {
            UserDAO userdao = new UserDAO();
            string a = userdao.uploadImage(rootPath, filename, bytes);
            userdao.updateAvatar(filename, idUser);
            return a;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool upadteInformation(int idUser, string fullname, string birthday, string email, string address, string phone, string linkFacebook)
        {
            UserDAO userdao = new UserDAO();
            User user = new User() { id = idUser, fullName = fullname, birthday = DateTime.Parse(birthday), email = email, address = address, phoneNumber = phone, linkFacebook = linkFacebook };
            return userdao.updateInfo(user) == 0 ? false : true;
        }

        [WebMethod]
        public bool changePassword(int userId, string oldPass, string newPass)
        {
            UserDAO userdao = new UserDAO();
            if (userdao.checkPassword(userId, oldPass))
            {
                return userdao.changePassword(userId, newPass);
            }
            else return false;
        }
    }
}
