using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class UserDAO : DBUtils
    {
        private string AVATAR_FOLDER = "avatar/";

        // Kiểm tra đăng nhập
        public User checkLogin(string username, string password)
        {
            User user = new User();
            SqlCommand cmd = null;

            try
            {
                string sqlCommand = "SELECT * FROM [User] where username = @username";
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

                connection.Open(); // open connect

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(4));
                            if (reader.GetString(5).Equals(password)) // if password is correct
                            {
                                user.id = reader.GetInt32(0);
                                user.fullName = reader.GetString(1);
                                user.birthday = reader.GetDateTime(2);
                                user.avatar = reader.IsDBNull(3) ? null : (AVATAR_FOLDER + reader.GetString(3));
                                user.userName = reader.GetString(4);
                                user.email = reader.GetString(6);
                                user.address = reader.IsDBNull(7) ? null : reader.GetString(7);
                                user.phoneNumber = reader.IsDBNull(8) ? null : reader.GetString(8);
                                user.linkFacebook = reader.IsDBNull(9) ? null : reader.GetString(9);
                                user.userPoint = reader.GetInt32(10);
                                user.createDate = reader.GetDateTime(11);
                            }
                            else return null;
                        }
                    } // not value return, user does not exist
                    else return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return user;
        }

        // Kiểm tra tài khoản và email người dùng (Không trùng với tài khoản hoặc email đã tồn tại)
        public string checkRegistered(string usernameInput, string emailInput)
        {
            SqlCommand cmd = null;

            try
            {
                string sqlCommand = "SELECT * FROM [User]";
                cmd = new SqlCommand(sqlCommand, connection);
                connection.Open(); // open connect

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string email = reader.GetString(6); // Lấy email trong db
                            string username = reader.GetString(4); // Lấy username trong db
                            if (username.Equals(usernameInput))
                            { // so sánh username
                                return "Sorry, This username already has registered ! ";
                            }
                            if (email.Equals(emailInput))
                            { // so sánh email
                                return "Sorry, This email already has registered ! ";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return null; // Thỏa mản đk không trùng tài khoản & email
        }

        // Tạo tài khoản trên hệ thống
        public int create(User user)
        {
            SqlCommand cmd = null;
            int idUser = 0; // number line data inserted
            try
            {
                string sql = "INSERT INTO [User](fullName, birthday, username, password, email, createDate) values(@fullName, @birthday, @username, @password, @email, @createDate) ; SELECT SCOPE_IDENTITY()";
                cmd = new SqlCommand(sql, connection);

                cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = user.fullName;
                cmd.Parameters.Add("@birthday", SqlDbType.Date).Value = user.birthday;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.userName;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = user.password;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = user.email;
                cmd.Parameters.Add("@createDate", SqlDbType.Date).Value = DateTime.Today;

                connection.Open(); // open connect
                idUser = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                cmd.Dispose();
            }
            return idUser;
        }

        // Search account by name
        public List<User> searchUser(string input)
        {
            List<User> users = new List<User>();
            SqlCommand cmd = null;

            try
            {
                string sqlCommand = "SELECT * FROM [User] WHERE fullName like '%@fullName%'";
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = input;

                connection.Open(); // open connect

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User user = new User();
                            user.id = reader.GetInt32(0);
                            user.fullName = reader.GetString(1);
                            user.birthday = reader.GetDateTime(2);
                            user.avatar = reader.IsDBNull(3) ? null : (AVATAR_FOLDER + reader.GetString(3));
                            user.userName = reader.GetString(4);
                            user.email = reader.GetString(6);
                            user.address = reader.IsDBNull(7) ? null : reader.GetString(7);
                            user.phoneNumber = reader.IsDBNull(8) ? null : reader.GetString(8);
                            user.linkFacebook = reader.IsDBNull(9) ? null : reader.GetString(9);
                            user.userPoint = reader.GetInt32(10);
                            user.createDate = reader.GetDateTime(11);
                            //
                            users.Add(user);
                        }
                    } // not value return, user does not exist
                    else return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return users;
        }

        // get user by id 
        public User getUserById(int idUser)
        {
            User user = new User();
            SqlCommand cmd = null;

            try
            {
                string sqlCommand = "SELECT * FROM [User] WHERE id = @id";
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUser;

                connection.Open(); // open connect

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.id = reader.GetInt32(0);
                            user.fullName = reader.GetString(1);
                            user.birthday = reader.GetDateTime(2);
                            user.avatar = reader.IsDBNull(3) ? null : (AVATAR_FOLDER + reader.GetString(3));
                            user.userName = reader.GetString(4);
                            user.email = reader.GetString(6);
                            user.address = reader.IsDBNull(7) ? null : reader.GetString(7);
                            user.phoneNumber = reader.IsDBNull(8) ? null : reader.GetString(8);
                            user.linkFacebook = reader.IsDBNull(9) ? null : reader.GetString(9);
                            user.userPoint = reader.GetInt32(10);
                            user.createDate = reader.GetDateTime(11);
                        }
                    } // not value return, user does not exist
                    else return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return user;
        }

        // save avatar of user
        // save image to server
        public string uploadImage(string rootPath, string fileName, byte[] bytes)
        {
            string folderPath = string.Format("{0}/{1}", rootPath, AVATAR_FOLDER);
            string filePath = string.Format("{0}/{1}{2}{3}", rootPath, AVATAR_FOLDER, Path.DirectorySeparatorChar, fileName);
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (bytes != null) File.WriteAllBytes(filePath, bytes);
            }
            catch (Exception e)
            {
                throw e;
            }
            return filePath;
        }

        // update avatar of user
        public int updateAvatar(string avatar, int idUser)
        {
            SqlCommand cmd = null;
            int row = 0;

            try
            {
                string sqlCommand = "UPDATE [User] set avatar = @avatar where id = @id";
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@avatar", SqlDbType.NVarChar).Value = avatar;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUser;

                connection.Open(); // open connect

                row = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return row;
        }

        // update infomation of user
        public int updateInfo(User user)
        {
            SqlCommand cmd = null;
            int row = 0;

            try
            {
                string sqlCommand = "Update [User] set fullName = @fullName, birthday = @birthday, email = @email, address = @address, phoneNumber = @phoneNumber, linkFacebook = @linkFacebook where id = @id ";
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = user.fullName;
                cmd.Parameters.Add("@birthday", SqlDbType.Date).Value = user.birthday.Date;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = user.email;
                cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = user.address;
                cmd.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = user.phoneNumber;
                cmd.Parameters.Add("@linkFacebook", SqlDbType.NVarChar).Value = user.linkFacebook;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = user.id;

                connection.Open(); // open connect

                row = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return row;
        }

        // check password
        public bool checkPassword(int userId, string oldPass)
        {
            bool check = false;
            SqlCommand cmd = null;
            try
            {
                string sqlCommand = "select count(*) from [User] where id = @id and password = @password";
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = oldPass;

                connection.Open(); // open connect

                check = int.Parse(cmd.ExecuteScalar().ToString()) == 0 ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return check;
        }

        // change password
        public bool changePassword(int userId, string newPass)
        {
            bool check = false;
            SqlCommand cmd = null;
            try
            {
                string sqlCommand = "update [User] set password = @password where id = @id";
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = newPass;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = userId;

                connection.Open(); // open connect

                check = cmd.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return check;
        }

    }
}