namespace Faker.Interfaces
{
    public interface IValueGenerator
    {
        object Generate(Type type);
        bool CanGenerate(Type type);
    }
}