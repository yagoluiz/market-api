using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infra.Mappings
{
    public class StreetFairMap : IEntityTypeConfiguration<StreetFair>
    {
        public void Configure(EntityTypeBuilder<StreetFair> builder)
        {
            builder.Property(property => property.Id);

            builder.Property(property => property.Name)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(property => property.CensusSector)
                .IsRequired();

            builder.Property(property => property.CensusGrouping)
                .IsRequired();

            builder.Property(property => property.DistrictCode)
                .IsRequired();

            builder.Property(property => property.District)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(property => property.SubCityHallCode)
                .IsRequired();

            builder.Property(property => property.SubCityHall)
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(property => property.Region5)
                .HasColumnType("varchar(6)")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(property => property.Region8)
                .HasColumnType("varchar(7)")
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(property => property.Register)
                .HasColumnType("varchar(6)")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(property => property.Address)
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(property => property.AddressNumber)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(property => property.Neighborhood)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(property => property.AddressDetails)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder.Property(property => property.Longitude)
                .IsRequired();

            builder.Property(property => property.Latitude)
                .IsRequired();

            builder.Property(property => property.CreatedDate)
                .IsRequired();

            builder.Property(property => property.UpdatedDate)
                .IsRequired();

            builder.HasKey(key => key.Id);

            builder.HasIndex(index => index.DistrictCode)
                .IsUnique();
        }
    }
}