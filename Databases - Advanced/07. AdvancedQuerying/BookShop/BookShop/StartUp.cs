namespace BookShop
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    using Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //var input = Console.ReadLine();
                string result;

                using (BookShopContext context = new BookShopContext())
                {
                    result = RemoveBooks(context).ToString();
                }

                Console.WriteLine(result);

            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, ignoreCase: true);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            var bookTitlesString = string.Join(Environment.NewLine, bookTitles);

            return bookTitlesString;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var targetBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold
                        && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            var bookTitlesString = string.Join(Environment.NewLine, targetBooks);

            return bookTitlesString;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var targetBooks = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:F2}")
                .ToArray();

            var bookString = string.Join(Environment.NewLine, targetBooks);

            return bookString;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var targetBooks = context.Books
                .Where(b =>  b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            var bookString = string.Join(Environment.NewLine, targetBooks);

            return bookString;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var targetBooks = context.Books
                .Where(b => b.BookCategories.All(c => categories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            var bookString = string.Join(Environment.NewLine, targetBooks);

            return bookString;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var specificDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var targetBooks = context.Books
                .Where(b => b.ReleaseDate.Value < specificDate)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToArray();

            var bookString = string.Join(Environment.NewLine, targetBooks);

            return bookString;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var names = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(x => x)
                .ToArray();

            var result = string.Join(Environment.NewLine, names);

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var inputToLower = input.ToLower();

            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(inputToLower))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            var result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var inputToLower = input.ToLower();

            var lines = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(inputToLower))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            var result = string.Join(Environment.NewLine, lines);

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var lines = context.Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    CopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.CopiesCount)
                .Select(x => $"{x.AuthorName} - {x.CopiesCount}")
                .ToArray();

            var result = string.Join(Environment.NewLine, lines);

            return result;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var lines = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.CategoryName)
                .Select(x => $"{x.CategoryName} ${x.TotalProfit:F2}")
                .ToArray();

            var result = string.Join(Environment.NewLine, lines);

            return result;
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    LastThreeBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Select(cb => new
                        {
                            Title = cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate.Value.Year
                        })
                        .ToArray()
                })
                .ToArray();

            var builder = new StringBuilder();

            foreach (var category in categories)
            {
                builder.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.LastThreeBooks)
                {
                    builder.AppendLine($"{book.Title} ({book.ReleaseYear})");
                }
            }

            return builder.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            var result = context.SaveChanges();

            return books.Count;
        }
    }
}
