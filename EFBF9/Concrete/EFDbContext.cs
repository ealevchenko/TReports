using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFBF9.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=BF9")
        {

        }

        //public virtual DbSet<BF9_UnloadBunker> UnloadBunker { get; set; }
        //public virtual DbSet<BF9_UnloadMaterial> UnloadMaterial { get; set; }
        //public virtual DbSet<BF9_EnergoSutki> EnergoSutki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BF9_UnloadBunker>()
            //    .Property(e => e.Материал)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<BF9_UnloadBunker>()
            //    .Property(e => e.Материал_по_факту)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<BF9_UnloadMaterial>()
            //    .Property(e => e.Type)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<BF9_UnloadMaterial>()
            //    .Property(e => e.Material)
            //    .IsFixedLength()
            //    .IsUnicode(false);
        }

    }
}
