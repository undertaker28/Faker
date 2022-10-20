using Faker.Core;
using Faker.Interfaces;
using System.Collections;

namespace Tests
{
    public class Tests
    {
        private IFaker _faker;

        [SetUp]
        public void Setup()
        {
            _faker = new Faker.Core.Faker();
        }

        [Test]
        [TestCase(typeof(bool))]
        [TestCase(typeof(byte))]
        [TestCase(typeof(char))]
        [TestCase(typeof(DateTime))]
        [TestCase(typeof(decimal))]
        [TestCase(typeof(double))]
        [TestCase(typeof(float))]
        [TestCase(typeof(int))]
        [TestCase(typeof(List<int>))]
        [TestCase(typeof(List<List<int>>))]
        [TestCase(typeof(long))]
        [TestCase(typeof(string))]
        [TestCase(typeof(short))]
        public void CreateSimpleType(Type type)
        {
            Assert.That(_faker.Create(type), Is.Not.EqualTo(ObjectInitor.GetDefaultValue(type)));
        }

        [Test]
        public void CreateCustomType()
        {
            Polygon poly = _faker.Create<Polygon>();
            Assert.Multiple(() =>
            {
                Assert.That(poly.NumOfCorners, Is.Not.EqualTo(ObjectInitor.GetDefaultValue(poly.NumOfCorners.GetType())));
                Assert.That(poly.Name, Is.Not.EqualTo(ObjectInitor.GetDefaultValue(poly.Name.GetType())));
                Assert.That(poly.IsPentagon, Is.Not.EqualTo(ObjectInitor.GetDefaultValue(poly.IsPentagon.GetType())));
            });
        }

        [Test]
        public void CreateCycleDependency()
        {
            Assert.DoesNotThrow(() => _faker.Create<CycleClassA>());
        }

        [Test]
        public void CheckCycleDependency()
        {
            CycleClassA a = _faker.Create<CycleClassA>();
            Assert.Multiple(() =>
            {
                Assert.That(a.b, Is.Not.EqualTo(ObjectInitor.GetDefaultValue(a.b.GetType())));
                Assert.That(a.b.c, Is.Not.EqualTo(ObjectInitor.GetDefaultValue(a.b.c.GetType())));
                Assert.That(a.b.c.a, Is.Not.EqualTo(ObjectInitor.GetDefaultValue(a.b.c.a.GetType())));
            });
        }

        [Test]
        public void CreateStructCtor()
        {
            MyStruct s = _faker.Create<MyStruct>();

            Assert.Multiple(() =>
            {
                Assert.That(s.Key, Is.Not.EqualTo(ObjectInitor.GetDefaultValue(s.Key.GetType())));
                Assert.That(s.Value, Is.Not.EqualTo(ObjectInitor.GetDefaultValue(s.Value.GetType())));
            });
        }

        [Test]
        public void CreateSimpleList()
        {
            List<int> list = _faker.Create<List<int>>();
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(list);
                Assert.NotZero(list.Count);
                Assert.That(list.Where(x => x == 0).Count(), Is.EqualTo(0));
            });
        }

        [Test]
        [TestCase(typeof(List<List<Product>>))]
        [TestCase(typeof(List<List<int>>))]
        public void CreateCustomList(Type type)
        {
            var list = (IList)_faker.Create(type);

            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(list);
                Assert.IsNotEmpty((IList)list[0]);
            });
        }
    }
}