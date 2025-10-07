using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add the database context
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseInMemoryDatabase("ProductsDb"));

// Add the repository
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();

// highlight-start
// ✅ 1. ADD SWAGGER SERVICES HERE
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// highlight-end

var app = builder.Build();

// Configure the HTTP request pipeline.
// highlight-start
// ✅ 2. ADD SWAGGER MIDDLEWARE HERE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// highlight-end

app.UseAuthorization();

app.MapControllers();

app.Run();
