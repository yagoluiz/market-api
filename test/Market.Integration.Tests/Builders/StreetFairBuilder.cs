using System.Collections.Generic;
using Bogus;
using Market.Domain.Entities;

namespace Market.Integration.Tests.Builders
{
    public static class StreetFairBuilder
    {
        public static StreetFair CreateStreetFair(int id = 0) =>
            new Faker<StreetFair>()
                .CustomInstantiator(faker => new StreetFair(
                    id: id,
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
                )).Generate();

        public static IEnumerable<StreetFair> CreateStreetFairs =>
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
    }
}
