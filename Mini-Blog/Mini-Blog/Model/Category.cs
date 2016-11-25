using System.Text;
using System.Collections.Generic;

using Mini_Blog.DbData;

namespace Mini_Blog.Model
{
    class Category : DbDataProvider
    {
        #region Fields & Properties
        public StringBuilder Caption { get; set; }
        public StringBuilder PostText { get; set; }

        private readonly IList<Post> _postList = new List<Post>();
        public IList<Post> PostList
        {
            get
            {
                return _postList;
            }
        }
        #endregion

        #region Constructors
        private Category(StringBuilder caption, StringBuilder postText)
        {
            Caption = caption;
            PostText = postText;
        }
        #endregion

        #region Methods

        #region Create Instance
        //Only for testing
        //------------------------------
        public static Category CreateInstance()
        {
            return CreateInstance(TestData.RandomData.GetRandomText(5, 10));
        }
        //------------------------------

        public static Category CreateInstance(string caption)
        {
            return CreateInstance(new StringBuilder(caption));
        }

        public static Category CreateInstance(StringBuilder caption)
        {
            if (!DbDataProvider.IsAlreadyInDb(caption))
            {
                var instance = new Category(caption, TestData.RandomData.GetRandomText(5, 25));
                if (instance.AddedToDb())
                {
                    instance.DataIsAddedToDb(instance.ToString());
                    return instance;
                }
            }
            return default(Category);
        }
        #endregion

        #region Add & Remove post
        public virtual bool AddPost(Post post)
        {
            if (post != null && _postList != null && !_postList.Contains(post))
            {
                _postList.Add(post);
                post.AddCategory(this);
                return true;
            }
            return false;
        }

        public virtual bool RemovePost(Post post)
        {
            if (post != null && _postList != null && _postList.Contains(post))
            {
                _postList.Remove(post);
                post.RemoveCategory(this);
                return true;
            }
            return false;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Such category has been added to db:\r\n -Caption: {0}\r\n -Description: {1}", this.Caption, this.PostText);
        }
        #endregion
    }
}
