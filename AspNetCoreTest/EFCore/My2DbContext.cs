using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class My2DbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public My2DbContext(DbContextOptions<My2DbContext> options) : base(options)
        {

        }
    }
}
