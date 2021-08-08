using System.Collections.Generic;
using Bogus;
using Market.Domain.Entities;

namespace Market.Integration.Tests.Builders
{
    public static class StreetFairBuilder
    {
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