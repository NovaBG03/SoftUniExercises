namespace FerrariProblem
{
    public interface ICar
    {
        string Model { get; }

        string DriverName { get; set; }

        string PushBrakes();

        string PushGasPedal();
    }
}
