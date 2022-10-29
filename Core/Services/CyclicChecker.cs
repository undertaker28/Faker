namespace Faker.Core
{
    public class CyclicChecker
    {
        private Dictionary<Type, int> _nestingCounter = new ();
        private static int maxNestingLevel = 3;

        public bool IsCyclic(Type type)
        {
            if (_nestingCounter.ContainsKey(type))
            {
                _nestingCounter[type]++;
            }
            else
            {
                _nestingCounter.Add(type, 1);
            }

            return _nestingCounter[type] >= maxNestingLevel;
        }

        public void DeleteFromCycle(Type type)
        {
            _nestingCounter[type]--;
        }
    }
}