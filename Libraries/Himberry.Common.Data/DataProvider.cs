using System.Data.Entity;

namespace Himberry.Common.Data
{
    public sealed class DataProvider
    {
        private DbContext _dbContext;

        public DataProvider(string connectionString)
        {
            _dbContext = new DbContext(connectionString);
        }

        public SqlQuery<TResult> SqlQuery<TResult>(string procedureName)
        {
            var sqlQuery = new SqlQuery<TResult>(_dbContext, procedureName);
            return sqlQuery;
        }

        public SqlCommand SqlCommand(string procedureName)
        {
            var sqlCommand = new SqlCommand(_dbContext, procedureName);
            return sqlCommand;
        }
    }
}