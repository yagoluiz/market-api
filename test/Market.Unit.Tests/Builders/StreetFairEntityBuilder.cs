using System.Collections.Generic;
using Bogus;
using Market.Domain.Entities;

namespace Market.Unit.Tests.Builders
{
    public static class StreetFairEntityBuilder
    {
        private static IEnumerable<StreetFair> CreateStreetFairs =>
            new Faker<StreetFair>()
                .CustomInstantiator(faker => new StreetFair(
                    faker.Random.Word(),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word(),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word(),
                    faker.Random.Int(1, 10).ToString(),
                    faker.Random.Int(1, 10).ToString(),
                    faker.Random.Int(1, 10).ToString(),
                    faker.Random.Word(),
                    faker.Random.Word(),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word(),
                    faker.Random.Word()
                )).Generate(3);

        public static Pagination<StreetFair> PaginationStreetFairs(
            bool isItems = true
        )
        {
            return new Faker<Pagination<StreetFair>>()
                .CustomInstantiator(faker => new Pagination<StreetFair>(
                    isItems ? CreateStreetFairs : new List<StreetFair>(),
                    faker.Random.Int(1, 10),
                    faker.Random.Int(1, 10),
                    faker.Random.Int(1, 10)
                ))
                .Generate();
        }
    }
}
