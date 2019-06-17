namespace KingsGambit
{
    using System;

    public class RoyalGuard : Underling
    {
        private const int DefaultKillLeft = 3;

        public RoyalGuard(string name)
            : base(name, DefaultKillLeft)
        {
            
        }

        public override void OnKingBeingAttacked(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
