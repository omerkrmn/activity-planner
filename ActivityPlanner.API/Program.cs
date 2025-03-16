using ActivityPlanner.API.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(opt => opt.AddPolicy(name: "MyAllowSpecificOrigins",
    policy => 
    {
        policy.AllowAnyOrigin();
    }
    ));
//builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();  
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
var app = builder.Build();
app.ConfigureExceptionHandler();
app.UseCors("MyAllowSpecificOrigins");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
