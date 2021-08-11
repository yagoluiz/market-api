using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Market.Domain.Entities;

namespace Market.Integration.Tests.Builders
{
    public static class StreetFairBuilder
    {
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

        public static StreetFair CreateStreetFair(int id = 0)
        {
            return new Faker<StreetFair>()
                .CustomInstantiator(faker => new StreetFair(
                    id,
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
        }
    }
}
