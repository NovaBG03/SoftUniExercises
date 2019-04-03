using System;
using System.Text;

namespace Mankind.Humans
{
    class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (char.IsLower(value[0]))
                {
                    NameUpperLetterException("firstName");
                }

                if (value.Length <= 3)
                {
                    NameLengthException("firstName", 4);
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (char.IsLower(value[0]))
                {
                    NameUpperLetterException("lastName");
                }

                if (value.Length <= 2)
                {
                    NameLengthException("lastName", 3);
                }

                lastName = value;
            }
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"First Name: {this.firstName}")
                .AppendLine($"Last Name: {this.LastName}");

            return builder.ToString();
        }

        private static void NameUpperLetterException(string field)
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {field}");
        }

        private static void NameLengthException(string field, int symbols)
        {
            throw new ArgumentException($"Expected length at least {symbols} symbols! Argument: {field}");
        }
    }
}
