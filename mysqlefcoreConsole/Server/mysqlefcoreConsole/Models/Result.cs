using System;
using System.Collections.Generic;
using System.Text;

namespace mysqlefcoreConsole.Models
{
    public class Result
    {
        public int status { get; set; }
        public string message { get; set; }
        public object autentication { get; set; }
        public object users { get; set; }
        public Result()
        {

        }
    }
}
