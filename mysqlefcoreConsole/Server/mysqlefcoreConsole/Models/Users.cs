using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mysqlefcoreConsole.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string password { get; set; }
        public string username { get; set; }

        public Users()
        {

        }
    }
}
