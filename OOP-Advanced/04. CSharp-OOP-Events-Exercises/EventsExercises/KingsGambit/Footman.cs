namespace KingsGambit
{
    using System;

    public class Footman : Underling
    {
        private const int DefaultKillLeft = 2;

        public Footman(string name)
            : base(name, DefaultKillLeft)
        {

        }

        public override void OnKingBeingAttacked(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
