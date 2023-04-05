using CRUDWithDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CRUDWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BaltaRestore");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Category WHERE Featured = 1";
                var categories = await sqlConnection.QueryAsync<Category>(sql);

                return Ok(categories);
            }
        }

        [HttpGet("{Title}")]
        public async Task<IActionResult> Get(int id)
        {
            var parameters = new
            { 
                id 
            };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Category Where Id = @id";
                var categories = await sqlConnection.QuerySingleOrDefaultAsync<Category>(sql, parameters);

                if (categories is null)
                    return NotFound("Não encontrado!");
                else
                    return Ok(categories);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            var newcategory = new Category(category.Title, category.Url, category.Summary, category.Description, category.Order);

            var parameters = new
            {
                newcategory.Order,
                newcategory.Title,
                newcategory.Url,
                newcategory.Summary,
                newcategory.Description
            };

            using (var sqlConnection = new SqlConnection(_connectionString)) 
            {
                const string sql = "INSERT INTO Category OUTPUT INSERTED.Id VALUES(@Order, @Title, @Url, @Summary, @Description)";
                var id = await sqlConnection.ExecuteScalarAsync<Category>(sql, parameters);
            }

            return Ok(newcategory);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Category category)
        {
            var parameters = new
            {
                category.Id,
                category.Order,
                category.Title,
                category.Url,
                category.Summary,
                category.Description
            };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Category SET ... WHERE Id = @id";
                await sqlConnection.ExecuteAsync(sql, parameters);
            }

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var parameters = new { id };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Category SET Featured = 0 WHERE Id = @id";
                await sqlConnection.ExecuteAsync(sql, parameters);
            }

            return Ok();

        }
    }
}
