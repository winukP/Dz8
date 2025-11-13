using System;

namespace D.Classes
{
    public class Person
    {
        public string Name { get; set; }
        public string Role { get; set; }

        public Person(string name, string role)
        {
            Name = name;
            Role = role;
        }
    }
}
