using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class CharGenerator : IValueGenerator
    {
        private readonly char[] _chars = "$%#@!*?;:^&1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public bool CanGenerate(Type type) => type == typeof(char);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return _chars[context.Random.Next(0, _chars.Length)];
        }
    }
}