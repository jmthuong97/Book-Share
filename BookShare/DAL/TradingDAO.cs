using System.Collections.Generic;
using Entity;
using System.Data.SqlClient;
using System.Data.Common;
using System;
using System.Data;

namespace DAL
{
    public class TradingDAO : DBUtils
    {
        private int pageSize = 5;
        private int NOT_AVAILABLE = -1;
        private int AVAILABLE = 0;
        private int PENDING = 1;
        private int LENDING = 2;
        private int COMPLETE = 3;

        // get newfeed
        public List<Trading> getLastedTrading(int page)
        {
            int from = (page - 1) * pageSize + 1;
            int to = page * pageSize;
            List<Trading> tradings = new List<Trading>();
            string sqlCommand = "select * from"
                + " (select *, row_number() over (order by createDate DESC, id DESC)"
                + " as row from Trading) result"
                + " where result.row between " + from + " and " + to;

            SqlCommand cmd = null;
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
                            Trading trading = new Trading();
                            trading.id = reader.GetInt32(0);
                            trading.idOwner = reader.GetInt32(1);
                            if (!reader.IsDBNull(2)) trading.idBorrower = reader.GetInt32(2);
                            trading.idBook = reader.GetInt32(3);
                            trading.statusBook = reader.GetInt32(4);
                            trading.statusComplete = reader.GetInt32(5) == 1 ? true : false;
                            trading.createDate = reader.GetDateTime(6);
                            if (!reader.IsDBNull(7)) trading.completeDate = reader.GetDateTime(7);
                            trading.getBook = new BookDAO().getBookByBookID(reader.GetInt32(3));
                            trading.getUser = new UserDAO().getUserById(reader.GetInt32(1));
                            tradings.Add(trading);
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


        // get number row data trading
        public int getRowCount()
        {
            string sqlCommand = "select count(*) from Trading";
            SqlCommand cmd = null;
            int pages = 0;
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);

                connection.Open(); // open connect
                pages = int.Parse(cmd.ExecuteScalar().ToString());
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
            return pages;
        }

        // get total page data need show
        public int getPages()
        {
            int rows = getRowCount();
            return rows / (pageSize) + ((rows % pageSize) != 0 ? 1 : 0);
        }

        // create new trading
        public int createTrading(Trading trading)
        {
            SqlCommand cmd = null;
            int idTrading = 0; // number line data inserted
            try
            {
                string sql = "INSERT INTO Trading (idOwner, idBook, createDate) VALUES (@idOwner, @idBook, @createDate) ; SELECT SCOPE_IDENTITY()";
                cmd = new SqlCommand(sql, connection);

                cmd.Parameters.Add("@idOwner", SqlDbType.Int).Value = trading.idOwner;
                cmd.Parameters.Add("@idBook", SqlDbType.Int).Value = trading.idBook;
                cmd.Parameters.Add("@createDate", SqlDbType.Date).Value = DateTime.Today;

                connection.Open(); // open connect
                idTrading = Convert.ToInt32(cmd.ExecuteScalar());
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
            return idTrading;
        }

        public List<Trading> getTradingByIdBook(int idBook, int idOwner)
        {
            List<Trading> tradings = new List<Trading>();
            string sqlCommand = "SELECT * FROM Trading where idBook = @idBook "
                    + "and statusBook = @statusBook and idOwner != @idOwner";

            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@idBook", SqlDbType.Int).Value = idBook;
                cmd.Parameters.Add("@statusBook", SqlDbType.Int).Value = AVAILABLE;
                cmd.Parameters.Add("@idOwner", SqlDbType.Int).Value = idOwner;

                connection.Open(); // open connect

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Trading trading = new Trading();

                            trading.id = reader.GetInt32(0);
                            trading.idOwner = reader.GetInt32(1);
                            if (!reader.IsDBNull(2)) trading.idBorrower = reader.GetInt32(2);
                            trading.idBook = reader.GetInt32(3);
                            trading.statusBook = reader.GetInt32(4);
                            trading.statusComplete = reader.GetInt32(5) == 1 ? true : false;
                            trading.createDate = reader.GetDateTime(6);
                            if (!reader.IsDBNull(7)) trading.completeDate = reader.GetDateTime(7);
                            trading.getBook = new BookDAO().getBookByBookID(reader.GetInt32(3));
                            trading.getUser = new UserDAO().getUserById(reader.GetInt32(1));
                            tradings.Add(trading);
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

        //================================= For action trading ================================= 

        public bool deleteTradingBook(int idTrading)
        {
            SqlCommand cmd = null;
            string sqlCommand = "UPDATE Trading"
                    + " SET statusBook = @statusBook"
                    + " WHERE id = @id";
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@statusBook", SqlDbType.Int).Value = NOT_AVAILABLE;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idTrading;

                connection.Open(); // open connect

                return cmd.ExecuteNonQuery() == 0 ? false : true;
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

        public bool requestTrading(int idTrading, int idBorrower)
        {
            SqlCommand cmd = null;
            string sqlCommand = "UPDATE Trading"
                    + " SET idBorrower = @idBorrower,  statusBook = @statusBook"
                    + " WHERE id = @id";
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@idBorrower", SqlDbType.Int).Value = idBorrower;
                cmd.Parameters.Add("@statusBook", SqlDbType.Int).Value = PENDING;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idTrading;

                connection.Open(); // open connect

                return cmd.ExecuteNonQuery() == 0 ? false : true;
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

        public bool acceptTrading(int idTrading)
        {
            SqlCommand cmd = null;
            string sqlCommand = "UPDATE Trading "
                    + " SET statusBook = @statusBook"
                    + " WHERE id = @id";
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@statusBook", SqlDbType.Int).Value = LENDING;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idTrading;

                connection.Open(); // open connect

                return cmd.ExecuteNonQuery() == 0 ? false : true;
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

        public bool rejectTrading(int idTrading)
        {
            SqlCommand cmd = null;
            string sqlCommand = "UPDATE Trading "
                    + " SET statusBook = @statusBook, idBorrower = 0"
                    + " WHERE id = @id";
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@statusBook", SqlDbType.Int).Value = AVAILABLE;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idTrading;

                connection.Open(); // open connect

                return cmd.ExecuteNonQuery() == 0 ? false : true;
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

        public bool completeTrading(int idTrading)
        {
            SqlCommand cmd = null;
            string sqlCommand = "UPDATE Trading "
                    + " SET statusBook = @statusBook"
                    + " WHERE id = @id";
            try
            {
                cmd = new SqlCommand(sqlCommand, connection);
                cmd.Parameters.Add("@statusBook", SqlDbType.Int).Value = COMPLETE;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idTrading;

                connection.Open(); // open connect

                return cmd.ExecuteNonQuery() == 0 ? false : true;
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

        //=========================================================== END ===========================================================
    }
}
