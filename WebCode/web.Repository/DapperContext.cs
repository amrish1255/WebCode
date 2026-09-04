using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.Common;
using web.Interface.Repository;

namespace web.Repository
{
    public class DapperContext : IDapperContext
    {

        private readonly ILogger<DapperContext> _logger;
        private readonly string? _connectionString;

        public DapperContext(IConfiguration configuration, ILogger<DapperContext> logger)
        {
            _connectionString = configuration.GetConnectionString("DataBaseConnecction");
            _logger = logger;
        }

        public DbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<dynamic> ExecuteStoredProcedure(string SpName, object? parameters = null)
        {
            await using var _dbConnection = CreateConnection();
            try
            {
                await _dbConnection.OpenAsync();
                var result = await _dbConnection.QueryAsync(SpName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing stored procedure: {SpName}", SpName);
                return null;
            }
            finally
            {
                _dbConnection?.Close();
            }
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string SpName, object? parameters = null)
        {
            if (string.IsNullOrWhiteSpace(SpName))
                throw new ArgumentException("Stored procedure name cannot be null or empty.", nameof(SpName));
            await using var _dbConnection = CreateConnection();
            try
            {
                if (_dbConnection.State != ConnectionState.Open)
                    await _dbConnection.OpenAsync();

                return await _dbConnection.QueryAsync<T>(
                    SpName,
                    parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 60 /* Increase timeout to 60 seconds */
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing stored procedure: {SpName}", SpName);
                throw; 
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                    await _dbConnection.CloseAsync();
            }
        }

        public async Task<T> ExecuteQueryFirstOrDefaultAsync<T>(string SpName, object? parameters = null)
        {
            if (string.IsNullOrWhiteSpace(SpName))
                throw new ArgumentException("Stored procedure name cannot be null or empty.", nameof(SpName));
            await using var _dbConnection = CreateConnection();
            try
            {
                if (_dbConnection.State != ConnectionState.Open)
                    await _dbConnection.OpenAsync();

                return await _dbConnection.QueryFirstOrDefaultAsync<T>(SpName, parameters,commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing stored procedure: {SpName}", SpName);
                throw; 
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                    await _dbConnection.CloseAsync();
            }
        }

        public async Task<T> ExecuteStoredProcedureWithOutputAsync<T>(string SpName,DynamicParameters parameters,string outputParameterName)
        {
            if (string.IsNullOrWhiteSpace(SpName))
                throw new ArgumentException("Stored procedure name cannot be null or empty.", nameof(SpName));

            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters), "Parameters cannot be null.");

            await using var _dbConnection = CreateConnection();

            try
            {
                if (_dbConnection.State != ConnectionState.Open) await _dbConnection.OpenAsync();

                await _dbConnection.ExecuteAsync(
                    SpName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return parameters.Get<T>(outputParameterName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing stored procedure with output: {SpName}", SpName);
                throw; 
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open) await _dbConnection.CloseAsync();
            }
        }
    }
}