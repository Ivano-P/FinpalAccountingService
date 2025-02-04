
using FinpalAccountingService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use Pomelo's MySQL provider (compatible with MariaDB)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration["DbConnectionString"]!, 
        new MySqlServerVersion(new Version(10, 4, 34)) // Change version to match your MariaDB version
    ));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
