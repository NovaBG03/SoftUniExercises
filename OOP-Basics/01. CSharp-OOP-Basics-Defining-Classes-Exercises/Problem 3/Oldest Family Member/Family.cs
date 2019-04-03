using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldest_Family_Member
{
    public class Family
    {
        private List<Person> people;


        public Family()
        {
            people = new List<Person>();
        }


        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }


        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldersMember()
        {
            Person oldestMember = people[0];

            foreach (Person person in people)
            {
                if (oldestMember.Age < person.Age)
                {
                    oldestMember = person;
                }
            }

            return oldestMember;
        }

    }
}
