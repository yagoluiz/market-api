using System.Collections.Generic;
using Bogus;
using Market.Domain.Entities;
using Bogus.Extensions;

namespace Market.Integration.Tests.Builders
{
    public static class StreetFairBuilder
    {
        public static StreetFair CreateStreetFair(int id = 0) =>
            new Faker<StreetFair>()
                .CustomInstantiator(faker => new StreetFair(
                    id: id,
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word(),
                    faker.Random.Word().ClampLength(max: 5),
                    faker.Random.Word().ClampLength(max: 5),
                    faker.Random.Word().ClampLength(max: 5),
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Word().ClampLength(max: 10)
                )).Generate();

        public static IEnumerable<StreetFair> CreateStreetFairs =>
            new Faker<StreetFair>()
                .CustomInstantiator(faker => new StreetFair(
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word(),
                    faker.Random.Word().ClampLength(max: 5),
                    faker.Random.Word().ClampLength(max: 5),
                    faker.Random.Word().ClampLength(max: 5),
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Int(10000, 999999),
                    faker.Random.Word().ClampLength(max: 10),
                    faker.Random.Word().ClampLength(max: 10)
                )).Generate(3);
    }
}
