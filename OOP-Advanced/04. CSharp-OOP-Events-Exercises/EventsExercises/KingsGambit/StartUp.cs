namespace KingsGambit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static King king;
        private static ICollection<Underling> underlings;

        public static void Main(string[] args)
        {
            string kingName = Console.ReadLine();
            king = new King(kingName);

            underlings = new List<Underling>();

            var royalGuardNames = Console.ReadLine().Split();
            royalGuardNames.Select(n => (Underling)new RoyalGuard(n))
                .ToList()
                .ForEach(u => underlings.Add(u));
            
            var footmanNames = Console.ReadLine().Split();
            footmanNames.Select(n => (Underling)new Footman(n))
                .ToList()
                .ForEach(u => underlings.Add(u));

            (underlings as List<Underling>)
                .ForEach(u => king.BeingAttacked += (u as Underling).OnKingBeingAttacked);

            (underlings as List<Underling>)
                .ForEach(u => (u as Underling).Killed += OnUnderlingKilled);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input == "Attack King")
                {
                    king.BeAttacked();
                }
                else if (input.StartsWith("Kill "))
                {
                    string name = input.Split()[1];

                    var underling = underlings.FirstOrDefault(r => r.Name == name);
                    if (underling != null)
                    {
                        underling.Kill();
                    }
                }
            }
        }

        private static void OnUnderlingKilled(object sender, EventArgs e)
        {
            var underling = sender as Underling;

            king.BeingAttacked -= underling.OnKingBeingAttacked;
            underlings.Remove(underling);
        }
    }
}
