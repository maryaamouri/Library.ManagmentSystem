using Libro.Application.Extensions;
using Libro.Persistence.Extensions;
using Libro.Identity.Extensions;
using Libro.Shared.Extenssions;
using Libro.Application.Common.Absractions;
using Libro.Api.Extenssons;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentityInfrastructure(configuration);
builder.Services.AddPersistence(configuration);
builder.Services.AddShared();
builder.Services.AddAuthentication();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDoc();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseShared();
app.MapControllers();

app.Run();
