using Blog.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//configura o comportamento(behavior) da api, suprimindo
//a validação automatica, desativando a validação automatica do ModelState
builder.Services.AddControllers().ConfigureApiBehaviorOptions( options =>
{
    options.SuppressModelStateInvalidFilter = true;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDataContext>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
