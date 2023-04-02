using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace BlogConsole.Repositories
{
    public class Repository<TModel> where TModel : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<TModel> Get()
            => _connection.GetAll<TModel>();

        public TModel Get(int id)
             => _connection.Get<TModel>(id);

        public void CreateModel(TModel model)
        {
            _connection.Insert<TModel>(model);
        }

        public void UpdateModel(TModel model)
            => _connection.Update<TModel>(model);

        public void DeleteModel(int id)
        {
            if (id != 0)
                return;
            var model = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(model);
        }
    }
}
