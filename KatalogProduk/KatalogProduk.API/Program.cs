using KatalogProduk.Data;
using KatalogProduk.Data.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<KatalogProdukContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICategory,CategoryRepo>();
builder.Services.AddScoped<IProduk, ProdukRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrebDb.PrepPopulation(app);

app.Run();
