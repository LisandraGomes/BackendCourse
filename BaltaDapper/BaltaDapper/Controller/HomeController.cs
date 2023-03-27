using BaltaDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BaltaDapper.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("Consulta")]
        public IActionResult Get()
        {
            const string connectionString = @"Server=localhost,1433;
                          Databae=BaltaRestore;User ID=SA;Password=lbg@2022";

            var category = new Category();

            using (var connection = new SqlConnection(connectionString))
            {
                var categories = connection.Query<Category>("Select [Id], [Title] from [Category]");

                foreach (var item in categories)
                {
                    var categoryName = item.Title;
                }
            }
            return Ok(category);

        }

        #region
        //public static void Post()
        //{
        //    const string connectionString = @"Server=localhost,1433;
        //                  Databae=BaltaRestore;User ID=SA;Password=lbg@2022";

        //    var category = new Category();
        //    category.Id = Guid.NewGuid();
        //    category.Title = "";
        //    category.Description = "";

        //    var insertSql = @"INSERT INTO [Category]
        //                VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Execute(insertSql, new
        //        {
        //           Id = category.Id,
        //           Title = category.Title,
        //           Url = category.Url,
        //           Summary = category.Summary,
        //           Order = category.Order,
        //           Description = category.Description,
        //           Featured = category.Featured
        //        });

        //        // var categories = connection.Query<Category>("Select [Id], [Title] from [Category]");

        //        //return Ok($"{category.Title}, Foi inserido!");
        //    }

        //}
        #endregion
        [HttpGet]
        #region Listar Categorias
        public IActionResult ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("Select [Id], [Title] from [Category]");

            foreach (var item in categories)
            {
                var categoryName = item.Title;
            }
            return Ok(categories);
        }
        #endregion

        #region Categoria Nova
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {           

            category.Id = Guid.NewGuid();
            category.Title = "";
            category.Description = "";
            //var category = new Category(category.Id, category.Title, category.Description);

            var insertSql = @"INSERT INTO [Category]
                        VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var rows = connection.Execute(insertSql, new
            {
                Id = category.Id,
                Title = category.Title,
                Url = category.Url,
                Summary = category.Summary,
                Order = category.Order,
                Description = category.Description,
                Featured = category.Featured
            });

            // var categories = connection.Query<Category>("Select [Id], [Title] from [Category]");

            return Ok($"{category.Title}, Foi inserido!");

        }

        #endregion

        //#region Categoria Nova
        //[HttpPost]
        //public IActionResult CreateManyCategory(SqlConnection connection)
        //{
        //    var category = new Category();
        //    category.Id = Guid.NewGuid();
        //    category.Title = "";
        //    category.Description = "";

        //    var category2 = new Category();
        //    category2.Id = Guid.NewGuid();
        //    category2.Title = "";
        //    category2.Description = "";

        //    var insertSql = @"INSERT INTO [Category]
        //                VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

        //    var rows = connection.Execute(insertSql, new[] {
        //    new
        //    {
        //        Id = category.Id,
        //        Title = category.Title,
        //        Url = category.Url,
        //        Summary = category.Summary,
        //        Order = category.Order,
        //        Description = category.Description,
        //        Featured = category.Featured
        //    },
        //    new {
        //        Id = category2.Id,
        //        Title = category2.Title,
        //        Url = category2.Url,
        //        Summary = category2.Summary,
        //        Order = category2.Order,
        //        Description = category2.Description,
        //        Featured = category2.Featured
        //    }
        //    });

        //    // var categories = connection.Query<Category>("Select [Id], [Title] from [Category]");

        //    return Ok($"{category.Title}, Foi inserido!");

        //}

        //#endregion

        //#region Atualizar Categoria
        //[HttpPut]
        //public IActionResult UpdateCategories(SqlConnection connection)
        //{
        //    var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
        //    var rows = connection.Execute(updateQuery, new
        //    {
        //        id = new Guid(""),
        //        title = ""
        //    });

        //    return Ok($"{rows} registros atualizados!");
        //}
        //#endregion

        //#region Atualizar Muitas Categorias
        //[HttpPut]
        //public IActionResult UpdateManyCategories(SqlConnection connection)
        //{
        //    var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
        //    var rows = connection.Execute(updateQuery, new
        //    {
        //        id = new Guid(""),
        //        title = ""
        //    });

        //    return Ok($"{rows} registros atualizados!");
        //}
        //#endregion
    }
}
