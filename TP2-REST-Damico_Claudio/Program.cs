using Microsoft.EntityFrameworkCore;
using TP2_REST_AccesData.Commands;
using TP2_REST_AccesData.Data;
using TP2_REST_Aplication.Services;
using TP2_REST_Domain.Commands;

var builder = WebApplication.CreateBuilder(args);

// This method gets called by the runtime. Use this method to add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<LibreriaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Repository
builder.Services.AddTransient<ILibrosRepository, LibrosRepository>();
builder.Services.AddTransient<ILibrosService, LibroService>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClientesService, ClienteService>();

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
