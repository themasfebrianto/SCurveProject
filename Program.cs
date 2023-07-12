using SCurveProject.Services;
using SCurveProject.settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bind the MainDatabaseSettings values to the MainDatabaseSettings class
var mainDatabaseSettings = new MainDatabaseSettings();
builder.Configuration.Bind("MainDatabaseSettings", mainDatabaseSettings);
builder.Services.AddSingleton(mainDatabaseSettings);

// Register the UserService in the dependency injection container
builder.Services.AddScoped<UserService>();

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