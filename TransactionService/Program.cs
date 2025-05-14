using Microsoft.EntityFrameworkCore;
using TransactionService.Migrations;
using TransactionService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Bank01Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>(); 
builder.Services.AddScoped<ITypeTransactionsRepository, TypeTransactionsRepository>();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
}
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
