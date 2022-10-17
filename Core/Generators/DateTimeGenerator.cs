using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class DateTimeGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(DateTime);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return new DateTime(
                year: context.Random.Next(1, 3000),
                month: context.Random.Next(1, 12),
                day: context.Random.Next(1, 28),
                hour: context.Random.Next(0, 23),
                minute: context.Random.Next(0, 59),
                second: context.Random.Next(0, 59),
                millisecond: context.Random.Next(0, 999)
            );
        }
    }
}