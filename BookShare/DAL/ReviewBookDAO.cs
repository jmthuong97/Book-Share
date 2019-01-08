using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ReviewBookDAO : DBUtils
    {
        // Tạo review book mới
        public int createReviewBook(Review review)
        {
            string sqlCommand = "INSERT INTO [ReviewBook](idBook, idUser, content, createDate) values(@idBook, @idUser, @content, @createDate)";
            int idReview = 0;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);

                cmd.Parameters.Add("@idBook", SqlDbType.Int).Value = review.idBook;
                cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = review.idUser;
                cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = review.content;
                cmd.Parameters.Add("@createDate", SqlDbType.Date).Value = DateTime.Today;

                connection.Open(); // open connect
                idReview = Convert.ToInt32(cmd.ExecuteScalar());
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

            return idReview;
        }

        // Lấy ra top input review book gần nhất
        public List<Review> getReviewBookByTop(int top, int idBook)
        {
            string sqlCommand = "select TOP " + top + " r.*, u.username from ReviewBook r, [User] u where r.idUser=u.id and r.idBook = @idBook order by r.id desc";
            List<Review> reviews = new List<Review>();
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@idBook", SqlDbType.Int).Value = idBook;

                connection.Open(); // open connect

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Review review = new Review();
                            review.id = reader.GetInt32(0);
                            review.idBook = reader.GetInt32(1);
                            review.idUser = reader.GetInt32(2);
                            review.content = reader.GetString(3);
                            review.CreateDate = reader.GetDateTime(4);
                            review.username = reader.GetString(5);
                            reviews.Add(review);
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

                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                cmd.Dispose();
            }

            return reviews;
        }
    }
}
