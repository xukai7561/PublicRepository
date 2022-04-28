using EFCore;
using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Zack.Commons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreTest", Version = "v1" });
    c.AddServer(new OpenApiServer()
    {
        Url = "",
        Description = "vvv"
    });
    c.CustomOperationIds(apiDesc =>
    {
        var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
        return controllerAction.ControllerName + "-" + controllerAction.ActionName;
    });
    var filePath = Path.Combine(AppContext.BaseDirectory, "AspNetCoreTest.xml");
    //c.IncludeXmlComments(filePath, true);
});

//var assem = new Assembly[] { Assembly.Load("EFCore") };//加载特定的程序集
var assem = ReflectionHelper.GetAllReferencedAssemblies();
builder.Services.AddAllDbContexts(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetSection("ConnectStr").Value);
}, assem);
//builder.Services.AddDbContext<MyDbContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectStr"));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseKnife4UI(c =>
    {
        c.RoutePrefix = string.Empty; ; // serve the UI at root
        c.SwaggerEndpoint("/v1/api-docs", "AspNetCoreTest v1");
    });

    //app.UseEndpoints(endpoints =>
    //{
    //    endpoints.MapControllers();
    //    endpoints.MapSwagger("{documentName}/api-docs");
    //});

}

app.UseAuthorization();

app.MapControllers();
app.MapSwagger("{documentName}/api-docs");

app.Run();
