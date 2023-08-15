using EventsPro.Application.Services;
using EventsPro.Application.Services.Interfaces;
using EventsPro.Persistence.Context;
using EventsPro.Persistence.Persistence;
using EventsPro.Persistence.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("EventProConnectionString");


builder.Services.AddDbContext<EventsProContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers().AddNewtonsoftJson(
    x => x.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IGeneralPersist, GeneralPersist>();
builder.Services.AddScoped<IEventPersist, EventPersist>();
builder.Services.AddCors();
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

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());
app.Run();
