using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Market.Domain.Entities;
using Market.Domain.Models;
using Market.Infra.Contexts;

namespace Market.Infra.Seeds
{
    public static class StreetFairSeed
    {
        public static void RunSeed(EntityContext context)
        {
            AddStreetFairs(context);
        }

        private static void AddStreetFairs(EntityContext context)
        {
            var streetFairCsvRecords = GetStreetFairCsvRecords();

            var streetFairs = streetFairCsvRecords
                .Select(record => new StreetFair(
                    record.Name.TrimEnd().ToUpper(),
                    record.CensusSector,
                    record.CensusGrouping,
                    record.DistrictCode,
                    record.District.TrimEnd().ToUpper(),
                    record.SubCityHallCode,
                    record.SubCityHall.TrimEnd().ToUpper(),
                    record.Region5.TrimEnd().ToUpper(),
                    record.Region8.TrimEnd().ToUpper(),
                    record.Register.TrimEnd().ToUpper(),
                    record.Address.TrimEnd().ToUpper(),
                    record.Neighborhood.TrimEnd().ToUpper(),
                    record.Longitude,
                    record.Latitude,
                    !string.IsNullOrEmpty(record.AddressNumber)
                        ? decimal.TryParse(record.AddressNumber, out var addressNumber)
                            ? decimal.Truncate(addressNumber).ToString(CultureInfo.InvariantCulture)
                            : record.AddressNumber.TrimEnd().ToUpper()
                        : null,
                    !string.IsNullOrEmpty(record.AddressDetails)
                        ? record.AddressDetails.TrimEnd().ToUpper()
                        : null
                ));

            context.AddRange(streetFairs);
            context.SaveChanges();
        }

        private static IEnumerable<StreetFairCsvModel> GetStreetFairCsvRecords()
        {
            var path = Path.Combine(
                Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? string.Empty,
                "Imports/DEINFO_AB_FEIRASLIVRES_2014.csv"
            );

            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToUpper(),
                MissingFieldFound = null
            };

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, csvConfiguration);

            var records = csv.GetRecords<StreetFairCsvModel>();

            return records.ToList();
        }
    }
}
