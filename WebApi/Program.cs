using Domain.Interfaces.Generics;
using Domain.Interfaces.ICategory;
using Domain.Interfaces.IDespise;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IServices;
using Domain.Interfaces.IUserFinancialSystem;
using Domain.Services;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();


// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(GenericInterface<>), typeof(GenericsRepositories<>));
builder.Services.AddSingleton<CategoryInterface, CategoryRepository>();
builder.Services.AddSingleton<DespiseInterface, DespiseRepository>();
builder.Services.AddSingleton<FinancialSystemInterface, FinancialSystemRepository>();
builder.Services.AddSingleton<UserFinancialSystemInterface, UserFinancialSystemRepository>();

// SERVIÇO DOMINIO
builder.Services.AddSingleton<IServiceCategory, ServiceCategory>();
builder.Services.AddSingleton<IServiceDespise, ServiceDespise>();
builder.Services.AddSingleton<IServiceFinancialSystem, ServiceFinancialSystem>();
builder.Services.AddSingleton<IServiceUserFinancialSystem, ServiceUserFinancialSystem>();


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
