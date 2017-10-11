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
        public virtual DbSet<REnergyDay> REnergyDay { get; set; }

        public virtual DbSet<ReportFlowEnergyDay_Group> ReportFlowEnergyDay_Group { get; set; }
        public virtual DbSet<ReportFlowEnergyDay_Item> ReportFlowEnergyDay_Item { get; set; }
        public virtual DbSet<ReportFlowEnergyDay_Type> ReportFlowEnergyDay_Type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TRDataSet>()
                .HasMany(e => e.TRTags)
                .WithRequired(e => e.TRDataSet)
                .HasForeignKey(e => e.id_dataset)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupEnergy>()
                .HasMany(e => e.ReportFlowEnergyDay_Group)
                .WithRequired(e => e.GroupEnergy)
                .HasForeignKey(e => e.id_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupEnergy>()
                .HasMany(e => e.TypeEnergy)
                .WithRequired(e => e.GroupEnergy)
                .HasForeignKey(e => e.id_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReportFlowEnergyDay_Group>()
                .HasMany(e => e.ReportFlowEnergyDay_Type)
                .WithRequired(e => e.ReportFlowEnergyDay_Group)
                .HasForeignKey(e => e.id_report_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReportFlowEnergyDay_Type>()
                .HasMany(e => e.ReportFlowEnergyDay_Item)
                .WithRequired(e => e.ReportFlowEnergyDay_Type)
                .HasForeignKey(e => e.id_report_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeEnergy>()
                .HasMany(e => e.ReportFlowEnergyDay_Type)
                .WithRequired(e => e.TypeEnergy)
                .HasForeignKey(e => e.id_type)
                .WillCascadeOnDelete(false);

        }
    }
}
