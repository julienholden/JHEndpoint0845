using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JHEndpoint0845.Models
{
    public partial class JHDbaseContext : DbContext
    {
        public JHDbaseContext()
        {
        }

        public JHDbaseContext(DbContextOptions<JHDbaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllStaff> AllStaff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=tcp:server-0309b.database.windows.net,1433;Initial Catalog=db-0309;Persist Security Info=False;User ID=jhadmin;Password=September2020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
