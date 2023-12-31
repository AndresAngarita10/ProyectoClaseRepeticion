using System.Reflection;
using API.Extensions;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//-------
//-----------
//------------------
//------------------------------
builder.Services.AddControllers(options => 
    {
        options.RespectBrowserAcceptHeader = true;
        
    }).AddXmlSerializerFormatters();

//--------------------------------////////////////
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-------
//-----------
//------------------
//------------------------------
builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices();//-----------------
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureRateLimiting();//Confiurar Rate Limiting
builder.Services.ConfigureApiVersioning();//Configurar extension de versiones
builder.Services.AddDbContext<ApiIncidenciasContext>(Options =>{
    string connectionString = builder.Configuration.GetConnectionString("ConexMysql");
    Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});







//---------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//-----
//----------
//------------------

app.UseCors("CorsPolicy");
app.UseIpRateLimiting();//usar el Rate Limiting

//----------------------------------------

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
