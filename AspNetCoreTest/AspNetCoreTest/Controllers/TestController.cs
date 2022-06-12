using EFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        private readonly My2DbContext _my2DbContext;

        public TestController(MyDbContext dbContext, My2DbContext my2DbContext)
        {
            _dbContext = dbContext;
            _my2DbContext = my2DbContext;
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetContent()
        {
            int c = _dbContext.Books.Count();
            return $"c={c},a=" + _my2DbContext.Persons.Count();
        }

        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetPerson()
        {
            int c = _my2DbContext.Persons.Count();
            return $"c={c}";
        }

        /// <summary>
        /// 获取Book集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Book> GetBookList()
        {
            var list = _dbContext.Books.ToList();
            return list;
        }

        [HttpGet]
        public string GetNo()
        {
            return "1001";

        }

        /// <summary>
        /// Test1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Tset1()
        {
            return "testGit";
        }

        /// <returns></returns>
        [HttpGet]
        public string Tset2()
        {
            return "test2";
        }

        /// <summary>
        /// LiSiTest1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string LiSiTest()
        {
            return "LiSiTest尴尬癌挥发分";
        }
        /// <summary>
        /// 张三Test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string 张三Test()
        {
            return "张三Test";
        }


  
    }
}
