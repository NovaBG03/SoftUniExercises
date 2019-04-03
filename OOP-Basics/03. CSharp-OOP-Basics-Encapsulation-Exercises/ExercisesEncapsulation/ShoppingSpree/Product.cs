
namespace ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception.EmptyName();
                }
                name = value;
            }
        }

        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    Exception.NegativeMoney();
                }
                cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
