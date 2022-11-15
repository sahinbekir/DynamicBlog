using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> o)
            : base(o)
        {

        }
        public DbSet<Employee>? Employees { get; set; }
    }
}
