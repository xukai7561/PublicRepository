using EFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace FilterTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public ValuesController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public string TestExceptionFilter()
        {
            return System.IO.File.ReadAllText("f:/1.txt");
        }

        [HttpGet]
        public string TestActionFilter()
        {
            Console.WriteLine("Action 执行中！");
            return "你好！";
        }

        [HttpPost]
        public string TsetTransactionScope()
        {
            using TransactionScope transactionScope = new TransactionScope();

            _dbContext.Books.Add(new Book { Title = "一万个", AuthorName = "师父父", Price = 120, PubDate = DateTime.Now.AddDays(-100) });
            _dbContext.SaveChanges();
            _dbContext.Persons.Add(new Person { Name = "部署", Age = 19 });
            _dbContext.SaveChanges();
            transactionScope.Complete();
            return "ok";
        }

        [NotTransactional]
        [HttpPost]
        public string TsetNoTransactionScope()
        {
           
            _dbContext.Persons.Add(new Person { Name = "abc", Age = 19 });
            _dbContext.SaveChanges();
            _dbContext.Books.Add(new Book { Title = "一万个为什么", AuthorName = "qwe11111111111111111", Price = 120, PubDate = DateTime.Now.AddDays(-100) });
            _dbContext.SaveChanges();
            return "ok";
        }

        [HttpPost]
        public string TsetTransactionScopeFilter()
        {
            try
            {
                _dbContext.Books.Add(new Book { Title = "一万个为什么", AuthorName = "qwe", Price = 120, PubDate = DateTime.Now.AddDays(-100) });
                _dbContext.SaveChanges();
                _dbContext.Persons.Add(new Person { Name = "abc1111111111111111", Age = 19 });
                _dbContext.SaveChanges();
                return "ok";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
