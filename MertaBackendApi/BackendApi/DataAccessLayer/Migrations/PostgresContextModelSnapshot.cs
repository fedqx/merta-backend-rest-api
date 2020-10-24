﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BackendApi.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.sq_campaign", "'sq_campaign', '', '1', '1', '', '', 'Int16', 'False'")
                .HasAnnotation("Relational:Sequence:.sq_category", "'sq_category', '', '1', '1', '', '', 'Int16', 'False'")
                .HasAnnotation("Relational:Sequence:.sq_flatinfo", "'sq_flatinfo', '', '1', '1', '', '', 'Int16', 'False'")
                .HasAnnotation("Relational:Sequence:.sq_image", "'sq_image', '', '1', '1', '', '', 'Int16', 'False'")
                .HasAnnotation("Relational:Sequence:.sq_stage", "'sq_stage', '', '1', '1', '', '', 'Int16', 'False'")
                .HasAnnotation("Relational:Sequence:.sq_worksite", "'sq_worksite', '', '1', '1', '', '', 'Int16', 'False'");

            modelBuilder.Entity("Entities.Campaign", b =>
                {
                    b.Property<short>("Campaign_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("nextval(\"'sq_campaign'\")");

                    b.Property<short>("CampaignWorksite_Id")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("Campaign_FDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Campaign_ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("Campaign_Stage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Campaign_Tag")
                        .HasColumnType("text");

                    b.HasKey("Campaign_Id");

                    b.HasIndex("CampaignWorksite_Id");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<short>("Category_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("nextval(\"'sq_category'\")");

                    b.Property<string>("Category_Tag")
                        .HasColumnType("text");

                    b.HasKey("Category_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.FlatInfo", b =>
                {
                    b.Property<short>("FlatInfo_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("nextval(\"'sq_flatinfo'\")");

                    b.Property<short>("FlatInfoWorksite_Id")
                        .HasColumnType("smallint");

                    b.Property<string>("FlatInfo_Apartment")
                        .HasColumnType("text");

                    b.Property<string>("FlatInfo_Front")
                        .HasColumnType("text");

                    b.Property<string>("FlatInfo_Room")
                        .HasColumnType("text");

                    b.Property<string>("FlatInfo_Size")
                        .HasColumnType("text");

                    b.HasKey("FlatInfo_Id");

                    b.HasIndex("FlatInfoWorksite_Id");

                    b.ToTable("FlatInfos");
                });

            modelBuilder.Entity("Entities.Image", b =>
                {
                    b.Property<short>("Image_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("nextval(\"'sq_image'\")");

                    b.Property<string>("ImageRaw_Url")
                        .HasColumnType("text");

                    b.Property<short>("ImageWorksite_Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Image_Url")
                        .HasColumnType("text");

                    b.HasKey("Image_Id");

                    b.HasIndex("ImageWorksite_Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Entities.Stage", b =>
                {
                    b.Property<short>("Stage_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("nextval(\"'sq_state'\")");

                    b.Property<string>("Stage_Tag")
                        .HasColumnType("text");

                    b.HasKey("Stage_Id");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("Entities.Worksite", b =>
                {
                    b.Property<short>("Worksite_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("nextval(\"'sq_worksite'\")");

                    b.Property<short>("WorksiteCategory_Id")
                        .HasColumnType("smallint");

                    b.Property<short>("WorksiteStage_Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Worksite_Adress")
                        .HasColumnType("text");

                    b.Property<string>("Worksite_City")
                        .HasColumnType("text");

                    b.Property<DateTime>("Worksite_FDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Worksite_SDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Worksite_Tag")
                        .HasColumnType("text");

                    b.HasKey("Worksite_Id");

                    b.HasIndex("WorksiteCategory_Id");

                    b.HasIndex("WorksiteStage_Id");

                    b.ToTable("Worksites");
                });

            modelBuilder.Entity("Entities.Campaign", b =>
                {
                    b.HasOne("Entities.Worksite", "CampaignWorksite")
                        .WithMany("WorksiteCampaigns")
                        .HasForeignKey("CampaignWorksite_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.FlatInfo", b =>
                {
                    b.HasOne("Entities.Worksite", "FlatInfoWorksite")
                        .WithMany("WorksiteFlatInfos")
                        .HasForeignKey("FlatInfoWorksite_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Image", b =>
                {
                    b.HasOne("Entities.Worksite", "ImageWorksite")
                        .WithMany("WorksiteImages")
                        .HasForeignKey("ImageWorksite_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Worksite", b =>
                {
                    b.HasOne("Entities.Category", "WorksiteCategory")
                        .WithMany("CategoryWorksites")
                        .HasForeignKey("WorksiteCategory_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Stage", "WorksiteStage")
                        .WithMany("StageWorksites")
                        .HasForeignKey("WorksiteStage_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
