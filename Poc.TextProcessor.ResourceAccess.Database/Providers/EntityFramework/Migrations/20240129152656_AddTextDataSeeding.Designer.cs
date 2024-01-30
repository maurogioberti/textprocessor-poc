﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework;

#nullable disable

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Migrations
{
    [DbContext(typeof(PocContext))]
    [Migration("20240129152656_AddTextDataSeeding")]
    partial class AddTextDataSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Poc.TextProcessor.ResourceAccess.Entities.TextEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Texts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        },
                        new
                        {
                            Id = 2,
                            Content = "Parmesan mascarpone cheese on toast. Manchego cheese strings goat rubber cheese cheese and biscuits cheese on toast boursin jarlsberg. Macaroni cheese when the cheese comes out everybody's happy cauliflower cheese cheddar cow taleggio queso bavarian bergkase. Edam parmesan queso ricotta babybel cow who moved my cheese cheese triangles. Everyone loves."
                        },
                        new
                        {
                            Id = 3,
                            Content = "Pudding topping candy biscuit halvah apple pie chocolate. Tootsie roll tootsie roll sugar plum dessert bear claw cake. Jelly-o gummi bears cake jelly beans macaroon tart jelly. Pie powder macaroon pie sweet gummies cupcake. Wafer dragée chupa chups lollipop carrot cake candy. Ice cream halvah pie tootsie roll donut jelly beans. Tootsie roll lemon drops lemon drops oat cake candy. Marzipan gummies marshmallow tart soufflé muffin."
                        },
                        new
                        {
                            Id = 4,
                            Content = "They're late. My experiment worked. They're all exactly twenty-five minutes slow. Nothing, nothing, nothing, look tell her destiny has brought you together, tell her that she's the most beautiful you have ever seen. Girls like that stuff. What, what are you doing George? Can I go now, Mr. Strickland? It works, ha ha ha ha, it works. I finally invent something that works. Oh."
                        });
                });

            modelBuilder.Entity("Poc.TextProcessor.ResourceAccess.Entities.TextSortEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.ToTable("TextSorts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Option = "AlphabeticAsc"
                        },
                        new
                        {
                            Id = 2,
                            Option = "AlphabeticDesc"
                        },
                        new
                        {
                            Id = 3,
                            Option = "LengthAsc"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}