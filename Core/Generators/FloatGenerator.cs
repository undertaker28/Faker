using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class FloatGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(float);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.NextSingle();
        }
    }
}