
namespace Mini_Blog.DbData.Core
{
    interface IDbDataProvider
    {
        bool AddedToDb();
        bool RemovedToDb();
        bool AddedDataRelation();
    }
}
