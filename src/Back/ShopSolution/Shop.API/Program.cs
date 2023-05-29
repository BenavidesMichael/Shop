using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Shop.API.Extentions;
using Shop.API.Middlewares;
using Shop.Application;
using Shop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataBase(builder.Configuration);
builder.Services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
builder.Services.AddCorsExtention();
builder.Services.AddIdentity(builder.Configuration);

builder.Services.AddInfrastructureServiceRegistartion(builder.Configuration);
builder.Services.AddApplicationServiceRegistration();

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    opt.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapControllers();

await app.AddSeed();

app.Run();
