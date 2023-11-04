using Microsoft.EntityFrameworkCore;
using EvaluacionTecnica.Negocio.dbContext;
using EvaluacionTecnica.Negocio.dbContext.Repository;
using EvaluacionTecnica.Negocio.dbContext.Interfaces.UsuarioRepo;
using EvaluacionTecnica.Negocio.dbContext.Interfaces.RoleRepo;
using EvaluacionTecnica.Presentacion.Services.Interfaces;
using EvaluacionTecnica.Presentacion.Services;

var builder = WebApplication.CreateBuilder(args);
var Cors = "Cors";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EvaluacionTecnicaDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("defaulConnection"));
});



builder.Services.AddScoped<IUserRepository, UsuarioRepository>();
builder.Services.AddScoped<IUserServices, UsuarioService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleServices, RoleService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: Cors, builder =>
    {
        builder.WithOrigins("*");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
}//
);


var app = builder.Build();
app.UseCors(Cors);
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
