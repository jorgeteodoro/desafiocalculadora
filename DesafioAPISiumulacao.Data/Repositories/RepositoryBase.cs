using Dapper.FluentMap.Mapping;
using Dapper.FluentMap;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;
using Dommel;
using Newtonsoft.Json;
using System.Linq;
using System.Data.SqlClient;
using DesafioAPISimulacao.Domain;
using DesafioAPISiumulacao.Data.Contracts;

namespace DesafioAPISimulacao.Data
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {

        protected SqlConnection _connection;
        protected SqlTransaction _transaction;
        protected bool inTransaction;
        protected IConfiguration _configuration;
        protected string ConnectionStringName = "Connection";

        protected RepositoryBase(IConfiguration config)
        {
            _configuration = config;
            inTransaction = false;

        }

        public IDbConnection getConnection()
        {
            if (inTransaction)
                return _connection;
            else
                return new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
        }

        public async Task<int> Insert(TEntity entity, bool normalizeString = false)
        {

            if (FluentMapper.EntityMaps.ContainsKey(typeof(TEntity)))
            {
                var map = (dynamic)FluentMapper.EntityMaps[typeof(TEntity)];
                StringBuilder fields = new StringBuilder();
                StringBuilder values = new StringBuilder();
                PropertyInfo idProp = null;
                string tableName = map.TableName;
                string idColumn = string.Empty;
                bool firstField = true;
                foreach (var prop in map.PropertyMaps)
                {
                    if (!prop.Ignored && prop.GeneratedOption != System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)
                    {
                        var propertie = (PropertyInfo)prop.PropertyInfo;
                        if (!Attribute.IsDefined(propertie, typeof(IsVirtual)) && !((IPropertyMap)prop).Ignored)
                        {
                            if (prop.Key)
                            {
                                idProp = (PropertyInfo)prop.PropertyInfo;
                                idColumn = Quote(prop.ColumnName);
                            }
                            else
                            {
                                if (!firstField)
                                {
                                    fields.Append(",");
                                    values.Append(",");
                                }
                                else
                                    firstField = false;
                                object? value = propertie.GetValue(entity);
                                fields.Append(prop.ColumnName);
                                values.Append($"{ObjectToString(propertie, value, normalizeString)}");
                            }
                        }
                    }
                }
                string insertQuery = $"INSERT INTO {tableName} ({fields}) VALUES ({values}); SELECT CAST(SCOPE_IDENTITY() as int)";
                try
                {
                    if (!inTransaction)
                        using (var db = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName)))
                            return await db.ExecuteScalarAsync<int>(insertQuery);
                    else
                        return await _connection.ExecuteScalarAsync<int>(insertQuery);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return 0;
        }

        private string Quote(string value)
        {
            return $"\"{value}\"";
        }

        private string NormalizeString(string text)
        {
            return new string(text.Normalize(NormalizationForm.FormD).Where(a => char.GetUnicodeCategory(a) != UnicodeCategory.NonSpacingMark).ToArray());
        }

        private object ObjectToString(PropertyInfo propertie, object o, bool removeDiacritics = false)
        {
            if (o == null)
                return "null";
            Type objType = o.GetType();
            objType = Nullable.GetUnderlyingType(objType) ?? objType;

            if (Attribute.IsDefined(propertie, typeof(IsJsonAttribute)))
                return string.Format("'{0}'::JSON", o);
            else if (objType.Equals(typeof(string)))
            {
                if (removeDiacritics)
                {
                    return "'" + (NormalizeString((string)o).TrimStart().Trim()).Replace("'", "''") + "'";
                }
                return "'" + ((string)o).TrimStart().Trim().Replace("'", "''") + "'";
            }
            else if (objType.Name.Equals("DateTime"))
                return string.Format("'{0}'", ((DateTime)o).ToString("yyyy-MM-dd HH:mm:ss"));
            else if (objType.Name.Equals("TimeSpan"))
                return string.Format("'{0}'", o.ToString());
            else if (o is float
                    || o is double
                    || o is decimal)
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                nfi.NumberGroupSeparator = "";
                return ((double)o).ToString(nfi);
            }
            else if (o is sbyte
                    || o is byte
                    || o is short
#pragma warning disable CS0184 // 'is' expression's given expression is never of the provided type
              || 0 is ushort
#pragma warning restore CS0184 // 'is' expression's given expression is never of the provided type
#pragma warning disable CS0183 // 'is' expression's given expression is always of the provided type
              || 0 is int
#pragma warning restore CS0183 // 'is' expression's given expression is always of the provided type
#pragma warning disable CS0184 // 'is' expression's given expression is never of the provided type
              || 0 is uint
#pragma warning restore CS0184 // 'is' expression's given expression is never of the provided type
              || o is long
                    || o is ulong)
                return o.ToString().TrimStart().Trim();
            else if (objType.IsPrimitive)
                return o.ToString().TrimStart().Trim();
            else
                return "'" + JsonConvert.SerializeObject(o).ToString() + "'::JSON";
        }

        private string GetSchema(Type type)
        {
            Type entityType;
            if (type.GetInterface(nameof(IEnumerable)) != null)
                entityType = type.GenericTypeArguments[0];
            else
                entityType = type;

            if (FluentMapper.EntityMaps.ContainsKey(entityType) && FluentMapper.TypeConventions != null)
            {
            }

            return "";
        }



        public dynamic StartTransaction()
        {
            if (!inTransaction)
            {
                inTransaction = true;
                _connection = new SqlConnection(_configuration.GetConnectionString(ConnectionStringName));
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
            return new { connection = _connection, transaction = _transaction };
        }

        public void Commit()
        {
            if (inTransaction)
            {
                inTransaction = false;
                _transaction.Commit();
                _connection.Close();
                _connection.Dispose();
            }
        }

        public void Rollback()
        {
            if (inTransaction)
            {
                try
                {
                    inTransaction = false;
                    _transaction.Rollback();
                    _connection.Close();
                    _connection.Dispose();
                }
                catch
                {

                }
                finally
                {
                    _transaction = null;
                    _connection = null;
                }
            }
        }



        public SqlTransaction GetTransaction()
        {
            return _transaction;
        }

        public void FinishTransaction()
        {
            inTransaction = false;
        }
    }
}
