namespace Lesson6_Practice1
{
    internal class Article
    {
        public Person Author { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }

        public Article(Person author, string name, double rating)
        {
            Author = author;
            Name = name;
            Rating = rating;
        }

        public Article()
        {
            Author = new Person();
            Name = "Unknown";
            Rating = 0;
        }

        public override string ToString()
        {
            return string.Format("Author: {0}, Name: \"{1}\", Rating: {2}", Author.ToShortString(), Name, Rating);
        }
    }
}
