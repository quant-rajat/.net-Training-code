using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Contracts.Repository
{
   public interface IBookRepository
    {
        //   void AddBookToRepository();
        Book FindBookById(string bookId);
        List<Book> ListAllBooks();
    }
}
