namespace Database
{
    using System;

    public class Database
    {
        private const int DefaultArrayCapacity = 16;

        private int[] array;
        private int index;

        private Database()
        {
            this.array = new int[Database.DefaultArrayCapacity];
            this.index = 0;
        }

        public Database(params int[] numbers)
            : this()
        {
            foreach (var number in numbers)
            {
                this.Add(number);
            }
        }

        public void Add(int number)
        {
            if (index >= Database.DefaultArrayCapacity)
            {
                throw new InvalidOperationException("Database size can't be more than 16 integers long.");
            }

            this.array[this.index++] = number;
        }

        public void Remove()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("Can't remove from empty database.");
            }

            this.array[--this.index] = 0;
        }

        public int[] Fetch()
        {
            int[] result = new int[this.index];

            for (int i = 0; i < this.index; i++)
            {
                result[i] = this.array[i];
            }

            return result;
        }
    }
}
