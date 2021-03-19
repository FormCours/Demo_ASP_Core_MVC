
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Toolbox.Database;
using Toolbox.Pattern.Repository;
using Toolbox.Pattern.Repository.Attributes;

namespace Demo_ASP_Core_MVC.DAL.Repositories
{
    public abstract class RepositoryBase<TKey, TEntity>
        : IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        protected Connect Connect { get; }
        protected string TableName { get; }
        protected string IdName { get; }

        public RepositoryBase()
        {
            // - Initialisation de la toolbox ADO
            // Installer le nuget package "System.data.SqlClient"
            Connect = new Connect(SqlClientFactory.Instance, "Server=TFNSDEV00A\\TECHNI;Database=Demo_ASP_Core;Trusted_Connection=True;");

            // - Recup des info de la table
            TableAttribute infoTable = Attribute.GetCustomAttribute(typeof(TEntity), typeof(TableAttribute)) as TableAttribute;

            // Cas 1 - Obligation d'utiliser l'attribut
            if (infoTable is null)
                throw new MissingMemberException("The entity does not have TableAttribute");
            TableName = "[" + infoTable.TableName + "]";
            IdName = infoTable.IdName;

            // Cas 2 - Utilisation de valeur par defaut si l'attribut est absent
            //TableName = "[" + infoTable?.TableName ?? typeof(TEntity).Name + "]";
            //IdName = infoTable?.IdName ?? "Id";
        }

        protected abstract TEntity ConvertRecordToEntity(IDataRecord record);

        public virtual TEntity Get(TKey key)
        {
            Query query = new Query($"SELECT * FROM {TableName} WHERE {IdName} = @Id");
            query.AddParameter("@Id", key);

            return Connect.ExecuteReader(query, ConvertRecordToEntity).SingleOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            Query query = new Query($"SELECT * FROM {TableName} ");

            return Connect.ExecuteReader(query, ConvertRecordToEntity);
        }

        public abstract TKey Insert(TEntity entity);

        public abstract bool Update(TKey key, TEntity entity);

        public virtual bool Delete(TKey key)
        {
            Query query = new Query($"DELETE FROM {TableName} WHERE {IdName} = @Id");
            query.AddParameter("@Id", key);

            return Connect.ExecuteNonquery(query) == 1;
        }
    }
}