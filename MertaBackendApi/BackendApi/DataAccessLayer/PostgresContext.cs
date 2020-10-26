using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using BackendApi;

namespace BackendApi.DataAccessLayer
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> opt) : base(opt)
        {

        }
        public PostgresContext()
        {

        }

        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Worksite> Worksites { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<FlatInfo> FlatInfos { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Stage> Stages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence<short>("sq_admin")
            //    .IncrementsBy(1);
            modelBuilder.HasSequence<int>("sq_campaign")
                .IncrementsBy(1);
            modelBuilder.HasSequence<int>("sq_category")
                .IncrementsBy(1);
            modelBuilder.HasSequence<int>("sq_flatinfo")
                .IncrementsBy(1);
            modelBuilder.HasSequence<int>("sq_image")
                .IncrementsBy(1);
            modelBuilder.HasSequence<int>("sq_stage")
                .IncrementsBy(1);
            modelBuilder.HasSequence<int>("sq_worksite")
                .IncrementsBy(1);

            //modelBuilder.Entity<Admin>()
            //    .Property(p => p.Admin_Id)
            //    .HasDefaultValueSql("nextval(\"'sq_admin'\")");
            modelBuilder.Entity<Campaign>()
                .Property(p => p.Campaign_Id)
                .HasDefaultValueSql("nextval('\"sq_campaign\"')");
            modelBuilder.Entity<Category>()
                .Property(p => p.Category_Id)
                .HasDefaultValueSql("nextval('\"sq_category\"')");
            modelBuilder.Entity<FlatInfo>()
                .Property(p => p.FlatInfo_Id)
                .HasDefaultValueSql("nextval('\"sq_flatinfo\"')");
            modelBuilder.Entity<Image>()
                .Property(p => p.Image_Id)
                .HasDefaultValueSql("nextval('\"sq_image\"')");
            modelBuilder.Entity<Stage>()
                .Property(p => p.Stage_Id)
                .HasDefaultValueSql("nextval('\"sq_state\"')");
            modelBuilder.Entity<Worksite>()
                .Property(p => p.Worksite_Id)
                .HasDefaultValueSql("nextval('\"sq_worksite\"')");


            modelBuilder
                .Entity<Worksite>()
                .HasOne(p => p.WorksiteCategory)
                .WithMany(p => p.CategoryWorksites)
                .HasForeignKey(p => p.WorksiteCategory_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Worksite>()
                .HasOne(p => p.WorksiteStage)
                .WithMany(p => p.StageWorksites)
                .HasForeignKey(p => p.WorksiteStage_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Image>()
                .HasOne(p => p.ImageWorksite)
                .WithMany(p => p.WorksiteImages)
                .HasForeignKey(p => p.ImageWorksite_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<FlatInfo>()
                .HasOne(p => p.FlatInfoWorksite)
                .WithMany(p => p.WorksiteFlatInfos)
                .HasForeignKey(p => p.FlatInfoWorksite_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Campaign>()
                .HasOne(p => p.CampaignWorksite)
                .WithMany(p => p.WorksiteCampaigns)
                .HasForeignKey(p => p.CampaignWorksite_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Campaign>()
                .Property(p => p.Campaign_Stage)
                .HasDefaultValue<bool>(true);
                





        }  
    }
}
