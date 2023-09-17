using backend.IServices;
using backend.Services;
using core.DBContext;
using Microsoft.EntityFrameworkCore;

NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

logger.Info("start up demo server");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDemoService, DemoService>();
builder.Services.AddDbContextPool<SqlDBContext>(t =>
{
    t.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConn"));
});



var app = builder.Build();

app.UseMiddleware<backend.Middleware.CorsMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
logger.Info("start up complete demo server");

app.Run();


