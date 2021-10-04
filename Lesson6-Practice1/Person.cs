using System;

namespace Lesson6_Practice1
{
    internal class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthday;

       public Person(string firstName, string lastName, DateTime birtday)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birtday;
        }

        public Person()
        {
            firstName = "Unknown";
            lastName = "Unknown";
            birthday = new DateTime();
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int BirthYear
        {
            get { return birthday.Year; }
            set { birthday.AddYears(value - birthday.Year); }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, birthday: {2}", firstName, lastName, birthday);
        }

        public virtual string ToShortString()
        {
            return string.Format("{0} {1}", firstName, lastName);
        }
    }
}
