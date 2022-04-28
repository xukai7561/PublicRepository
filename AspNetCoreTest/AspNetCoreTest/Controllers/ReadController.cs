using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        [HttpGet]
        public string ReadStr()
        {
            return "ReadStr by 张三";
        }
    }
}
