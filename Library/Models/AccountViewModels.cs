using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class AccountViewModels
    {
        public class LoginViewModel
        {
            [Required]
            [DisplayName("Enter your Username: ")]
            public string Username { get; set; }

            [Required]
            [DisplayName("Enter your Password: ")]
            public string Password { get; set; }

        }

    }
}