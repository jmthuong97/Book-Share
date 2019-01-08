using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL
{
    public class BookDAO : DBUtils
    {
        private int pageSize = 5;

        // create new book
        public int create(Book book)
        {
            SqlCommand cmd = null;
            int idBook = 0; // number line data inserted
            try
            {
                string sql = "INSERT INTO Book(title, author, ISBN, language, description, tag, idUser) values(@title, @author, @ISBN, @language, @description, @tag, @idUser); SELECT SCOPE_IDENTITY()";
                cmd = new SqlCommand(sql, connection);

                cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = book.title;
                cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = book.author;
                cmd.Parameters.Add("@ISBN", SqlDbType.NVarChar).Value = book.ISBN;
                cmd.Parameters.Add("@language", SqlDbType.NVarChar).Value = book.language;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = book.description;
                cmd.Parameters.Add("@tag", SqlDbType.NVarChar).Value = book.tag;
                cmd.Parameters.Add("@idUser", SqlDbType.NVarChar).Value = book.idUser;

                connection.Open(); // open connect
                idBook = Convert.ToInt32(cmd.ExecuteScalar());
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
            return idBook;
        }

        // query for all
        public List<Book> getBookByCommand(string sqlCommand)
        {
            List<Book> books = new List<Book>();
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
                            Book book = new Book();

                            book.id = reader.GetInt32(0);
                            book.title = reader.GetString(1);
                            book.author = reader.GetString(2);
                            book.ISBN = reader.GetString(3);
                            book.language = reader.GetString(4);
                            book.description = reader.GetString(5);
                            book.tag = reader.GetString(6);
                            book.idUser = reader.GetInt32(8);
                            book.getImage = new CoverBookDAO().getImageByBookID(reader.GetInt32(0));
                            book.getImages = new CoverBookDAO().getBookImages(reader.GetInt32(0));

                            //
                            books.Add(book);
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
            return books;
        }


        // get book by ISBN
        public Book getBookByISBN(string xISBN)
        {
            List<Book> bookList = getBookByCommand("Select * from Book where ISBN = '" + xISBN + "'");
            if (bookList.Count > 0)
                return bookList[0];
            else return null;
        }

        // check book is exists by ISBN
        public bool isBookExisted(string xISBN)
        {
            bool result = true;
            if (getBookByISBN(xISBN) == null)
            {
                result = false;
            }
            return result;
        }

        // For new feed: get newest book upload
        public List<Book> getLastedBook(int page)
        {
            int from = (page - 1) * pageSize + 1;
            int to = page * pageSize;
            string query = "select * from"
                    + " (select *, row_number() over (order by id DESC)"
                    + " as row from Book) result"
                    + " where result.row between " + from + " and " + to;
            return getBookByCommand(query);
        }

        // get Book by ID 
        public Book getBookByBookID(int idBook)
        {
            Book result = null;
            List<Book> bookList = getBookByCommand("Select * from Book where id = '" + idBook + "'");
            if (bookList.Count > 0)
                result = bookList[0];
            return result;
        }

        // For search: tab Name
        public List<Book> getBooksByName(string name, int page)
        {
            int from = (page - 1) * pageSize + 1;
            int to = page * pageSize;
            string query = "select * from "
                    + "(select *, row_number() over (order by id DESC) as row from Book"
                    + " where title LIKE '%" + name + "%') result"
                    + " where result.row between " + from + " and " + to;
            return getBookByCommand(query);
        }

        // For search: tab ISBN
        public List<Book> getBooksByISBN(string ISBN, int page)
        {
            int from = (page - 1) * pageSize + 1;
            int to = page * pageSize;
            string query = "select * from "
                    + "(select *, row_number()  over (order by id DESC) as row from Book"
                    + " where ISBN LIKE '%" + ISBN + "%') result"
                    + " where result.row between " + from + " and " + to;
            return getBookByCommand(query);
        }

        // For search: tab Author
        public List<Book> getBooksByAuthor(string author, int page)
        {
            int from = (page - 1) * pageSize + 1;
            int to = page * pageSize;
            string query = "select * from "
                    + "(select *, row_number() over (order by id DESC) as row from Book"
                    + " where author LIKE '%" + author + "%') result"
                    + " where result.row between " + from + " and " + to;
            return getBookByCommand(query);
        }

        // For search: tab Tag
        public List<Book> getBooksByTag(string tag, int page)
        {
            int from = (page - 1) * pageSize + 1;
            int to = page * pageSize;
            string query = "select * from "
                    + "(select *, row_number() over (order by id DESC) as row from Book"
                    + " where tag LIKE '%" + tag + "%') result"
                    + " where result.row between " + from + " and " + to;
            return getBookByCommand(query);
        }

        // For search: tab All book
        public List<Book> getBook(string queryStr, int page)
        {
            int from = (page - 1) * pageSize + 1;
            int to = page * pageSize;
            string query = "select * from"
                    + " (select distinct * , ROW_NUMBER() over (order by id DESC) as row from"
                    + " (select * from Book where title LIKE '%" + queryStr + "%'"
                    + " union select * from Book where ISBN like '%" + queryStr + "%'"
                    + " union select * from Book where author LIKE '%" + queryStr + "%'"
                    + " union select * from Book where tag LIKE '%" + queryStr + "%') result) final_result"
                    + " where final_result.row between " + from + " and " + to;
            return getBookByCommand(query);
        }

        // For paging: get total of row
        public int getRowCount(string type, string queryStr)
        {
            int pages = 0;
            string sqlCommand = "";
            SqlCommand cmd = null;

            switch (type)
            {
                case "lasted":
                    sqlCommand = "select count(*) from Book";
                    break;
                case "All":
                    sqlCommand = "select count (distinct id) from"
                            + " (select * from Book where title like '%" + queryStr + "%'"
                            + " union select * from Book where ISBN like '%" + queryStr + "%'"
                            + " union select * from Book where author like '%" + queryStr + "%'"
                            + " union select * from Book where tag like '%" + queryStr + "%') result";
                    break;
                case "Title":
                    sqlCommand = "select count (*) from Book where title LIKE '%" + queryStr + "%'";
                    break;
                case "Author":
                    sqlCommand = "select count (*) from Book where author LIKE '%" + queryStr + "%'";
                    break;
                case "ISBN":
                    sqlCommand = "select count (*) from Book where ISBN LIKE '%" + queryStr + "%'";
                    break;
                case "Tag":
                    sqlCommand = "select count (*) from Book where tag LIKE '%" + queryStr + "%'";
                    break;
            }

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
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            return pages;
        }

        // For paging: calculator number of page
        public int getPages(string type, string queryStr)
        {
            int rows = getRowCount(type, queryStr);
            return rows / (pageSize) + ((rows % pageSize) != 0 ? 1 : 0);
        }
    }
}
