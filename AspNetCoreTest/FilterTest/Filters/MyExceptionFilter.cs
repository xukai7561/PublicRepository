using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTest
{
    public class MyExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public MyExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public Task OnExceptionAsync(ExceptionContext context)
        {
            string msg = "";
            if (_hostEnvironment.IsDevelopment())
            {
                msg = context.Exception.ToString();
            }
            else
            {
                msg = "服务器端发生未处理异常";
            }

            ObjectResult objectResult = new ObjectResult(new { code = 500, message = msg });
            context.Result = objectResult;
            context.ExceptionHandled=true;
            //context.Result = objectResult;
            return Task.CompletedTask;
        }
    }
}
