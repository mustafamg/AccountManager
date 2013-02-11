using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AccountManagement.Models
{
    public class RegisterEntry
    {
       

        public string Name { get; set; }
        public string Password { get; set; }
         [Key]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public char Gender { get; set; }
        public bool Activated { get; set; }
        
    }
}
