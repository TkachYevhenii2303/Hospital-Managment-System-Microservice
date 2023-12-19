using Dapper;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.Domains.Common.Interfaces;
using HospitalManagementSystem.Domains.Generics.Interfaces;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace HospitalManagementSystem.Domains.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : IEntity
    {
        protected readonly SqlConnection _connection;

        protected readonly IDbTransaction _transaction;

        protected readonly string _table;

        public GenericRepository(SqlConnection connection, IDbTransaction transaction, string table)
        {
            _connection = connection;

            _transaction = transaction;

            _table = table;
        }

        public async Task<Response<IEnumerable<TEntity>>> GetEntitiesAsync()
        {
            var result = new Response<IEnumerable<TEntity>>();

            var request = $"Select * from {_table}";

            result.Data = await _connection.QueryAsync<TEntity>(request, transaction: _transaction);

            result.Message = $"Fetching operation was succesfull!";

            return result;
        }

        public async Task<Response<TEntity>> GetEntityByIdAsync(Guid Id)
        {
            var result = new Response<TEntity>();

            var request = $"Select * from {_table} where Id = @Id";

            result.Data =
                await _connection.QuerySingleOrDefaultAsync<TEntity>(request, param: new { Id }, transaction: _transaction);

            if (result.Data is null)
            {
                result.Message = $"We could not found entity with {Id} Id!";
                result.Success = false;
                throw new Exception($"Entity with {Id} Id could not be found!");
            }

            result.Message = "Fetching operation was succesfull!";

            return result;
        }

        public async Task<Response<IEnumerable<TEntity>>> InsertEntityAsync(TEntity entity)
        {
            var result = new Response<IEnumerable<TEntity>>();

            entity.CreatedDateTime = DateTime.Now;

            var request = InsertRequest();

            await _connection.ExecuteAsync(request, param: entity, transaction: _transaction);

            result.Data = await _connection.QueryAsync<TEntity>($"Select * from {_table}", transaction: _transaction);

            return result;
        }

        public async Task<Response<IEnumerable<TEntity>>> UpdateEntityAsync(TEntity entity)
        {
            var result = new Response<IEnumerable<TEntity>>();

            entity.CreatedDateTime = DateTime.Now;
            entity.UpdatedDateTime = DateTime.Now;

            try
            {
                var request = UpdateRequest();

                await _connection.ExecuteAsync(request, param: entity, transaction: _transaction);
            }
            catch (Exception exceptions)
            {
                result.Message = "We have the problem with Update Request!";
                result.Success = false;
                throw new Exception($"Something went wrong... {exceptions.Message}");
            }

            result.Data = await _connection.QueryAsync<TEntity>($"Select * from {_table}", transaction: _transaction);

            return result;
        }

        public async Task<Response<IEnumerable<TEntity>>> DeleteEntityAsync(Guid Id)
        {
            var result = new Response<IEnumerable<TEntity>>();

            var request = $"Delete from {_table} where Id = @Id";

            await _connection.ExecuteAsync(request, new { Id }, transaction: _transaction);

            result.Data = await _connection.QueryAsync<TEntity>($"Select * From {_table}", transaction: _transaction);

            return result;
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(TEntity).GetProperties();

        private static List<string> Properties(IEnumerable<PropertyInfo> properties)
        {
            return (from property in properties
                    let attributes =
                property.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 ||
                (attributes[0] as DescriptionAttribute)?.Description != "ingore"
                    select property.Name).ToList();
        }

        private string InsertRequest()
        {
            var builder = new StringBuilder($"Insert into {_table}");
            builder.Append(" (");

            var properties = Properties(GetProperties);
            properties.ForEach(property => { builder.Append($"[{property}],"); });

            builder.Remove(builder.Length - 1, 1).Append(") Values (");

            properties.ForEach(property => { builder.Append($"@{property},"); });

            builder.Remove(builder.Length - 1, 1).Append(")");

            return builder.ToString();
        }

        private string UpdateRequest()
        {
            var builder = new StringBuilder($"Update {_table} set ");
            var properties = Properties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    builder.Append($"{property} = @{property},");
                }
            });

            builder.Remove(builder.Length - 1, 1).Append(" Where Id = @Id");

            return builder.ToString();
        }
    }
}
