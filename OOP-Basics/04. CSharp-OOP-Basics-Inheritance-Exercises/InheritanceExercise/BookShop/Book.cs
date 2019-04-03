using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;


        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }


        public virtual string Title
        {
            get => title;
            set
            {
                if (value.Length < 3)
                {
                    InvalidTitleException();
                }
                title = value;
            }
        }

        public virtual string Author
        {
            get => author;
            set
            {
                IsNameInvalid(value);
                author = value;
            }
        }

        public virtual decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    InvalidPriceException();
                }
                price = value;
            }
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            return builder.ToString().TrimEnd();
        }

        private void InvalidPriceException()
        {
            throw new ArgumentException("Price not valid!");
        }

        private void IsNameInvalid(string fullName)
        {
            string secondName = fullName.Split()[1];
            if (char.IsDigit(secondName[0]))
            {
                throw new ArgumentException("Author not valid!");
            }
        }

        private void InvalidTitleException()
        {
            throw new ArgumentException("Title not valid!");
        }
    }
}
