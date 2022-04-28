using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTest.Filters
{
    public class MyActionFilter2 : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("MyActionFilter2 开始执行！");
            var r =await next();
            if (r.Exception != null)
                Console.WriteLine("MyActionFilter2 执行失败！");
            else
                Console.WriteLine("MyActionFilter2 执行成功！");
        }
    }
}
