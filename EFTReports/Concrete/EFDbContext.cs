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

        public virtual DbSet<Connections> Connections { get; set; }
        public virtual DbSet<DataSetParameters> DataSetParameters { get; set; }
        public virtual DbSet<DataSets> DataSets { get; set; }
        public virtual DbSet<FactoryProviders> FactoryProviders { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }


        public virtual DbSet<GroupEnergy> GroupEnergy { get; set; }
        public virtual DbSet<TypeEnergy> TypeEnergy { get; set; }

        public virtual DbSet<ReportForms> ReportForms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GroupEnergy>()
                .HasMany(e => e.TypeEnergy)
                .WithRequired(e => e.GroupEnergy)
                .HasForeignKey(e => e.id_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Connections>()
                .HasMany(e => e.DataSets)
                .WithRequired(e => e.Connections)
                .HasForeignKey(e => e.id_connection)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DataSets>()
                .HasMany(e => e.DataSetParameters)
                .WithRequired(e => e.DataSets)
                .HasForeignKey(e => e.id_dataset)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FactoryProviders>()
                .HasMany(e => e.Connections)
                .WithRequired(e => e.FactoryProviders)
                .HasForeignKey(e => e.id_provider)
                .WillCascadeOnDelete(false);

        }
    }
}
