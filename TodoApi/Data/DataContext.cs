using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
