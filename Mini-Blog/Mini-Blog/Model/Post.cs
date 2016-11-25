using System;
using System.Text;
using System.Collections.Generic;

using Mini_Blog.DbData;

namespace Mini_Blog.Model
{
    class Post : DbDataProvider
    {
        #region Fields & Properties
        public StringBuilder Caption { get; set; }
        public StringBuilder Description { get; set; }

        private readonly IList<Category> _categoryList = new List<Category>();
        public IList<Category> CategoryList
        {
            get
            {
                return _categoryList;
            }
        }
        #endregion

        #region Constructors
        private Post(StringBuilder caption, StringBuilder description)
        {
            Caption = caption;
            Description = description;
        }
        #endregion

        #region Methods

        #region Create Instance
        //Only for testing
        //------------------------------
        public static Post CreateInstance()
        {
            return CreateInstance(TestData.RandomData.GetRandomText(5, 10));
        }
        //------------------------------

        public static Post CreateInstance(string caption)
        {
            return CreateInstance(new StringBuilder(caption));
        }

        public static Post CreateInstance(StringBuilder caption)
        {
            if (!IsAlreadyInDb(caption))
            {
                var instance = new Post(caption, TestData.RandomData.GetRandomText(5, 80));
                if (instance.AddedToDb())
                {
                    instance.DataIsAddedToDb(instance.ToString());
                    return instance;
                }
            }
            return default(Post);
        }
        #endregion

        #region Add & Remove categoty
        public virtual bool AddCategory(Category category)
        {
            if (category != null && _categoryList != null && !_categoryList.Contains(category))
            {
                _categoryList.Add(category);
                category.AddPost(this);
                return true;
            }
            return false;
        }

        public virtual bool RemoveCategory(Category category)
        {
            if (category != null && _categoryList != null && _categoryList.Contains(category))
            {
                _categoryList.Remove(category);
                category.RemovePost(this);
                return true;
            }
            return false;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Such post has been added to db:\r\n -Caption: {0}\r\n -Description: {1}", Caption, Description);
        }
        #endregion
    }
}
