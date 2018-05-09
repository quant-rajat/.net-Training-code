using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class IssuedBook
    {
      //  public string UserId { get; set; }
        public string BookId { get; set; }
        public string Title { get; set; }
        public string BookCopyId { get; set; }
        public string Author { get; set; }
        public Int32 Edition { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ProjectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
       
    }
}
