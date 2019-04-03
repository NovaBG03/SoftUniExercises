namespace VehiclesProblem.Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        string Drive(double distance);

        void Refuele(double fuel);
    }
}
