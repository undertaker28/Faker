using Faker.Context;
using Faker.Interfaces;
using System.Collections.Specialized;

namespace Core.Generators
{
    public class URIGenerator : IValueGenerator
    {
        private static List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        private static List<char> alphabetSymbol = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        private static List<String> schemes = new List<String>() { "http", "https", "ftp", "mailto", "file", "data", "irc" };
        public bool CanGenerate(Type type) => type == typeof(Uri);
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            Random rand = new();

            int randomScheme = rand.Next(0, 3);
            var scheme = schemes[randomScheme];

            var domain = "";
            const int maxDomainLength = 63;
            var tempDomainLength = 0;
            int numOfDomains = rand.Next(1, 31);
            int maxSymbolsInDomainLevel = maxDomainLength / numOfDomains;
            for (int i = 1; i <= numOfDomains; i++)
            {
                for (int j = 1; j <= rand.Next(1, i * maxSymbolsInDomainLevel - tempDomainLength); j++)
                    domain += alphabetSymbol[rand.Next(0, alphabetSymbol.Count)].ToString();

                domain += ".";
                tempDomainLength = domain.Length;
            }

            var path = "";
            int nestingCounter = rand.Next(1, 6);
            for (int i = 1; i <= nestingCounter; i++)
            {
                for (int j = 1; j <= rand.Next(1, 11); j++)
                    path += alphabetSymbol[rand.Next(0, alphabetSymbol.Count)].ToString();

                path += "/";
            }

            int numOfParameters = rand.Next(1, 6);
            var value = "";
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            for (int i = 1; i <= numOfParameters; i++)
            {
                for (int j = 1; j <= rand.Next(1, 8); j++)
                    value += rand.Next(1, 3) == 1 ? numbers[rand.Next(0, numbers.Count)].ToString() : alphabetSymbol[rand.Next(0, alphabetSymbol.Count)].ToString();

                queryString.Add("key" + i, value);
            }

            return new Uri(scheme + "://" + domain.Remove(domain.Length - 1) + "/" + path + queryString.ToString());
        }
    }
}
