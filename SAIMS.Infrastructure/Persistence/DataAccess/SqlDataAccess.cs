
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace SAIMS.Infrastructure.DataAccess;
public class SqlDataAccess : ISqlDataAccess
{
    /*
    https://exceptionnotfound.net/implementing-a-generic-dapper-repository-in-asp-net-core/
    */
    private readonly IConfiguration _configuration;

    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<TModel?> LoadSingle<TModel>(string storedProcedure, string connectionID = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        return await connection.QueryFirstOrDefaultAsync<TModel>(storedProcedure, commandType: CommandType.StoredProcedure);
    }

    public async Task<TModel?> LoadSingle<TModel, TParams>(string storedProcedure, TParams parameters, string connectionID = "Default") where TParams : class
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        return await connection.QueryFirstOrDefaultAsync<TModel>(storedProcedure, parameters);
    }

    public async Task<T> LoadValue<T>(string storedProcedure, Func<dynamic, T> valueSelector, string connectionID = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        dynamic record = await connection.QueryFirstAsync(storedProcedure, commandType: CommandType.StoredProcedure);
        return valueSelector(record);
    }

    public async Task<T> LoadValue<TModel, T>(string storedProcedure, Func<TModel, T> valueSelector, string connectionID = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        dynamic? record = await connection.QueryFirstAsync<TModel>(storedProcedure, commandType: CommandType.StoredProcedure);
        return valueSelector(record);
    }

    public async Task<IEnumerable<TModel>> LoadData<TModel>(string storedProcedure, string connectionID = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        return await connection.QueryAsync<TModel>(storedProcedure, commandType: CommandType.StoredProcedure);
    }
    
    public async Task<IEnumerable<TModel>> LoadQueryAsync<TModel>(string sql, Object parameters, string connectionID = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        // Execute the stored procedure with CommandType.StoredProcedure
        return await connection.QueryAsync<TModel>(sql, parameters);
    }

    public async Task<IEnumerable<TModel>> LoadData<TModel, TParams>(string storedProcedure, TParams parameters, string connectionID = "Default") where TParams : class
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        return await connection.QueryAsync<TModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<TParams>(string storedProcedure, TParams parameters, string connectionID = "Default") where TParams : class
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> SaveDataAndGetReturnInt<TParams>(string storedProcedure, TParams parameters, string connectionID = "Default") where TParams : class
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        DynamicParameters ps = new();
        ps.AddDynamicParams(parameters);
        ps.Add("@return", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
        await connection.ExecuteAsync(storedProcedure, ps, commandType: CommandType.StoredProcedure);
        return ps.Get<int>("@return");
    }

    public async Task<int> SaveRecordsAndGetCount<TParams>(string storedProcedure, TParams parameters, string countParamName, string connectionID = "Default") where TParams : class
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        DynamicParameters ps = new();
        ps.AddDynamicParams(parameters);
        ps.Add(countParamName, dbType: DbType.Int32, direction: ParameterDirection.Output);
        await connection.ExecuteAsync(storedProcedure, ps, commandType: CommandType.StoredProcedure);
        return ps.Get<int>(countParamName);
    }

    public async Task<IMultipleResultSets> LoadMultiple<TParams>(string storedProcedure, TParams parameters, string connectionID = "Default") where TParams : class
    {
        IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        return new MultipleResultSets(await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure), connection);
    }

    public List<TModel> Query<TModel,TParams>(string query, TParams parameters, string connectionID = "Default") where TParams : class
    {
        IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        return connection.Query<TModel>(query, parameters).ToList();
    }


    public class MultipleResultSets : IMultipleResultSets, IDisposable
    {
        private readonly SqlMapper.GridReader _multi;
        private readonly IDbConnection _dbConnection;

        public MultipleResultSets(SqlMapper.GridReader multi, IDbConnection dbConnection)
        {
            _multi = multi;
            _dbConnection = dbConnection;
        }

        public IMultipleResultSets Read<TModel>(out IEnumerable<TModel> data)
        {
            data = _multi.Read<TModel>();
            return this;
        }

        public IMultipleResultSets ReadSingle<TModel>(out TModel? data)
        {
            data = _multi.Read<TModel?>().FirstOrDefault();
            return this;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _multi.Dispose();
            _dbConnection.Dispose();
        }
    }


}
