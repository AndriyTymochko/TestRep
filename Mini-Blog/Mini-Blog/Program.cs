using System;
using System.Collections.Generic;

namespace Mini_Blog
{
    class Program
    {
        private static readonly TestData.RandomData _randomDataProvider = new TestData.RandomData();

        static void Main(string[] args)
        {
            ushort categoryCount = 0, postCount = 0;
            if (!GetInputParamForDataGenerating(ref categoryCount, ref postCount))
                return;


            IList<DbData.Core.IDbDataProvider> allData = _randomDataProvider.GetConnectedPostsWithCategories(
                _randomDataProvider.GetGeneratedPosts(postCount),
                _randomDataProvider.GetGeneratedCategories(categoryCount));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Test data have been succesfully generated!");
            Console.ReadLine();
        }


        private static bool GetInputParamForDataGenerating(ref ushort categoryCount, ref ushort postCount)
        {
            try
            {
                string inputedCategoryCount, inputedPostCount;
                do
                {
                    Console.Write("\nEnter # of categories that must be generated (or 'x' for exit): ");
                    inputedCategoryCount = Console.ReadLine();
                    if (inputedCategoryCount.ToLower() == "x")
                        return false;

                    Console.Write("Enter # of posts that must be generated (or 'x' for exit): ");
                    inputedPostCount = Console.ReadLine();
                    if (inputedPostCount.ToLower() == "x")
                        return false;

                } while (!ushort.TryParse(inputedCategoryCount, out categoryCount) || !ushort.TryParse(inputedPostCount, out postCount));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
