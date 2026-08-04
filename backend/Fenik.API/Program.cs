using Fenik.API;

var builder = WebApplication.CreateBuilder(args);

//create logs folder for serilog
var logPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "app-data", "logs");
if(!Directory.Exists(logPath))
{
    Directory.CreateDirectory(logPath);
}

builder.Services.AddBackEndServices(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
