using Library.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Contracts.Repository;

namespace Library.Services
{
    public class BookService : Contracts.Services.IBookServices
    {
        Contracts.Repository.IBookRepository BookRepository;
        public BookService(Contracts.Repository.IBookRepository BookRepository)
        {
            this.BookRepository = BookRepository;
        }

        public Book FindBookById(string bookId)
        {
            if (bookId == null)
            {
                return null;
            }
           return BookRepository.FindBookById(bookId);
        }

        public List<Book> ListAllBooks()
        {
            return BookRepository.ListAllBooks();
        }
    }
}
