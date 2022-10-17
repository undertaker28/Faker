using Faker.Interfaces;

namespace Faker.Core
{
    public class ObjectInitor
    {
        private readonly IFaker _faker;
        public ObjectInitor(IFaker faker)
        {
            _faker = faker;
        }

        public void InitFields(object obj, Type objectType)
        {
            var fields = objectType.GetFields().Where(f => !f.IsInitOnly);

            foreach (var field in fields)
            {
                try
                {
                    if (Equals(field.GetValue(obj), GetDefaultValue(field.FieldType)))
                        field.SetValue(obj, _faker.Create(field.FieldType));
                }
                catch { }
            }
        }

        public void InitProps(object obj, Type objectType)
        {
            var props = objectType.GetProperties().Where(p => p.CanWrite);

            foreach (var prop in props)
            {
                try
                {
                    if (Equals(prop.GetValue(obj), GetDefaultValue(prop.PropertyType)))
                        prop.SetValue(obj, _faker.Create(prop.PropertyType));
                }
                catch { }
            }
        }

        public static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}