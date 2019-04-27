using SoftUniRestaurant.Core;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            RestaurantController restaurantController = new RestaurantController();

            Engine engine = new Engine(restaurantController);
            engine.Run();
        }
    }
}
