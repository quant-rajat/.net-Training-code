using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Contracts.Repository;
using System.Data.SqlClient;
using Library.Models;
using System.Data;
using System.Configuration;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Librarydb"].ConnectionString);
       
        
        /*---------A Method for finding books by getting Bookid parameter-----*/

        public Book FindBookById(string bookId)
        {
           Book book = null;
           try
                {
                 SqlCommand command = new SqlCommand("stp_FindBooksById", connection);
                 command.CommandType = CommandType.StoredProcedure;          //setting  commandtype  storedprocedure
                command.Parameters.AddWithValue("@Id", bookId);
                /*---------connection Open to sql server ----------*/
                connection.Open();
                //Reading data from sql by executing query with sqlreader
                SqlDataReader reader = command.ExecuteReader();
                
                    if (reader.Read())
                    {
                        book = new Book()
                        {
                            Id = (string)reader["id"],
                            Title = (string)reader["title"],
                            Isbn = (string)reader["isbn"],
                            Author = (string)reader["author"],
                            Publisher = (string)reader["publisher"]

                        };
                    }
                }
             finally
                {
                    if(connection!=null)
                    connection.Close();
                }

            return book; //return the book if found in Library repository
            
        }


        /*---------Method for listing All books present in the library database in server-------*/
        public List<Book> ListAllBooks()
        {
            // connection object init
            // command object
            // conn open
            // handle empty result set
            
            //list 
            List<Book> bookList = null;

            try
            {                
                /* --------it uses stored procedure named stp_ListAllBooks in sql server-------*/
                SqlCommand command = new SqlCommand("stp_ListAllBooks", connection);
                command.CommandType = CommandType.StoredProcedure;                  //setting commandtype to storedprocedure
                connection.Open();                                                  // connection open to sql
                SqlDataReader reader = command.ExecuteReader();                     // sqlreader stores the executed query results 
                while (reader.Read())
                    {
                     bookList.Add(new Book()
                        {
                         Id = (string)reader["id"],
                         Title = (string)reader["title"],
                         Isbn = (string)reader["isbn"],
                         Author = (string)reader["author"],
                         Publisher = (string)reader["publisher"],
                         Total_Copy = Convert.ToInt32(reader["total_copy"])
                         });
                    }

            }
            finally
            {
                if(connection!=null)
                {
                    connection.Close(); // closing connection if not closed earlier...
                }   
            }

            return bookList;    // returning list of books
        }

    }
}
