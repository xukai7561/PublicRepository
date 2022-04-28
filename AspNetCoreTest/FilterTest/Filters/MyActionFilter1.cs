using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTest.Filters
{
    public class MyActionFilter1 : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("MyActionFilter1 开始执行！");
            var r =await next();
            if (r.Exception != null)
                Console.WriteLine("MyActionFilter1 执行失败！");
            else
                Console.WriteLine("MyActionFilter1 执行成功！");
        }
    }
}
