using FilterTest;
using FilterTest.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zack.Commons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<RateLimitFilter>();//����
    opt.Filters.Add<MyActionFilter1>();
    opt.Filters.Add<MyActionFilter2>();

    opt.Filters.Add<TransactionScopeFilter>();//�Զ���������
});
//var assem = new Assembly[] { Assembly.Load("EFCore") };//�����ض��ĳ���
var assem = ReflectionHelper.GetAllReferencedAssemblies();
builder.Services.AddAllDbContexts(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetSection("ConnectStr").Value);
}, assem);

//builder.Services.Configure<MvcOptions>(opt =>
//{
//    opt.Filters.Add<MyExceptionFilter>();
//    opt.Filters.Add<LogExceptionFilter>();
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
