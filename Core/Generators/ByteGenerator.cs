using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class ByteGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(byte);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (byte)context.Random.Next(1, byte.MaxValue);
        }
    }
}