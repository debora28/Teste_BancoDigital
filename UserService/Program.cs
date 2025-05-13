using Microsoft.EntityFrameworkCore;
using UserService.CustomValidations;
using UserService.Migrations;
using UserService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BancoContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IValidateCpfCnpj, ValidateCpfCnpj>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

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
