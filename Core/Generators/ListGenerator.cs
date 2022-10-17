using Faker.Context;
using Faker.Interfaces;
using System.Collections;

namespace Faker.Generators
{
    public class ListGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var list = (IList)Activator.CreateInstance(typeToGenerate);
            var listSize = context.Random.Next(5, 100);
            for (int i = 0; i < listSize; i++)
                list.Add(context.Faker.Create(typeToGenerate.GetGenericArguments()[0]));

            return list;
        }
    }
}