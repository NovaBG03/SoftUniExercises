using System.Collections.Generic;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
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

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    Exception.NegativeMoney();
                }
                money = value;
            }
        }

        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Exception.NotEnoughMoney(this, product);
            }

            this.Money -= product.Cost;
            this.Products.Add(product);
        }

        public override string ToString()
        {
            if (this.Products.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            return $"{this.Name} - {string.Join(", ", this.Products)}";
        }
    }
}
