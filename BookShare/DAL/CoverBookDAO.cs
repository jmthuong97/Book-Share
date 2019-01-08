using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class CoverBookDAO : DBUtils
    {
        private string COVER_BOOK_COVER1 = "/Cover Book/";
        private string COVER_BOOK_COVER2 = "Cover Book/";

        // get the first image book
        public string getImageByBookID(int idBook)
        {
            SqlCommand cmd = null;
            string imageURL = "";
            string sqlCommand = "select TOP 1 [urlImage] from ImageBook"
                    + " where idBook=@idBook";

            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@idBook", SqlDbType.Int).Value = idBook;

                connection.Open(); // open connect

                imageURL = COVER_BOOK_COVER2 + cmd.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return imageURL;
        }

        // get list book image by idbook
        public List<string> getBookImages(int idBook)
        {
            SqlCommand cmd = null;
            List<string> images = new List<string>();
            string sqlCommand = "select * from ImageBook"
                    + " where idBook='" + idBook + "'";

            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                connection.Open(); // open connect

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            images.Add(COVER_BOOK_COVER2 + reader.GetString(1));
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
            return images;
        }

        // insert image book
        public bool insert(ImageBook imgb)
        {
            SqlCommand cmd = null;
            string sqlCommand = "INSERT INTO ImageBook(urlImage, idBook) values('" + imgb.urlImage + "', " + imgb.idBook + ")";
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);

                connection.Open(); // open connect
                return cmd.ExecuteNonQuery() != 0;
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
        }

        // save image to server
        public string uploadImage(string rootPath, string fileName, byte[] bytes)
        {
            string folderPath = string.Format("{0}{1}", rootPath, COVER_BOOK_COVER1);
            string filePath = string.Format("{0}{1}{2}", rootPath, COVER_BOOK_COVER1, fileName);
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
    }

}
