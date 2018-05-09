using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository;
using Library.Contracts.Repository;
using System.Data;
using System.Data.SqlClient;
using Library.Models;
using System.Configuration;

namespace Library.Repository
{
    public class UserRepository:IUserRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //  Instantiate the connection
        SqlConnection connection;
        public UserRepository()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Librarydb"].ConnectionString);
        }
        public User AuthenticateUser(string Username, string Password)
        {
            User user = null;
            try
            {
                SqlCommand cmd = new SqlCommand("stp_AuthenticateUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    user = new User()
                    {
                        Id = (string)rdr["Id"],
                        Username = (string)rdr["email_id"],
                        FirstName = (string)rdr["firstname"],
                        LastName = (string)rdr["lastname"],
                        Created = Convert.ToDateTime(rdr["created"]),
                        Modified = Convert.ToDateTime(rdr["modified"]),
                        Roles = new List<string>()
                        {
                            (string)rdr["roles"]
                        }
                    };
                }
                while (rdr.Read())
                {
                    user.Roles.Add((string)rdr["roles"]);
                }
                


            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return user;
        }
        public PagedResults<User> GetAllUser(int pagenumber,int rowcount)
        {

            List<User> userList = null;
            PagedResults<User> userListResult = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("stp_FetchAllUsersPaged2", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Page", pagenumber);
                sqlCommand.Parameters.AddWithValue("@RowCountPerPage", rowcount);
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    userList = new List<User>();
                    userListResult = new PagedResults<User>();
                }
                while(reader.Read())
                { 
                    userListResult.TotalRecordCount = Convert.ToInt32(reader["total_record_count"]);
                    userListResult.PageSize = Convert.ToInt32(rowcount);
                    userListResult.PageNumber = pagenumber;
                }
            
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        userList.Add(new User()
                        {
                            Id = (string)reader["Id"],
                            Username = (string)reader["email_id"],
                            FirstName = (string)reader["firstname"],
                            LastName = (string)reader["lastname"],
                            Created = Convert.ToDateTime(reader["created"]),
                            Modified = Convert.ToDateTime(reader["modified"])
                        });
                    }
                    userListResult.Results = userList;
                }
              
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return userListResult;
        }

        async public Task<int> GetTotalUserCount()
        {
            int totalCount=0;
            try
            {
                SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["Librarydb"].ConnectionString);
                SqlCommand sqlCommand2 = new SqlCommand("stp_GetTotalUserCount", connection2);
                sqlCommand2.CommandType = CommandType.StoredProcedure;

                // for getting total record count..........

                await connection2.OpenAsync();
                SqlDataReader reader2 = await sqlCommand2.ExecuteReaderAsync();

                if (await reader2.ReadAsync())
                {
                    totalCount = new int();
                    totalCount = (int)reader2["total_record_count"];
                }
               
                    throw new Exception("Zero Total USer count received from sql");
                


            }
            catch (Exception e)
            {
                log.Info(e.Message);
                
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return totalCount;
        }
        async public Task<List<User>> GetAllUserAsync(int pagenumber, int rowcount)
        {
            List<User> userList = null;
                   
            try
            {   // for getting userList from sql db...............
                // Task<SqlDataReader>[] reader = new Task<SqlDataReader>[2];
                SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Librarydb"].ConnectionString);
                SqlCommand sqlCommand1 = new SqlCommand("stp_FetchAllUsersPaged2", connection1);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                sqlCommand1.Parameters.AddWithValue("@Page", pagenumber);
                sqlCommand1.Parameters.AddWithValue("@RowCountPerPage", rowcount);
                await connection1.OpenAsync();




                SqlDataReader reader1  = await sqlCommand1.ExecuteReaderAsync();


                if (reader1.HasRows)
                {
                    userList = new List<User>();
                }
                while (await reader1.ReadAsync())
                {
                    userList.Add(new User()
                    {
                        Id = (string)reader1["Id"],
                        Username = (string)reader1["email_id"],
                        FirstName = (string)reader1["firstname"],
                        LastName = (string)reader1["lastname"],
                        Created = Convert.ToDateTime(reader1["created"]),
                        Modified = Convert.ToDateTime(reader1["modified"])
                    });
                }

            }
            catch (Exception e)
            {
                log.Info(e);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return userList;
            //throw new NotImplementedException();
        }

        /*   public List<User> GetAllUser(int pagenumber, int rowcount)
           {
               List<User> userList = null;

               try
               {
                   SqlCommand sqlCommand = new SqlCommand("stp_FetchAllUsers", connection);
                   sqlCommand.CommandType = CommandType.StoredProcedure;
                   sqlCommand.Parameters.AddWithValue("@Page", pagenumber);
                   sqlCommand.Parameters.AddWithValue("@RowCountPerPage", rowcount);
                   connection.Open();

                   SqlDataReader reader = sqlCommand.ExecuteReader();
                   if(reader.HasRows)
                   {
                       userList = new List<User>();
                   }
                   while (reader.Read())
                   {
                       userList.Add(new User()
                       {
                           Id = (string)reader["Id"],
                           Username = (string)reader["email_id"],
                           FirstName = (string)reader["firstname"],
                           LastName = (string)reader["lastname"],
                           Created = Convert.ToDateTime(reader["created"]),
                           Modified = Convert.ToDateTime(reader["modified"])
                       });

                   }
                   return userList;
               }
               finally
               {
                   if (connection != null)
                   {
                       connection.Close();
                   }
               }
           }*/

        public List<IssuedBook> UserHistory(string Userid)
        {
            List<IssuedBook> books=null;



            try
            {
                SqlCommand cmd = new SqlCommand("stp_UserIssuedBookHistory", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Userid", Userid);
                connection.Open();
                SqlDataReader reader =cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    books = new List<IssuedBook>();
                }
                while (reader.Read())
                {

                    IssuedBook issuedBook = new IssuedBook();

                    //if(reader["actual_return_date"] != DBNull.Value)
                    //{
                    //    issuedBook.ActualReturnDate = Convert.ToDateTime(reader["actual_return_date"]);
                    //}
                    




                    books.Add(new IssuedBook()
                    {
                        BookId = (string)reader["id"],
                        BookCopyId = (string)reader["book_copy_id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Edition = Convert.ToInt32(reader["book_edition"]),
                        IssueDate = Convert.ToDateTime(reader["issue_date"]),
                        ProjectedReturnDate = Convert.ToDateTime(reader["projected_return_date"]),
                        ActualReturnDate = reader["actual_return_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["actual_return_date"])
                            
                    });

                };
             }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return books;
                
       }
    }
}
