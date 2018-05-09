using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Contracts.Repository
{
    public interface IUserRepository
    {
        User AuthenticateUser(string Username, string Password);
        List<IssuedBook> UserHistory(string id);
        PagedResults<User> GetAllUser(int page, int rowcount);
        Task<List<User>> GetAllUserAsync(int page, int rowcount);
        Task<int> GetTotalUserCount();
   

    }
}
