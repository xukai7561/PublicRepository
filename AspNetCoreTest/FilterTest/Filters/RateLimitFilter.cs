using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace FilterTest.Filters
{
	/// <summary>
	/// 限流过滤器
	/// </summary>
	public class RateLimitFilter : IAsyncActionFilter
	{
        private readonly IMemoryCache _memCache;

        public RateLimitFilter(IMemoryCache memCache)
		{
            _memCache = memCache;
        }
		public Task OnActionExecutionAsync(ActionExecutingContext context,
				ActionExecutionDelegate next)
		{
			string removeIP = context.HttpContext.Connection.RemoteIpAddress.ToString();
			string cacheKey = $"LastVisitTick_{removeIP}";
			long? lastTick = _memCache.Get<long?>(cacheKey);
			if (lastTick == null || Environment.TickCount64 - lastTick > 1000)
			{
				_memCache.Set(cacheKey, Environment.TickCount64, TimeSpan.FromSeconds(10));
				return next();
			}
			else
			{
				//context.Result = new ContentResult{ StatusCode = 429 };
				context.Result = new ObjectResult("访问太频繁") { StatusCode = 429 };
				return Task.CompletedTask;
			}
		}
	}
}
