using Faker.Interfaces;

namespace Faker.Core
{
    public class ObjectCreator
    {
        private readonly IFaker _faker;
        public ObjectCreator(IFaker faker)
        {
            _faker = faker;
        }

        public object CreateObject(Type type)
        {
            var typeConstructors = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .ToList();

            foreach (var ctor in typeConstructors)
            {
                try
                {
                    var parameters = ctor.GetParameters()
                        .Select(t => t.ParameterType)
                        .Select(_faker.Create).ToArray();

                    return ctor.Invoke(parameters);
                }
                catch
                { }
            }

            throw new Exception();
        }
    }
}