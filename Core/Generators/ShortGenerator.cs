using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class ShortGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(short);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (short)context.Random.Next(1, short.MaxValue);
        }
    }
}