using BlogApi.Models;
using BlogApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly string _connectionString;

        public HomeController(IConfiguration configuration)
            => _connectionString = configuration.GetConnectionString("BaltaRestore");

        [HttpGet("Users")]
        public async Task<IActionResult> ReadUsers()
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<User>(connection);
            var users = repository.Get();
            return Ok(users);
        }

        [HttpGet("UsersWithRole")]
        public async Task<IActionResult> Readwitch()
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new UserRepository(connection);
            var users = repository.ReadWithRoles();
            //foreach (var user in users)
            //    foreach (var role in user.Roles)
            //        Console.WriteLine($"{user.Name} - {role.Name}");

            return Ok(users);
        }
        
        [HttpGet("UserRead/{id}")]
        public async Task<IActionResult> ReadUserId(int id)
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<User>(connection);
            var users = repository.Get(id);
            //foreach (var user in users)
            //    foreach (var role in user.Roles)
            //        Console.WriteLine($"{user.Name} - {role.Name}");

            return Ok(users);
        } 
        
        [HttpPost("UserCreate")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<User>(connection);
            repository.CreateModel(user);
            //foreach (var user in users)
            //    foreach (var role in user.Roles)
            //        Console.WriteLine($"{user.Name} - {role.Name}");

            return Ok($"Usuário {user.Name}, criado.");
        }

        //Tag
        [HttpGet("Tag")]
        public async Task<IActionResult> ReadTag()
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<Tag>(connection);
            var tags = repository.Get();
            return Ok(tags);
        }

        [HttpGet("Tag/{id}")]
        public async Task<IActionResult> ReadTagId(int id)
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<Tag>(connection);
            var tag = repository.Get(id);
            return Ok(tag);
        }

        //Category
        [HttpGet("Category")]
        public async Task<IActionResult> ReadCategory()
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<Category>(connection);
            var categories = repository.Get();
            return Ok(categories);
        }

        [HttpGet("Category/{id}")]
        public async Task<IActionResult> ReadCategoryId(int id)
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<Category>(connection);
            var category = repository.Get(id);
            return Ok(category);
        }        

        //Post
        [HttpGet("Post")]
        public async Task<IActionResult> ReadPost()
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<Post>(connection);
            var categories = repository.Get();
            return Ok(categories);
        }

        [HttpGet("Post/{id}")]
        public async Task<IActionResult> ReadPostId(int id)
        {
            var connection = new SqlConnection(_connectionString);
            var repository = new Repository<Post>(connection);
            var category = repository.Get(id);
            return Ok(category);
        }


    }
}
