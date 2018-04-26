using System.Data.Entity;

namespace Minor.GenericCRUD.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<AppDbContext>());
        }

        public DbSet<Student> Students { get; set; }
    }
}