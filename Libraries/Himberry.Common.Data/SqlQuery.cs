using System.Data.Entity;
using System.Linq;

namespace Himberry.Common.Data
{
    public sealed class SqlQuery<TResult> : QueryBase
    {
        public SqlQuery(DbContext dbContext, string procedureName) : base(dbContext, procedureName)
        { }

        public TResult[] GetResult()
        {
            var stringParams = BuildStringParams();
            var sqlParams = BuildSqlParameters();
            var result = sqlParams.Any()
                ? DbContext.Database.SqlQuery<TResult>(stringParams, sqlParams)
                : DbContext.Database.SqlQuery<TResult>(stringParams);

            return result.ToArrayAsync().Result;
        }
    }
}