
using Blog.Models;
using BlogConsole.Repositories;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string Connection_String = @"Server=localhost,1433;
                          Database=Blog;User ID=SA;Password=lbg@2022";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(@"Server=localhost,1433;
                          Database=Blog;User ID=SA;Password=lbg@2022");
            connection.Open();
            //ReadUsers(connection);
            Readwitch(connection);
            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.Get();
            foreach (var user in users)
                Console.WriteLine(user.Name);
        }  
        public static void Readwitch(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.ReadWithRoles();
            foreach (var user in users)
                foreach(var role in user.Roles)
                    Console.WriteLine($"{user.Name} - {role.Name}");
        }  
        
        public static void ReadUser()
        {

            using (var connection = new SqlConnection(Connection_String))
            {
                var user = connection.Get<User>(1);

                    Console.WriteLine(user.Name);

            }
        }
         
        //public static void CreateUser()
        //{
        //    var user = new User()
        //    {
        //        Name = "Rubens Marques",
        //        Bio = "Analista de Suporte",
        //        Email = "rubensmarques@teste.io",
        //        Image = "https://...",
        //        PasswordHash = "HASH",
        //        Slug = "rubens-marques"                
        //    };

        //    using (var connection = new SqlConnection(Connection_String))
        //    {
        //            connection.Insert<User>(user);

        //            Console.WriteLine("Usuário " + user.Name + " Cadastrado com sucesso!");

        //    }
        //}

        //public static void UpdateUser()
        //{
        //    var user = new User()
        //    {
        //        Id = 2,
        //        Name = "Rubens Marques dos Santos Oliveira",
        //        Bio = "Analista de Suporte",
        //        Email = "rubensmarques@teste.io",
        //        Image = "https://...",
        //        PasswordHash = "HASH",
        //        Slug = "rubens-marques"
        //    };

        //    using (var connection = new SqlConnection(Connection_String))
        //    {
        //        connection.Update<User>(user);

        //        Console.WriteLine("Usuário " + user.Name + " Atualizado com sucesso!");

        //    }
        //}
        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(Connection_String))
            {

                var user = connection.Get<User>(2);

                connection.Delete<User>(user);

                Console.WriteLine("Usuário excluido com sucesso!");

            }
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.Get();
            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }
    }
}
