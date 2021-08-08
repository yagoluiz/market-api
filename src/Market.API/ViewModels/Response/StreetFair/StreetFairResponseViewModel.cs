using System;

namespace Market.API.ViewModels.Response.StreetFair
{
    public class StreetFairResponseViewModel
    {
        public StreetFairResponseViewModel(
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
            string addressNumber,
            string neighborhood,
            string addressDetails,
            int longitude,
            int latitude,
            DateTime createdDate
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
            AddressNumber = addressNumber;
            Neighborhood = neighborhood;
            AddressDetails = addressDetails;
            Longitude = longitude;
            Latitude = latitude;
            CreatedDate = createdDate;
        }

        /// <summary>
        ///     Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Census sector
        /// </summary>
        public long CensusSector { get; }

        /// <summary>
        ///     Census grouping
        /// </summary>
        public long CensusGrouping { get; }

        /// <summary>
        ///     District code
        /// </summary>
        public int DistrictCode { get; }

        /// <summary>
        ///     District
        /// </summary>
        public string District { get; }

        /// <summary>
        ///     Sub city hall Code
        /// </summary>
        public int SubCityHallCode { get; }

        /// <summary>
        ///     Sub city hall
        /// </summary>
        public string SubCityHall { get; }

        /// <summary>
        ///     Region 5
        /// </summary>
        public string Region5 { get; }

        /// <summary>
        ///     Region 8
        /// </summary>
        public string Region8 { get; }

        /// <summary>
        ///     Register
        /// </summary>
        public string Register { get; }

        /// <summary>
        ///     Address
        /// </summary>
        public string Address { get; }

        /// <summary>
        ///     Address number
        /// </summary>
        public string AddressNumber { get; }

        /// <summary>
        ///     Neighborhood
        /// </summary>
        public string Neighborhood { get; }

        /// <summary>
        ///     Address details
        /// </summary>
        public string AddressDetails { get; }

        /// <summary>
        ///     Longitude
        /// </summary>
        public int Longitude { get; }

        /// <summary>
        ///     Latitude
        /// </summary>
        public int Latitude { get; }

        /// <summary>
        ///     Created date
        /// </summary>
        public DateTime CreatedDate { get; }
    }
}