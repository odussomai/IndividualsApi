﻿// <auto-generated />
using System;
using IndividualsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IndividualsApi.Migrations
{
    [DbContext(typeof(IndividualsContext))]
    partial class IndividualsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IndividualsApi.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tbilisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kutaisi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Batumi"
                        });
                });

            modelBuilder.Entity("IndividualsApi.Data.Entities.Individual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Image");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<int>("Sex");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Individuals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            DateOfBirth = new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Aleksandre",
                            Image = "",
                            LastName = "Tsereteli",
                            PersonalId = "01024080411",
                            Sex = 0
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            DateOfBirth = new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Another",
                            Image = "",
                            LastName = "Person",
                            PersonalId = "11111111111",
                            Sex = 1
                        });
                });

            modelBuilder.Entity("IndividualsApi.Data.Entities.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IndividualId");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IndividualId = 1,
                            PhoneNumber = "598499901",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            IndividualId = 1,
                            PhoneNumber = "577676767",
                            Type = 2
                        });
                });

            modelBuilder.Entity("IndividualsApi.Data.Entities.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IndividualId");

                    b.Property<int>("RelativeId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.HasIndex("RelativeId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("IndividualsApi.Data.Entities.Individual", b =>
                {
                    b.HasOne("IndividualsApi.Data.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("IndividualsApi.Data.Entities.Phone", b =>
                {
                    b.HasOne("IndividualsApi.Data.Entities.Individual")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("IndividualId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IndividualsApi.Data.Entities.Relation", b =>
                {
                    b.HasOne("IndividualsApi.Data.Entities.Individual", "individual")
                        .WithMany("Relatives")
                        .HasForeignKey("IndividualId");

                    b.HasOne("IndividualsApi.Data.Entities.Individual", "Relative")
                        .WithMany()
                        .HasForeignKey("RelativeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
