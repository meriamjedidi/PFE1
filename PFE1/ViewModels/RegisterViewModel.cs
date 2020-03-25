using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFE1.ViewModels
{
    public class RegisterViewModel

    {
        [Key]
        public int idregister { get; set; }
        [Required]
       [EmailAddress]
        public string Email { get; set; }
       [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }

    }
}
