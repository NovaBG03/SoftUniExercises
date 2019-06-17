namespace EventImplementation
{
    using System;

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                this.OnNameChange(new NameChangeEventArgs(this.name));
            }
        }

        public event NameChangeEventHandler NameChange;

        private void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange.Invoke(this, args);
        }
    }
}
