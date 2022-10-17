using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class BoolGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(bool);
        public object Generate(Type typeToGenerate, GeneratorContext context) => true;
    }
}