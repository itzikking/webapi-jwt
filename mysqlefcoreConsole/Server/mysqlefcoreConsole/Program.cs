using System;
using System.Text;
using mysqlefcoreConsole;
using mysqlefcoreConsole.Services;
using MySql.Data.MySqlClient.Memcached;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using mysqlefcoreConsole.Models;
using System.Collections.Generic;

namespace mysqlefcore
{
    class Program
    {

        static void Main()
        {
            RunAsync();
        }

        static void RunAsync()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44394/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

    }
}
