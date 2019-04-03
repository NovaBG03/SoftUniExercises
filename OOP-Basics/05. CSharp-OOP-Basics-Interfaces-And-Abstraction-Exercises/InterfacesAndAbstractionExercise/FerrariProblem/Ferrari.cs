namespace FerrariProblem
{
    class Ferrari : ICar
    {
        public string Model { get; }

        public string DriverName { get; set; }


        public Ferrari()
        {
            this.Model = "488-Spider";
        }


        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }
    }
}
