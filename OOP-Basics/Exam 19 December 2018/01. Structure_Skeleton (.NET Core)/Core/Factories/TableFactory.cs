using SoftUniRestaurant.Models.Tables;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Core.Factories
{
    public class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    return new InsideTable(tableNumber, capacity);
                case "Outside":
                    return new OutsideTable(tableNumber, capacity);
                default:
                    return null;
            }
        }
    }
}
