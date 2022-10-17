using System.Text;
using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class StringGenerator : IValueGenerator
    {
        private readonly char[] _chars = "$%#@!*?;:^&1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public bool CanGenerate(Type type) => type == typeof(string);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var length = context.Random.Next(5, 100);
            var builder = new StringBuilder();

            for (int i = 0; i < length; i++)
                builder.Append(_chars[context.Random.Next(_chars.Length)]);

            return builder.ToString();
        }
    }
}