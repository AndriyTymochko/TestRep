using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using Mini_Blog.Model;
using Mini_Blog.DbData.Core;

namespace Mini_Blog.TestData
{
    class RandomData
    {
        #region Fields
        private static readonly Random _random = new Random();
        #endregion

        #region Methods
        public static StringBuilder GetRandomText(ushort minCharts = 1, ushort maxChars = 1)
        {
            try
            {
                var chars = "0123456789abcdefghijklmnopqrstuvwxyz";
                return new StringBuilder(new String(chars.Select(c => chars[_random.Next(chars.Length)]).Take(_random.Next(minCharts, maxChars)).ToArray()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(StringBuilder);
            }
        }

        public virtual IList<Post> GetGeneratedPosts(ushort capacity)
        {
            try
            {
                List<Post> dataList = new List<Post>();
                for (ushort i = 1; i <= capacity; i++)
                {
                    Post post = Post.CreateInstance();
                    if (post != default(Post))
                        dataList.Add(Post.CreateInstance());
                }
                return dataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Post>();
            }
        }
        public virtual IList<Category> GetGeneratedCategories(ushort capacity)
        {
            try
            {
                List<Category> dataList = new List<Category>();
                for (ushort i = 1; i <= capacity; i++)
                {
                    Category category = Category.CreateInstance();
                    if (category != default(Category))
                        dataList.Add(Category.CreateInstance());
                }
                return dataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Category>();
            }
        }

        public virtual IList<IDbDataProvider> GetConnectedPostsWithCategories(IList<Post> postsList, IList<Category> categoryList)
        {
            try
            {
                categoryList.ForEach(x =>
                {
                    Console.WriteLine("\n-----------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(x.ToString());
                    Console.ResetColor();

                    int postsCount = _random.Next(1, postsList.Count + 1);
                    for (ushort i = 1; i <= postsCount; i++)
                        if (x.AddPost(postsList[_random.Next(0, postsList.Count)]))
                            Console.WriteLine(x.PostList.LastOrDefault().ToString());
                    Console.WriteLine("-----------------------------------------------------------------");
                });
                return new List<IDbDataProvider>(categoryList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<IDbDataProvider>(categoryList);
            }
        }
        #endregion
    }
}
