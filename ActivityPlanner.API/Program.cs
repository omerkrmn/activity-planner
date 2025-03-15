using ActivityPlanner.API.Extensions;
using ActivityPlanner.Repositories.Contracts.RepositoryContracts;
using ActivityPlanner.Repositories.EFcore;
using ActivityPlanner.Services.Contracts;
using ActivityPlanner.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<ISubscriberService, SubscriberService>();
builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureIdentity();
var app = builder.Build();
app.ConfigureExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
