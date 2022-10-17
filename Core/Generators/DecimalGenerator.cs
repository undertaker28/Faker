using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class DecimalGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(decimal);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (decimal)context.Random.Next(1, int.MaxValue);
        }
    }
}