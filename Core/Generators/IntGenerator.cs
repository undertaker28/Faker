using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class IntGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(int);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.Next(1, int.MaxValue);
        }
    }
}