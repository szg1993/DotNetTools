namespace ExGuard
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<string> Childs { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Childs = new List<string>() { "Töhötöm", "Orália" };
        }
    }
}