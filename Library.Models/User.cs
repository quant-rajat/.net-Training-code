using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class User
    {
        
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public List<string> Roles { get; set; }
    }
}
