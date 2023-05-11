using Microsoft.EntityFrameworkCore;
using WsApiexamen.Data.Entities;

namespace WsApiexamen.Data
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
            
        }
        public DBContext(DbContextOptions<DBContext>options): base(options)
        {
            
        }
        public DbSet<tblExamen> tblExamen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblExamen>().HasKey(e => e.idExamen);
           
        }
     
    }
}
