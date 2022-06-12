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

        /// <summary>
        /// Test1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Tset1()
        {
            return "testGit";
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
        /// <summary>
        /// 王五Test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string 王五Test()
        {
            string str = "afadagduadYDudADad";



            return "王五Test发黑发还多好的";
        }

        /// <summary>
        /// 赵六Test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string 赵六Test()
        {
            return "赵六Test";
        }

        [HttpGet]
        public string 寒气Test()
        {
            string str = "666";
            return "寒气Test";
        }
    }
}
