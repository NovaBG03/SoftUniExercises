namespace StrategyPattern
{
    public class Person 
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }


        public string Name { get; private set; }

        public int Age { get; private set; }


        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Age);
        }
    }
}