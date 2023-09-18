﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using casa_app_backend.Data;

#nullable disable

namespace casa_app_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230813220316_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("casa_app_backend.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("casa_app_backend.Models.HouseConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("casa_app_backend.Models.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GuestEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GuestPhone")
                        .HasColumnType("text");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WorkerType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("casa_app_backend.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AssignTask")
                        .HasColumnType("boolean");

                    b.Property<int>("HouseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("casa_app_backend.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AssignTask")
                        .HasColumnType("boolean");

                    b.Property<int>("HouseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("casa_app_backend.Models.ToDo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CanceledDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DoneDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EstimateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PetId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("integer");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Recurring")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PetId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("casa_app_backend.Models.ToDoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BaseCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BaseCategoryId");

                    b.ToTable("ToDoCategories");
                });

            modelBuilder.Entity("casa_app_backend.Models.ToDoDefault", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PetId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("integer");

                    b.Property<int>("Recurring")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ToDosDefault");
                });

            modelBuilder.Entity("casa_app_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthDay")
                        .HasColumnType("text");

                    b.Property<int?>("ContractId")
                        .HasColumnType("integer");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("casa_app_backend.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AssignTask")
                        .HasColumnType("boolean");

                    b.Property<int>("HouseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("casa_app_backend.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<int>("HouseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("casa_app_backend.Models.HouseConfig", b =>
                {
                    b.HasOne("casa_app_backend.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("casa_app_backend.Models.Invite", b =>
                {
                    b.HasOne("casa_app_backend.Models.Contract", "Contract")
                        .WithMany("Invites")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("casa_app_backend.Models.Pet", b =>
                {
                    b.HasOne("casa_app_backend.Models.HouseConfig", "House")
                        .WithMany("Pets")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("casa_app_backend.Models.Place", b =>
                {
                    b.HasOne("casa_app_backend.Models.HouseConfig", "House")
                        .WithMany("Places")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("casa_app_backend.Models.ToDo", b =>
                {
                    b.HasOne("casa_app_backend.Models.User", "AssignedTo")
                        .WithMany("ToDosAssigned")
                        .HasForeignKey("AssignedToId");

                    b.HasOne("casa_app_backend.Models.ToDoCategory", "Category")
                        .WithMany("ToDos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("casa_app_backend.Models.User", "CreatedBy")
                        .WithMany("ToDosCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("casa_app_backend.Models.Pet", "Pet")
                        .WithMany("ToDos")
                        .HasForeignKey("PetId");

                    b.HasOne("casa_app_backend.Models.Place", "Place")
                        .WithMany("ToDos")
                        .HasForeignKey("PlaceId");

                    b.HasOne("casa_app_backend.Models.Vehicle", "Vehicle")
                        .WithMany("ToDos")
                        .HasForeignKey("VehicleId");

                    b.Navigation("AssignedTo");

                    b.Navigation("Category");

                    b.Navigation("CreatedBy");

                    b.Navigation("Pet");

                    b.Navigation("Place");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("casa_app_backend.Models.ToDoCategory", b =>
                {
                    b.HasOne("casa_app_backend.Models.ToDoCategory", "BaseCategory")
                        .WithMany("Categories")
                        .HasForeignKey("BaseCategoryId");

                    b.Navigation("BaseCategory");
                });

            modelBuilder.Entity("casa_app_backend.Models.ToDoDefault", b =>
                {
                    b.HasOne("casa_app_backend.Models.ToDoCategory", "Category")
                        .WithMany("ToDoDefaults")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("casa_app_backend.Models.User", b =>
                {
                    b.HasOne("casa_app_backend.Models.Contract", "Contract")
                        .WithMany("UsersOfContract")
                        .HasForeignKey("ContractId");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("casa_app_backend.Models.Vehicle", b =>
                {
                    b.HasOne("casa_app_backend.Models.HouseConfig", "House")
                        .WithMany("Vehicles")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("casa_app_backend.Models.Worker", b =>
                {
                    b.HasOne("casa_app_backend.Models.HouseConfig", "House")
                        .WithMany("Workers")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("casa_app_backend.Models.Contract", b =>
                {
                    b.Navigation("Invites");

                    b.Navigation("UsersOfContract");
                });

            modelBuilder.Entity("casa_app_backend.Models.HouseConfig", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("Places");

                    b.Navigation("Vehicles");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("casa_app_backend.Models.Pet", b =>
                {
                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("casa_app_backend.Models.Place", b =>
                {
                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("casa_app_backend.Models.ToDoCategory", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("ToDoDefaults");

                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("casa_app_backend.Models.User", b =>
                {
                    b.Navigation("ToDosAssigned");

                    b.Navigation("ToDosCreated");
                });

            modelBuilder.Entity("casa_app_backend.Models.Vehicle", b =>
                {
                    b.Navigation("ToDos");
                });
#pragma warning restore 612, 618
        }
    }
}
