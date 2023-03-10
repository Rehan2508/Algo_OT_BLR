// <auto-generated />
using Algo.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Algo.App.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Algo.App.Models.CityCode", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("code")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("CityCodes");
                });

            modelBuilder.Entity("Algo.App.Models.Routes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("destination")
                        .HasColumnName("city_to")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("destinationCode")
                        .HasColumnName("to_city_code")
                        .HasColumnType("int");

                    b.Property<double>("distance")
                        .HasColumnName("distance")
                        .HasColumnType("float");

                    b.Property<string>("source")
                        .HasColumnName("city_from")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sourceCode")
                        .HasColumnName("from_city_code")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SP_Routes");
                });

            modelBuilder.Entity("Algo.App.Models.RoutesData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("route_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("algoInput")
                        .HasColumnName("algoInput")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("algoName")
                        .HasColumnName("algoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("algoOutput")
                        .HasColumnName("algoOutput")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("SP_ShortestPathHeader");
                });
#pragma warning restore 612, 618
        }
    }
}
