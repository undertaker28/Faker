using Faker.Context;

namespace Faker.Interfaces
{
    public interface IValueGenerator
    {
        object Generate(Type typeToGenerate, GeneratorContext context);
        bool CanGenerate(Type type);
    }
}