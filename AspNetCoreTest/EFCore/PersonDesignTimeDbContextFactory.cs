using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class PersonDesignTimeDbContextFactory : IDesignTimeDbContextFactory<My2DbContext>
    {
        private readonly IConfiguration _configuration;

        public PersonDesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public My2DbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<My2DbContext>();
            //var connStr = _configuration.GetSection("")
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Demo;User ID=sa;Password=111111");

            return new My2DbContext(optionsBuilder.Options);
        }
    }
}
