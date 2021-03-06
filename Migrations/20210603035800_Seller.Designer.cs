// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SellerApi.Data;

namespace SellerApi.Migrations
{
    [DbContext(typeof(SellerApiContext))]
    [Migration("20210603035800_Seller")]
    partial class Seller
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SellerApi.Models.Sellerslist", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("commission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("producttype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sellername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Sellerslist");
                });
#pragma warning restore 612, 618
        }
    }
}
