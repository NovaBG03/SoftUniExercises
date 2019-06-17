namespace KingsGambit
{
    using System;

    public class King
    {
        public event EventHandler BeingAttacked;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void BeAttacked()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            OnBeingAttacked();
        }

        private void OnBeingAttacked()
        {
            BeingAttacked?.Invoke(this, EventArgs.Empty);
        }
    }
}
