using Microsoft.EntityFrameworkCore;
using APIForAutomation.Api.Models;

namespace APIForAutomation.Api.Data
{
    public class Context : DbContext
    {
        //Microsoft.EnitityFramworkCore.SqlServer
        //Microsoft.EnitityFramworkCore.Tools
        // Add-Migration NomeMigração
        //Update-Database -verbose
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}
