using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Robot : IId
    {
        public Robot(string model, string id)
        {
            this.Id = id;
            this.Model = model;
        }


        public string Id { get; private set; }

        public string Model { get; private set; }
    }
}
