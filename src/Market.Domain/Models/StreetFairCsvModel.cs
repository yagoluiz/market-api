using CsvHelper.Configuration.Attributes;

namespace Market.Domain.Models
{
    public class StreetFairCsvModel
    {
        [Index(1)] [Name("LONG")] public int Longitude { get; set; }
        [Index(2)] [Name("LAT")] public int Latitude { get; set; }
        [Index(3)] [Name("SETCENS")] public long CensusSector { get; set; }
        [Index(4)] [Name("AREAP")] public long CensusGrouping { get; set; }
        [Index(5)] [Name("CODDIST")] public int DistrictCode { get; set; }
        [Index(6)] [Name("DISTRITO")] public string District { get; set; }
        [Index(7)] [Name("CODSUBPREF")] public int SubCityHallCode { get; set; }
        [Index(8)] [Name("SUBPREFE")] public string SubCityHall { get; set; }
        [Index(9)] [Name("REGIAO5")] public string Region5 { get; set; }
        [Index(10)] [Name("REGIAO8")] public string Region8 { get; set; }
        [Index(11)] [Name("NOME_FEIRA")] public string Name { get; set; }
        [Index(12)] [Name("REGISTRO")] public string Register { get; set; }
        [Index(13)] [Name("LOGRADOURO")] public string Address { get; set; }
        [Index(14)] [Name("NUMERO")] public string AddressNumber { get; set; }
        [Index(15)] [Name("BAIRRO")] public string Neighborhood { get; set; }
        [Index(16)] [Name("REFERENCIA")] public string AddressDetails { get; set; }
    }
}