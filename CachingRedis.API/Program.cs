using CachingRedis.API.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.InstallerServicesInAssembly();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options => options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.MapControllers();

app.Run();