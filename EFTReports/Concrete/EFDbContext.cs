namespace EFTReports.Concrete
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EFTReports.Entities;

    public partial class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=TReports")
        {
        }

        public virtual DbSet<TRDataSet> TRDataSet { get; set; }
        public virtual DbSet<TRTags> TRTags { get; set; }


        public virtual DbSet<GroupEnergy> GroupEnergy { get; set; }
        public virtual DbSet<TypeEnergy> TypeEnergy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TRDataSet>()
                .HasMany(e => e.TRTags)
                .WithRequired(e => e.TRDataSet)
                .HasForeignKey(e => e.id_dataset)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupEnergy>()
                .HasMany(e => e.TypeEnergy)
                .WithRequired(e => e.GroupEnergy)
                .HasForeignKey(e => e.id_group)
                .WillCascadeOnDelete(false);

        }
    }
}
