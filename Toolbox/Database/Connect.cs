using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Toolbox.Database
{
    public sealed class Connect
    {
        private string _ConnectionString;
        private DbProviderFactory _Factory;

        public Connect(DbProviderFactory factory, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _ConnectionString = connectionString;
            _Factory = factory;
        }

        private DbCommand CreateCommand(DbConnection db, Query query)
        {
            DbCommand command = db.CreateCommand();

            command.CommandText = query.Request;
            command.CommandType = query.IsProcedure ? CommandType.StoredProcedure : CommandType.Text;

            foreach (KeyValuePair<string, object> parameter in query.Parameters)
            {
                DbParameter p = _Factory.CreateParameter();
                p.ParameterName = parameter.Key;
                p.Value = parameter.Value;

                command.Parameters.Add(p);
            }

            return command;
        }

        private DbConnection CreateConnection()
        {
            DbConnection db = _Factory.CreateConnection();
            db.ConnectionString = _ConnectionString;
            return db;
        }


        public int ExecuteNonquery(Query query)
        {
            using (DbConnection db = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(db, query))
                {
                    db.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public TResult ExecuteScalar<TResult>(Query query)
        {
            using (DbConnection db = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(db, query))
                {
                    db.Open();

                    object o = cmd.ExecuteNonQuery();

                    return (o is DBNull) ? default(TResult) : (TResult)o;
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Query query, Func<IDataRecord, TResult> convert)
        {
            using (DbConnection db = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(db, query))
                {
                    db.Open();

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return convert(reader);
                        }
                    }
                }
            }
        }
    }
}
