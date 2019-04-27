namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Core.Factories;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private ICollection<IFood> menu;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;
        private decimal income;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
            income = 0;
        }


        public string AddFood(string type, string name, decimal price)
        {
            IFood food = this.foodFactory.CreateFood(type, name, price);

            if (food is null)
            {
                return null;//TODO throw exception
            }

            this.menu.Add(food);

            return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:F2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);

            if (drink is null)
            {
                return null;//TODO throw exception
            }

            this.drinks.Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateTable(type, tableNumber, capacity);

            if (table is null)
            {
                return null;//TODO throw exception
            }

            this.tables.Add(table);

            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if (table is null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.GetTable(tableNumber);

            if (table is null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood food = this.GetFood(foodName);

            if (food is null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        private IFood GetFood(string foodName)
        {
            return this.menu.FirstOrDefault(f => f.Name == foodName);
        }

        private ITable GetTable(int tableNumber)
        {
            return this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.GetTable(tableNumber);

            if (table is null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink drink = this.GetDrink(drinkName, drinkBrand);

            if (drink is null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        private IDrink GetDrink(string drinkName, string drinkBrand)
        {
            return this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = GetTable(tableNumber);

            if (table is null)
            {
                return null;
            }

            decimal bill = table.Price + table.GetBill();
            this.income += bill;
            
            table.Clear();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {bill:F2}");

            return builder.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var table in this.tables.Where(t => !t.IsReserved))
            {
                builder.AppendLine(table.GetFreeTableInfo());
            }

            return builder.ToString().Trim();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var table in this.tables.Where(t => t.IsReserved))
            {
                builder.AppendLine(table.GetOccupiedTableInfo());
            }

            return builder.ToString().Trim();
        } 

        public string GetSummary()
        {
            return $"Total income: {this.income:F2}lv";
        }
    }
}
