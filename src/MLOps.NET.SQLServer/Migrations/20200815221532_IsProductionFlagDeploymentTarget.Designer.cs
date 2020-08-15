﻿// <auto-generated />
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System;
using MLOps.NET.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MLOps.NET.SQLServer.Migrations
{
    [DbContext(typeof(MLOpsSQLDbContext))]
    [Migration("20200815221532_IsProductionFlagDeploymentTarget")]
    partial class IsProductionFlagDeploymentTarget
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MLOps.NET.Entities.Impl.ConfusionMatrixEntity", b =>
                {
                    b.Property<Guid>("ConfusionMatrixEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RunId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerializedMatrix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConfusionMatrixEntityId");

                    b.HasIndex("RunId")
                        .IsUnique();

                    b.ToTable("ConfusionMatrix");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.Data", b =>
                {
                    b.Property<Guid>("DataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DataHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RunId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DataId");

                    b.ToTable("Data");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.DataColumn", b =>
                {
                    b.Property<Guid>("DataColumnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataSchemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataColumnId");

                    b.HasIndex("DataSchemaId");

                    b.ToTable("DataColumn");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.DataSchema", b =>
                {
                    b.Property<Guid>("DataSchemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ColumnCount")
                        .HasColumnType("int");

                    b.Property<Guid>("DataId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DataSchemaId");

                    b.HasIndex("DataId")
                        .IsUnique();

                    b.ToTable("DataSchema");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.Deployment", b =>
                {
                    b.Property<Guid>("DeploymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeployedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeploymentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeploymentTargetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExperimentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegisteredModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DeploymentId");

                    b.HasIndex("DeploymentTargetId");

                    b.HasIndex("ExperimentId");

                    b.HasIndex("RegisteredModelId");

                    b.ToTable("Deployment");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.DeploymentTarget", b =>
                {
                    b.Property<Guid>("DeploymentTargetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsProduction")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeploymentTargetId");

                    b.ToTable("DeploymentTarget");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.Experiment", b =>
                {
                    b.Property<Guid>("ExperimentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExperimentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperimentId");

                    b.ToTable("Experiment");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.HyperParameter", b =>
                {
                    b.Property<Guid>("HyperParameterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RunId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HyperParameterId");

                    b.HasIndex("RunId");

                    b.ToTable("HyperParameter");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.Metric", b =>
                {
                    b.Property<Guid>("MetricId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MetricName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RunId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("MetricId");

                    b.HasIndex("RunId");

                    b.ToTable("Metric");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.RegisteredModel", b =>
                {
                    b.Property<Guid>("RegisteredModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExperimentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegisteredBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RunArtifactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RunId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("RegisteredModelId");

                    b.HasIndex("ExperimentId");

                    b.HasIndex("RunArtifactId");

                    b.HasIndex("RunId")
                        .IsUnique();

                    b.ToTable("RegisteredModel");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.Run", b =>
                {
                    b.Property<Guid>("RunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExperimentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GitCommitHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RunDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("TrainingTime")
                        .HasColumnType("time");

                    b.HasKey("RunId");

                    b.HasIndex("ExperimentId");

                    b.ToTable("Run");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.RunArtifact", b =>
                {
                    b.Property<Guid>("RunArtifactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RunId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RunArtifactId");

                    b.HasIndex("RunId");

                    b.ToTable("RunArtifact");
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.ConfusionMatrixEntity", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.Run", null)
                        .WithOne("ConfusionMatrix")
                        .HasForeignKey("MLOps.NET.Entities.Impl.ConfusionMatrixEntity", "RunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.DataColumn", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.DataSchema", null)
                        .WithMany("DataColumns")
                        .HasForeignKey("DataSchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.DataSchema", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.Data", null)
                        .WithOne("DataSchema")
                        .HasForeignKey("MLOps.NET.Entities.Impl.DataSchema", "DataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.Deployment", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.DeploymentTarget", "DeploymentTarget")
                        .WithMany("Deployments")
                        .HasForeignKey("DeploymentTargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLOps.NET.Entities.Impl.Experiment", "Experiment")
                        .WithMany()
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MLOps.NET.Entities.Impl.RegisteredModel", "RegisteredModel")
                        .WithMany()
                        .HasForeignKey("RegisteredModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.HyperParameter", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.Run", "Run")
                        .WithMany("HyperParameters")
                        .HasForeignKey("RunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.Metric", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.Run", "Run")
                        .WithMany("Metrics")
                        .HasForeignKey("RunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.RegisteredModel", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.Experiment", "Experiment")
                        .WithMany()
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MLOps.NET.Entities.Impl.RunArtifact", "RunArtifact")
                        .WithMany()
                        .HasForeignKey("RunArtifactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLOps.NET.Entities.Impl.Run", "Run")
                        .WithOne()
                        .HasForeignKey("MLOps.NET.Entities.Impl.RegisteredModel", "RunId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.Run", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.Experiment", "Experiment")
                        .WithMany("Runs")
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MLOps.NET.Entities.Impl.RunArtifact", b =>
                {
                    b.HasOne("MLOps.NET.Entities.Impl.Run", "Run")
                        .WithMany("RunArtifacts")
                        .HasForeignKey("RunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
