using Dapper;
using System.Data.Common;
namespace web.Interface.Repository
{
    public interface IDapperContext
    {
        public DbConnection CreateConnection();
        public Task<dynamic> ExecuteStoredProcedure(string SpName, object parameters);
        public Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string SpName, object parameters);
        public Task<T> ExecuteQueryFirstOrDefaultAsync<T>(string SpName, object parameters);
        public Task<T> ExecuteStoredProcedureWithOutputAsync<T>(string SpName, DynamicParameters parameters, string outputParameterName);


    }
}