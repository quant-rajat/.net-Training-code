using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Contracts.Services
{
  public  interface IUserServices
    {
        User AuthenticateUser(string userName, string Password);
        List<IssuedBook> UserHistory(string id);
        PagedResults<User> GetAllUser(int page, int rowcount);
        Task<PagedResults<User>> GetAllUserAsync(int page, int rowcount);
    }
}
