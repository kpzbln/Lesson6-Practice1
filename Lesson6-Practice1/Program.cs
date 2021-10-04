using System;

namespace Lesson6_Practice1
{
    enum Frequency { weekly, monthly, yearly }

    internal class Program
    {
        static void Main(string[] args)
        {
            Magazine magazine = new("Vladislav Kumanov", Frequency.weekly, DateTime.Now, 1);
            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine();

            Console.WriteLine("Indexer(weekly): " + magazine[Frequency.weekly]);
            Console.WriteLine("Indexer(monthly): " + magazine[Frequency.monthly]);
            Console.WriteLine("Indexer(yearly): " + magazine[Frequency.yearly]);
            Console.WriteLine();

            magazine.Name = "MIREA";
            magazine.Frequency = Frequency.monthly;
            magazine.PublishDate = magazine.PublishDate.AddDays(-15);
            magazine.Edition = 2;
            magazine.Articles = new Article[]
            {
                new Article(new Person("Vladislav", "Kumanov", new DateTime(2002, 9, 7)), "How to open notepad",5),
                new Article(new Person("Vladislav", "Kumanov", new DateTime(2002, 9, 7)), "How to close notepad",5),
            };
            Console.WriteLine(magazine);
            Console.WriteLine();

            magazine.AddArticles(
                new Article(new Person("Vladislav", "Kumanov", new DateTime(2002, 9, 7)), "How to open browser", 5),
                new Article(new Person("Vladislav", "Kumanov", new DateTime(2002, 9, 7)), "How to close browser", 5)
                );
            Console.WriteLine(magazine);
            Console.WriteLine();

            Console.Write("Enter the number of rows and columns (separator: ' ' or ','): ");
            string inputString = Console.ReadLine();
            string[] inputRowsAndColumns= inputString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfRows = Convert.ToInt32(inputRowsAndColumns[0]);
            int numberOfColumns = Convert.ToInt32(inputRowsAndColumns[1]);

            Article[] array = new Article[numberOfRows * numberOfColumns];
            for (int element = numberOfRows * numberOfColumns - 1; element >= 0; element--)
            {
                array[element] = new Article();
            }
            
            Article[,] twoDimensionalArray = new Article[numberOfRows, numberOfColumns];
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    twoDimensionalArray[row, column] = new Article();
                }
            }
            
            Article[][] steppedArray = new Article[numberOfRows][];
            for (int row = 0; row < numberOfRows; row++)
            {
                steppedArray[row] = new Article[numberOfColumns];
                for (int column = 0; column < numberOfColumns; column++)
                {
                    steppedArray[row][column] = new Article();
                }
            }
            
            int startTime;

            startTime = Environment.TickCount;
            foreach(Article article in array)
            {
                article.Name = "How to open explorer";
            }
            Console.WriteLine("Array time: {0}", Environment.TickCount - startTime);


            startTime = Environment.TickCount;
            foreach (Article article in twoDimensionalArray)
            {
                article.Name = "How to open explorer";
            }
            Console.WriteLine("Two-Dimensional Array time: {0}", Environment.TickCount - startTime);

            startTime = Environment.TickCount;
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    steppedArray[row][column].Name = "How to open explorer";
                }
            }
            Console.WriteLine("Stepped Array time: {0}", Environment.TickCount - startTime);
        }
    }
}
