using System;

namespace GenericBox
{
    public class Box<T> : IComparable<Box<T>>
        where T : IComparable<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public static bool operator ==(Box<T> firstValue, Box<T> secondValue)
        {
            if (firstValue.value.CompareTo(secondValue.value) == 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Box<T> firstValue, Box<T> secondValue)
        {
            return !(firstValue == secondValue);
        }

        public static bool operator >(Box<T> firstValue, Box<T> secondValue)
        {
            if (firstValue.value.CompareTo(secondValue.value) == 1)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(Box<T> firstValue, Box<T> secondValue)
        {
            if (firstValue.value.CompareTo(secondValue.value) == -1)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.GetType().GenericTypeArguments[0].FullName}: {this.value}";
        }

        public int CompareTo(Box<T> other)
        {
            return this.value.CompareTo(other.value);
        }
    }
}
