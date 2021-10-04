using System;

namespace Lesson6_Practice1
{
    internal class Magazine
    {
        private string name;
        private Frequency frequency;
        private DateTime publishDate;
        private int edition;
        private Article[] articles;

        public Magazine(string name, Frequency frequency, DateTime publishDate, int edition)
        {
            this.name = name;
            this.frequency = frequency;
            this.publishDate = publishDate;
            this.edition = edition;
        }

        public Magazine()
        {
            this.name = "Unknown";
            this.frequency = Frequency.weekly;
            this.publishDate = new DateTime();
            this.edition = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Frequency Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        public int Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        public Article[] Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        public double AverageRating
        {
            get {
                if (articles == null) return 0;
                int numberOfArticles = articles.Length;

                double totalRating = 0;

                foreach (Article article in articles)
                {
                    totalRating += article.Rating;
                }

                return totalRating / numberOfArticles;
            }
        }

        public bool this[Frequency frequency]
        {
            get { return this.frequency == frequency; }
        }

        public void AddArticles(params Article[] newArticles)
        {
            if (newArticles.Length == 0) return;

            if (articles == null)
            {
                articles = Array.Empty<Article>();
            }

            int oldLength = articles.Length;
            Array.Resize(ref articles, articles.Length + newArticles.Length);
            Array.Copy(newArticles, 0, articles, oldLength, newArticles.Length);
        }

        public override string ToString()
        {
            string resultString =
                $"Name: {name}, " +
                $"Frequency: {frequency}" +
                $"\nPublish date: {publishDate.ToShortDateString()}, " +
                $"Edition: {edition}, " +
                $"Average rating: {AverageRating}";

            if (articles == null) return resultString;

            resultString += "\nArticles:";

            foreach (Article article in articles)
            {
                resultString += "\n" + article.ToString();
            }

            return resultString;
        }

        public virtual string ToShortString()
        {

            return $"Name: {name}," +
                $" Frequency: {frequency}" +
                $"\nPublish date: {publishDate.ToShortDateString()}," +
                $" Edition: {edition}, " +
                $"Average rating: {AverageRating}";
        }
    }
}
