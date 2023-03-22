using BaltaDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaDapper.Controller
{
    public class DefaultController
    {
        public static void Get()
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

        #region Listar Categorias
        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("Select [Id], [Title] from [Category]");

            foreach (var item in categories)
            {
                var categoryName = item.Title;
            }
        }
        #endregion

        #region Categoria Nova
        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "";
            category.Description = "";

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

            //return Ok($"{category.Title}, Foi inserido!");

        }

        #endregion

        #region Categoria Nova
        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "";
            category.Description = "";

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "";
            category2.Description = "";

            var insertSql = @"INSERT INTO [Category]
                        VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var rows = connection.Execute(insertSql, new[] {
            new
            {
                Id = category.Id,
                Title = category.Title,
                Url = category.Url,
                Summary = category.Summary,
                Order = category.Order,
                Description = category.Description,
                Featured = category.Featured
            },
            new {
                Id = category2.Id,
                Title = category2.Title,
                Url = category2.Url,
                Summary = category2.Summary,
                Order = category2.Order,
                Description = category2.Description,
                Featured = category2.Featured
            } 
            });

            // var categories = connection.Query<Category>("Select [Id], [Title] from [Category]");

            //return Ok($"{category.Title}, Foi inserido!");

        }

        #endregion

        #region Atualizar Categoria
        public static void UpdateCategories(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid(""),
                title = ""
            });

            //return Ok($"{rows} registros atualizados!");
        }
        #endregion

        #region Atualizar Muitas Categorias
        public static void UpdateManyCategories(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid(""),
                title = ""
            });

            //return Ok($"{rows} registros atualizados!");
        }
        #endregion

    }
}
