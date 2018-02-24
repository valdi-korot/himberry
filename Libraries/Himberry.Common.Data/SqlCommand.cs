using System.Data.Entity;
using System.Linq;

namespace Himberry.Common.Data
{
    public sealed class SqlCommand : QueryBase
    {
        public SqlCommand(DbContext dbContext, string procedureName) : base(dbContext, procedureName)
        { }

        public int Execute()
        {
            var stringParams = BuildStringParams();
            var sqlParams = BuildSqlParameters();
            var result = sqlParams.Any()
                ? DbContext.Database.ExecuteSqlCommand("EXEC " + stringParams, sqlParams)
                : DbContext.Database.ExecuteSqlCommand("EXEC " + stringParams);
            return result;
        }
    }
}