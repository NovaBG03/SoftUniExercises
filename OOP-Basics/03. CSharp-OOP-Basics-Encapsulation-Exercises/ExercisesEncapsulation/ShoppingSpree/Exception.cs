using System;

namespace ShoppingSpree
{
    static class Exception
    {
        static public void EmptyName()
        {
            throw new ArgumentException("Name cannot be empty."); ;
        }

        static public void NegativeMoney()
        {
            throw new ArgumentException("Money cannot be negative.");
        }

        static public void NotEnoughMoney(Person person, Product product)
        {
            throw new ArgumentException($"{person.Name} can't afford {product.Name}");
        }

    }
}
