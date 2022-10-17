using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class DoubleGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(double);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.NextDouble();
        }
    }
}