using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL
{
    public class TradingDetailsDAO : DBUtils
    {
        private int NOT_AVAILABLE = -1;
        private int AVAILABLE = 0;
        private int PENDING = 1;
        private int LENDING = 2;
        private int COMPLETE = 3;

        //================================= For get data trading ================================= 
        //=============== For lending ===============
        // form get data: same param @idOwner
        public List<TradingDetail> getDataOwner(int idOwner, int status, string sqlCommand)
        {
            List<TradingDetail> tradings = new List<TradingDetail>();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@statusBook", SqlDbType.Int).Value = status;
                cmd.Parameters.Add("@idOwner", SqlDbType.Int).Value = idOwner;

                connection.Open(); // open connect
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TradingDetail t = new TradingDetail();
                            t.id = reader.GetInt32(0);
                            t.bookID = reader.GetInt32(1);
                            t.title = reader.GetString(2);
                            t.createDate = reader.GetDateTime(3).ToString("MM/dd/yyyy");
                            t.status = reader.GetInt32(4);
                            t.userID = reader.GetInt32(5);
                            t.username = reader.IsDBNull(6) ? "N/A" : reader.GetString(6);
                            tradings.Add(t);
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

            return tradings;
        }

        // get all data lending available of owner
        public List<TradingDetail> getAvailableTrading(int idOwner)
        {
            string sqlCommand = "SELECT t.id, t.idBook, b.title, t.createDate, t.statusBook, t.idBorrower, u.username"
                    + " FROM Trading t"
                    + " INNER JOIN Book b on b.id = t.idBook"
                    + " LEFT JOIN [User] u on u.id = t.idBorrower"
                    + " where t.statusBook = @statusBook and t.idOwner = @idOwner ";
            return getDataOwner(idOwner, AVAILABLE, sqlCommand);
        }

        // get all pending book data of the owner
        public List<TradingDetail> getPendingBookOwner(int idOwner)
        {
            string sqlCommand = "SELECT t.id, t.idBook, b.title, t.createDate, t.statusBook, t.idBorrower, u.username"
                    + " FROM Trading t"
                    + " INNER JOIN Book b on b.id = t.idBook"
                    + " LEFT JOIN [User] u on u.id = t.idBorrower"
                    + " where t.statusBook = @statusBook and t.idOwner = @idOwner ";
            return getDataOwner(idOwner, PENDING, sqlCommand);
        }

        // get all lending book data of the owner
        public List<TradingDetail> getLendingBookOwner(int idOwner)
        {
            string sqlCommand = "SELECT t.id, t.idBook, b.title, t.createDate, t.statusBook, t.idBorrower, u.username"
                + " FROM Trading t"
                + " INNER JOIN Book b on b.id = t.idBook"
                + " INNER JOIN [User] u on u.id = t.idBorrower"
                + " where t.statusBook = @statusBook and t.idOwner = @idOwner";
            return getDataOwner(idOwner, LENDING, sqlCommand);
        }

        // get all the books lent successfully of the owner
        public List<TradingDetail> getLendComplete(int idOwner)
        {
            string sqlCommand = "SELECT t.id, t.idBook, b.title, t.createDate, t.statusBook, t.idBorrower, u.username"
                + " FROM Trading t"
                + " INNER JOIN Book b on b.id = t.idBook"
                + " INNER JOIN [User] u on u.id = t.idBorrower"
                + " where t.statusBook = @statusBook and t.idOwner = @idOwner";
            return getDataOwner(idOwner, COMPLETE, sqlCommand);
        }

        //=============== For borrowing ===============
        // form get data: same param @idBorrower
        public List<TradingDetail> getDataBorrower(int idBorrower, int status)
        {
            List<TradingDetail> tradings = new List<TradingDetail>();
            SqlCommand cmd = null;
            try
            {
                string sqlCommand = "SELECT t.id, t.idBook, b.title, t.createDate, t.statusBook, t.idOwner, u.username"
                + " FROM Trading t"
                + " INNER JOIN Book b on b.id = t.idBook"
                + " INNER JOIN [User] u on u.id = t.idOwner"
                + " where t.statusBook = @statusBook and t.idBorrower = @idBorrower";
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@statusBook", SqlDbType.Int).Value = status;
                cmd.Parameters.Add("@idBorrower", SqlDbType.Int).Value = idBorrower;

                connection.Open(); // open connect
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TradingDetail t = new TradingDetail();
                            t.id = reader.GetInt32(0);
                            t.bookID = reader.GetInt32(1);
                            t.title = reader.GetString(2);
                            t.createDate = reader.GetDateTime(3).ToString("MM/dd/yyyy");
                            t.status = reader.GetInt32(4);
                            t.userID = reader.GetInt32(5);
                            t.username = reader.GetString(6);
                            tradings.Add(t);
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

            return tradings;
        }

        // get all pending book data of the borrower
        public List<TradingDetail> getPendingBookBorrower(int idBorrower)
        {
            return getDataBorrower(idBorrower, PENDING);
        }

        // get all book data borrowed by the owner
        public List<TradingDetail> getLendingBookBorrower(int idBorrower)
        {
            return getDataBorrower(idBorrower, LENDING);
        }

        // get all the books borrowed successfully of the owner
        public List<TradingDetail> getBorrowComplete(int idBorrower)
        {
            return getDataBorrower(idBorrower, COMPLETE);
        }
    }
}
