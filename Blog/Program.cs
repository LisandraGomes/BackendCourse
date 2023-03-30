using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
 class Program{ 
    private const string Connection_String = @"Server=localhost,1433;
                          Databae=Blog;User ID=SA;Password=lbg@2022";

    public static void ReadUser()
    {
        using(var connection = new SqlConnection(Connection_String))
        {
            var users = connection.GetAll<User>();

            foreach(var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }

 }
 }
