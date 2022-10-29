namespace Tests
{
    public class Product
    {
        public string NameOfProduct { get; set; }
        public int Number { get; set; }
        public bool isPopular = false;
        public Uri ProductUri { get; set; }
        public List<Product> Products;

        public Product(string name, int num, bool flag, Uri productUri, List<Product> products)
        {
            NameOfProduct = name;
            Number = num;
            isPopular = flag;
            Products = products;
            ProductUri = productUri;
        }

        public Product(string name, int num, bool flag, Uri productUri)
        {
            this.NameOfProduct = name;
            this.Number = num;
            this.isPopular = flag;
            this.ProductUri = productUri;
        }

        private Product()
        {

        }
    }

    public class Polygon
    {
        public int NumOfCorners { get; set; }
        public string Name { get; set; }
        public bool IsPentagon = false;
        private double Square;

        public Polygon(int amount, string name, bool isPentag)
        {
            NumOfCorners = amount;
            Name = name;
            IsPentagon = isPentag;
        }
    }

    public class CycleClassA
    {
        public CycleClassB b { get; set; }
    }

    public class CycleClassB
    {
        public CycleClassC c { get; set; }
    }

    public class CycleClassC
    {
        public CycleClassA a { get; set; }
    }

    public struct MyStruct
    {
        public string Key;
        public int Value;

        public MyStruct(int value, string key)
        {
            Key = key;
            Value = value;
        }
    }
}