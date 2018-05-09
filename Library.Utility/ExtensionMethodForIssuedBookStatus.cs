using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Contracts.Repository;
using Library.Repository;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Library.Contracts.Services;
using Library.Services;

namespace Library.Utility
{
   
    public  enum BookStatus{defaultStatus,returned,notreturned,notreturnedwarning,notreturnedlatewarning};
    public static class ExtensionMethodForIssuedBookStatus
    {  
      

        public static BookStatus ListIssuedBooksWithStatus (this IssuedBook issuedBookObject)
        {
            
            
            var difference = issuedBookObject.ProjectedReturnDate - DateTime.Now;
            BookStatus status=BookStatus.defaultStatus;


          if(difference.TotalDays<=0)
            {
                status = BookStatus.notreturnedlatewarning;
            }
          else if(difference.TotalDays<=2&& difference.TotalDays > 0)
            {
                status = BookStatus.notreturnedwarning;
            }
          else if (difference.TotalDays > 2)
            {
                status = BookStatus.notreturned;
            }

            if (issuedBookObject.ActualReturnDate != null)
            {
                status = BookStatus.returned;
            }
            return status;

        }
    }
}
