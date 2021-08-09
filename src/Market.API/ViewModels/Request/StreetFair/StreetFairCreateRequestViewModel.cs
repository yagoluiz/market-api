using System.ComponentModel.DataAnnotations;

namespace Market.API.ViewModels.Request.StreetFair
{
    public class StreetFairCreateRequestViewModel
    {
        /// <summary>
        ///     Name
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        ///     Census sector
        /// </summary>
        [Required]
        public long CensusSector { get; set; }

        /// <summary>
        ///     Census grouping
        /// </summary>
        [Required]
        public long CensusGrouping { get; set; }

        /// <summary>
        ///     District code
        /// </summary>
        [Required]
        public int DistrictCode { get; set; }

        /// <summary>
        ///     District
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string District { get; set; }

        /// <summary>
        ///     Sub city hall code
        /// </summary>
        [Required]
        public int SubCityHallCode { get; set; }

        /// <summary>
        ///     Sub city hall
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string SubCityHall { get; set; }

        /// <summary>
        ///     Region 5
        /// </summary>
        [Required]
        [MaxLength(6)]
        public string Region5 { get; set; }

        /// <summary>
        ///     Region 8
        /// </summary>
        [Required]
        [MaxLength(7)]
        public string Region8 { get; set; }

        /// <summary>
        ///     Register
        /// </summary>
        [Required]
        [MaxLength(6)]
        public string Register { get; set; }

        /// <summary>
        ///     Address
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        /// <summary>
        ///     Address number
        /// </summary>
        [MaxLength(50)]
        public string AddressNumber { get; set; }

        /// <summary>
        ///     Neighborhood
        /// </summary>
        [Required]
        public string Neighborhood { get; set; }

        /// <summary>
        ///     Address details
        /// </summary>
        public string AddressDetails { get; set; }

        /// <summary>
        ///     Longitude
        /// </summary>
        [Required]
        public int Longitude { get; set; }

        /// <summary>
        ///     Latitude
        /// </summary>
        [Required]
        public int Latitude { get; set; }
    }
}