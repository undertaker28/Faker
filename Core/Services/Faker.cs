using Core.Generators;
using Faker.Context;
using Faker.Generators;
using Faker.Interfaces;

namespace Faker.Core
{
    public class Faker : IFaker
    {
        private readonly GeneratorContext _generatorContext;
        private readonly List<IValueGenerator> _valueGenerators = new List<IValueGenerator> {
                new BoolGenerator(),
                new ByteGenerator(),
                new CharGenerator(),
                new DateTimeGenerator(),
                new DecimalGenerator(),
                new DoubleGenerator(),
                new FloatGenerator(),
                new IntGenerator(),
                new ListGenerator(),
                new LongGenerator(),
                new ShortGenerator(),
                new StringGenerator(),
                new URIGenerator(),
            };

    private readonly CyclicChecker _cyclicChecker = new();

    public Faker()
        {
            _generatorContext = new GeneratorContext(new Random(), this);
            _valueGenerators = GetAllGeneratorsFromAssembly();
        }

        private static List<IValueGenerator> GetAllGeneratorsFromAssembly()
        {
            var generatorsList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterfaces().Contains(typeof(IValueGenerator)) && t.IsClass)
                .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
            return generatorsList;
        }

        public T Create<T>()
        {
            return (T)CreateInstance(typeof(T));
        }

        public object Create(Type type)
        {
            return CreateInstance(type);
        }

        private object CreateInstance(Type type)
        {
            foreach (var generator in _valueGenerators)
            {
                if (generator.CanGenerate(type))
                    return generator.Generate(type, _generatorContext);
            }

            if (_cyclicChecker.IsCyclic(type))
                return null;

            var creatorService = new ObjectCreator(this);
            var initializeService = new ObjectInitor(this);

            var instance = creatorService.CreateObject(type);

            initializeService.InitFields(instance, type);
            initializeService.InitProps(instance, type);

            _cyclicChecker.DeleteFromCycle(type);

            return instance;
        }
    }
}