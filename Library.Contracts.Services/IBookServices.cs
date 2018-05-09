using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Contracts.Services
{
    public interface IBookServices
    {
        Book FindBookById(string bookId);
        List<Book> ListAllBooks();
        
    }
}
