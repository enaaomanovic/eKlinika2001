using eKlinika.Services;
using eKlinika.Services.Context;
using eKlinika.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<PacijentInterface, PacijentService>();
builder.Services.AddTransient<LjekarInterface, LjekarService>();
builder.Services.AddTransient<PrijemPacijentaInterface, PrijemPacijentaService>();
builder.Services.AddTransient<NalazInterface, NalazService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<eKlinikaContext>(options =>
    options.UseSqlServer(connectionString));

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
