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
        public async Task<IActionResult> Get(string Title)
        {
            var parameters = new
            { 
                Title 
            };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Category Where Lower(Title) like Lower('%@Title%')";
                var categories = await sqlConnection.QueryAsync<Category>(sql, parameters);

                return Ok(categories);
            }
        }
    }
}
