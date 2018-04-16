using System.Data.Entity;
using DomainBook.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infrastructure.Context
{
    public partial class BookContext: DbContext
    {
        public BookContext()
            // Some hardcode on connection string :P
            : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IBook; Integrated Security=True; Connect Timeout=30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
