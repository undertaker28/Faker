﻿using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class LongGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(long);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.NextInt64(1, long.MaxValue);
        }
    }
}