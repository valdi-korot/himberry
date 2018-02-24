using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Himberry.Common.Data
{
    public abstract class QueryBase : IDisposable
    {
        protected DbContext DbContext;
        private string _procedureName;
        private Dictionary<string, object> parameters = new Dictionary<string, object>();

        internal QueryBase(DbContext dbContext, string procedureName)
        {
            DbContext = dbContext;
            _procedureName = procedureName;
        }

        public void AddParameter(string parametrName, object value)
        {
            parameters[parametrName] = value;
        }

        protected string BuildStringParams()
        {
            string stringParams = _procedureName + " "
                                  + string.Join(",", parameters.Keys.Select(p => "@" + p));
            return stringParams;
        }

        protected IReadOnlyCollection<SqlParameter> BuildSqlParameters()
        {
            var sqlParameters = parameters.Select(p => new SqlParameter(p.Key, p.Value)).ToList();
            return sqlParameters;
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}