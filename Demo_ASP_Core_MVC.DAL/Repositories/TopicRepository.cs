using Demo_ASP_Core_MVC.DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Toolbox.Database;

namespace Demo_ASP_Core_MVC.DAL.Repositories
{
    public class TopicRepository : RepositoryBase<Guid, TopicEntity>
    {
        public TopicRepository(IConfiguration configuration) : base(configuration)
        { }

        public override Guid Insert(TopicEntity entity)
        {
            Query query = new Query("AddTopic", true);
            query.AddParameter("@Title", entity.Title);
            query.AddParameter("@Id_Creator", entity.IdCreator);

            return Connect.ExecuteScalar<Guid>(query);
        }

        public override bool Update(Guid key, TopicEntity entity)
        {
            Query query = new Query("UpdateTopic", true);
            query.AddParameter("@Id_Topic", key);
            query.AddParameter("@Title", entity.Title);
            query.AddParameter("@Id_Creator", entity.IdCreator);

            return Connect.ExecuteNonquery(query) == 1;
        }

        protected override TopicEntity ConvertRecordToEntity(IDataRecord record)
        {
            return new TopicEntity()
            {
                Id = (Guid)record[IdName],
                Title = record["Title"].ToString(),
                IdCreator = (Guid)record["Id_Creator"]
            };
        }
    }
}
