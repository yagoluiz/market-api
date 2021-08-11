using System;

namespace Market.Domain.Entities
{
    public class StreetFair
    {
        protected StreetFair()
        {
        }

        public StreetFair(
            string name,
            long censusSector,
            long censusGrouping,
            int districtCode,
            string district,
            int subCityHallCode,
            string subCityHall,
            string region5,
            string region8,
            string register,
            string address,
            string neighborhood,
            int longitude,
            int latitude,
            string addressNumber = null,
            string addressDetails = null
        )
        {
            Name = name;
            CensusSector = censusSector;
            CensusGrouping = censusGrouping;
            DistrictCode = districtCode;
            District = district;
            SubCityHallCode = subCityHallCode;
            SubCityHall = subCityHall;
            Region5 = region5;
            Region8 = region8;
            Register = register;
            Address = address;
            Neighborhood = neighborhood;
            Longitude = longitude;
            Latitude = latitude;
            AddressNumber = addressNumber;
            AddressDetails = addressDetails;
        }

        public StreetFair(
            int id,
            string name,
            long censusSector,
            long censusGrouping,
            int districtCode,
            string district,
            int subCityHallCode,
            string subCityHall,
            string region5,
            string region8,
            string register,
            string address,
            string neighborhood,
            int longitude,
            int latitude,
            string addressNumber = null,
            string addressDetails = null
        )
        {
            Id = id;
            Name = name;
            CensusSector = censusSector;
            CensusGrouping = censusGrouping;
            DistrictCode = districtCode;
            District = district;
            SubCityHallCode = subCityHallCode;
            SubCityHall = subCityHall;
            Region5 = region5;
            Region8 = region8;
            Register = register;
            Address = address;
            Neighborhood = neighborhood;
            Longitude = longitude;
            Latitude = latitude;
            AddressNumber = addressNumber;
            AddressDetails = addressDetails;
        }

        public int Id { get; }
        public string Name { get; }
        public long CensusSector { get; }
        public long CensusGrouping { get; }
        public int DistrictCode { get; }
        public string District { get; }
        public int SubCityHallCode { get; }
        public string SubCityHall { get; }
        public string Region5 { get; }
        public string Region8 { get; }
        public string Register { get; }
        public string Address { get; }
        public string AddressNumber { get; }
        public string Neighborhood { get; }
        public string AddressDetails { get; }
        public int Longitude { get; }
        public int Latitude { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdatedDate { get; }
    }
}
