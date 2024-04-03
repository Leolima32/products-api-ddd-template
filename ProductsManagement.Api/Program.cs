using Microsoft.EntityFrameworkCore;
using ProductsManagement.Application.Interfaces;
using ProductsManagement.Application.Services;
using ProductsManagement.Domain.Interfaces;
using ProductsManagement.Infra;
using ProductsManagement.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<IProductsService, ProductsService>();

builder.Services.AddSqlite<AppDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ProductsManagement.Api"));

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();