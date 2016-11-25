
namespace Mini_Blog.DbData
{
    class DbDataProvider : Mini_Blog.DbData.Core.IDbDataProvider
    {
        private static System.Random _random = new System.Random();

        public virtual bool AddedToDb()
        {
            // add data to DB
            return true;
        }

        public virtual bool RemovedToDb()
        {
            // remove data from DB
            return true;
        }

        public virtual bool AddedDataRelation()
        {
            // add data relation
            return true;
        }

        public static bool IsAlreadyInDb(System.Text.StringBuilder key)
        {
            //try to check if data with some key ('ID' or 'Caption') are already in DB
            return false;
            //return _random.Next(1, 10) > 5;  
        }

        protected virtual void DataIsAddedToDb(string typeOfDataName)
        {
            //if data have been successfully added to DB then try send e-mail with notification to moderator 
        }
    }
}
