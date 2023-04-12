using Blog.Data;
using BlogApiEF.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            //async -> assincrona, dispara paralelamente | await -> aguardar execução
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("categories/{id:int}")]
        public async Task<IActionResult> GetIdAsync(
            [FromServices] BlogDataContext context, [FromRoute] int id) 
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(category);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> PostAsync(
            [FromServices] BlogDataContext context,
            [FromBody] Category category
            )
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Created($"v1/categories/{category.Id}", category);

        }

        [HttpPut("categories/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] BlogDataContext context,
            [FromRoute] int id,
            [FromBody] Category category
            )
        {
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

        [HttpDelete("categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] BlogDataContext context,
            [FromRoute] int id
            )
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound();

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return Ok(category);
        }
    }
}
