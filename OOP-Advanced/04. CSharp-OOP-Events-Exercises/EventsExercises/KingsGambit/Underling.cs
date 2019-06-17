namespace KingsGambit
{
    using System;

    public abstract class Underling
    {
        private int killLeft;

        public event EventHandler Killed;

        protected Underling(string name, int killLeft)
        {
            this.Name = name;
            this.KillLeft = killLeft;
        }

        public string Name { get; private set; }

        public int KillLeft
        {
            get => this.killLeft;
            protected set
            {
                if (value <= 0)
                {
                    this.OnKilled();
                }

                killLeft = value;
            }
        }

        public void Kill()
        {
            this.KillLeft--;
        }

        public abstract void OnKingBeingAttacked(object sender, EventArgs args);

        private void OnKilled()
        {
            this.Killed.Invoke(this, EventArgs.Empty);
        }
    }
}
