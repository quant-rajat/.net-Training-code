using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Contracts.Services;
using Library.Contracts.Repository;
using Library.Models;
using System.Data.SqlClient;
using System.Data;

namespace Library.Services
{
    public class UserService: IUserServices
    {
        IUserRepository userRepository;
       
        public UserService(Contracts.Repository.IUserRepository UserRepository)
        {
            this.userRepository = UserRepository;
        }

        public User AuthenticateUser(string userName, string Password)
        {
            if (userName == null || Password == null)
            {
                return null;
            }
           return userRepository.AuthenticateUser(userName,Password);
       
        }

        public PagedResults<User> GetAllUser(int pagenumber,int rowcount)
        {
            if( rowcount==0 )
            {
                return null;
            }
            return userRepository.GetAllUser(pagenumber,rowcount);
           
        }
       async public Task<PagedResults<User>> GetAllUserAsync(int pagenumber, int rowcount)
        {
            if (rowcount <=0||pagenumber<=0)
            {
                return null;
            }
           // await Task.WhenAll(userRepository.GetTotalUserCount(), userRepository.GetAllUserAsync(pagenumber, rowcount));

            Task<int> totalCount=  userRepository.GetTotalUserCount();
            Task<List<User>> userList =  userRepository.GetAllUserAsync(pagenumber, rowcount); 
            PagedResults<User> userListResult = new PagedResults<User>();
            userListResult.PageNumber = pagenumber;
            userListResult.PageSize = rowcount;
            userListResult.TotalRecordCount = await totalCount;
            userListResult.Results =await userList;
            return userListResult;
        }

        

        public List<IssuedBook> UserHistory(string id)
        {
            if (id == null)
            {
                return null;
            }
            return userRepository.UserHistory(id);
            
        }
       
    }
}
