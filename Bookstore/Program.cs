using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Bookstore.Data;
using Bookstore.Data.Repositories;
using Bookstore.Models;
using Bookstore.Services;
using static Bookstore.Data.Repositories.ICRUDRepository;
using static Bookstore.Services.ICrudService;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BookContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICrudRepository<BookItem, int>, BookRepository>();
builder.Services.AddScoped<ICrudService<BookItem, int>, BookService>();




builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookstoreRestAPI",
        Version =
    "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

