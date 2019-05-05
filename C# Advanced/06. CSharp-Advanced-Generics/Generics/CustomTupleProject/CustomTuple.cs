namespace CustomTupleProject
{
    public class CustomTuple<T1, T2>
    {
        private T1 item1;
        private T2 item2;

        public CustomTuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }


        public T1 Item1
        {
            get { return item1; }
            private set { item1 = value; }
        }

        public T2 Item2
        {
            get { return item2; }
            private set { item2 = value; }
        }


        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}"; 
        }
    }
}
