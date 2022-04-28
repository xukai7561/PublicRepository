using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTest
{
    public class LogExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            return File.AppendAllTextAsync("h:/error.log",context.Exception.ToString());
        }
    }
}
