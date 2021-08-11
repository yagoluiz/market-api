using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infra.Mappings
{
    public class StreetFairMap : IEntityTypeConfiguration<StreetFair>
    {
        public void Configure(EntityTypeBuilder<StreetFair> builder)
        {
            builder.ToTable("street_fair", "public");

            builder.Property(property => property.Id)
                .HasColumnName("id");

            builder.Property(property => property.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(property => property.CensusSector)
                .HasColumnName("census_sector")
                .IsRequired();

            builder.Property(property => property.CensusGrouping)
                .HasColumnName("census_grouping")
                .IsRequired();

            builder.Property(property => property.DistrictCode)
                .HasColumnName("district_code")
                .IsRequired();

            builder.Property(property => property.District)
                .HasColumnName("district")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(property => property.SubCityHallCode)
                .HasColumnName("sub_city_hall_code")
                .IsRequired();

            builder.Property(property => property.SubCityHall)
                .HasColumnName("sub_city_hall")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(property => property.Region5)
                .HasColumnName("region5")
                .HasColumnType("varchar(6)")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(property => property.Region8)
                .HasColumnName("region8")
                .HasColumnType("varchar(7)")
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(property => property.Register)
                .HasColumnName("register")
                .HasColumnType("varchar(6)")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(property => property.Address)
                .HasColumnName("address")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(property => property.AddressNumber)
                .HasColumnName("address_number")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(property => property.Neighborhood)
                .HasColumnName("neighborhood")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(property => property.AddressDetails)
                .HasColumnName("address_details")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(property => property.Longitude)
                .HasColumnName("longitude")
                .IsRequired();

            builder.Property(property => property.Latitude)
                .HasColumnName("latitude")
                .IsRequired();

            builder.Property(property => property.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired();

            builder.Property(property => property.UpdatedDate)
                .HasColumnName("updated_date")
                .IsRequired();

            builder.HasKey(key => key.Id);
        }
    }
}
