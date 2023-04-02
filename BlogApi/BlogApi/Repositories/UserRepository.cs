using BlogApi.Models;
using Dapper;
using System.Data.SqlClient;

namespace BlogApi.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;


        public List<User> ReadWithRoles()
        {
            var query = @"SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();
            //estrutura One To many
            var items = _connection.Query<User, Role, User>(
                    query,
                    (user, role) =>
                    {
                        //verifica se existe
                        var usr = users.FirstOrDefault(x => x.Id == user.Id);
                        //adiciona
                        if (usr == null)
                        {
                            usr = user;
                            if(role != null)
                                usr.Roles.Add(role);
                            users.Add(usr);
                        }
                        else
                            usr.Roles.Add(role);

                        //obrigatorio retornar usuario
                        return user;
                    }, 
                    splitOn: "Id");

            return users;
        }
    }
}
