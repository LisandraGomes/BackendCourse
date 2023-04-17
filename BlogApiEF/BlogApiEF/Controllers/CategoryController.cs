using Blog.Data;
using BlogApiEF.Models;
using BlogApiEF.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BlogApiEF.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("categories")] // API Rest -> Sempre no minusculo e sempre no plural, não precisa colocar a barra
        public async Task<IActionResult> GetAsync(
            [FromServices] BlogDataContext context)
        {
            try
            {
                //async -> assincrona, dispara paralelamente | await -> aguardar execução
                var categories = await context.Categories.ToListAsync();
                return Ok(categories);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "05G01 - Falha interna no Servidor.");
            }
        }

        [HttpGet("categories/{id:int}")]
        public async Task<IActionResult> GetIdAsync(
            [FromServices] BlogDataContext context, [FromRoute] int id) 
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05G00 - Falha no Servidor.");
            }
        }

        [HttpPost("categories")]
        public async Task<IActionResult> PostAsync(
            [FromServices] BlogDataContext context,
            [FromBody] CreateCategoryViewModel category
            )
        {
            try
            {
                var newCategory = new Category()
                { 
                    Id = 0,
                    Name = category.Name,
                    Slug= category.Slug.ToLower(),
                    Posts = null
                };
                await context.Categories.AddAsync(newCategory);
                await context.SaveChangesAsync();
                return Created($"v1/categories/{newCategory.Id}", newCategory);
            }
            catch (DbUpdateException ex) {
                return StatusCode(500, "05I01 - Não foi possível incluir a categoria.");
            }
            catch (Exception ex) {
                return StatusCode(500, "05I02 - Falha interna no Servidor.");
            }
        }

        [HttpPut("categories/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] BlogDataContext context,
            [FromRoute] int id,
            [FromBody] Category category
            )
        {
            try { 
            var upcategory = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            
            if (upcategory == null)
                return NotFound();

            upcategory.Name = category.Name;
            upcategory.Slug = category.Slug;
            
            context.Categories.Update(upcategory);
            await context.SaveChangesAsync();

            upcategory = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05U01 - Não foi possível incluir a categoria.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05U02 - Falha interna no Servidor.");
            }
        }

        [HttpDelete("categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] BlogDataContext context,
            [FromRoute] int id
            )
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return NotFound();

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok($"Categoria {category.Name}, excluída.");
            }
            catch(DbException ex) {
                return StatusCode(500, "05D01 - Não foi possível realizar a exclusão, favor verifique a ação e tente novamente.");
            }
            catch(Exception ex) 
            {
                return StatusCode(500, "05D02 -  Falha no Servidor.");
            }
        }
    }
}
