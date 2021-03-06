using Demo_ASP_Core_MVC.DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Toolbox.Database;

namespace Demo_ASP_Core_MVC.DAL.Repositories
{
    public class MessageRepository : RepositoryBase<Guid, MessageEntity>
    {
        public MessageRepository(IConfiguration configuration) : base(configuration)
        { }

        public MessageEntity GetLastOfTopic(Guid idTopic)
        {
            Query query = new Query($"SELECT TOP(1) * FROM {TableName}" +
                                    $" WHERE  Id_Topic = @Id_Topic" +
                                    $" ORDER BY Submit_Date DESC");
            query.AddParameter("@Id_Topic", idTopic);

            return Connect.ExecuteReader(query, ConvertRecordToEntity).SingleOrDefault();
        }

        public override Guid Insert(MessageEntity entity)
        {
            Query query = new Query("AddMessage", true);
            query.AddParameter("@Content", entity.Content);
            query.AddParameter("@Id_Member", entity.IdMember);
            query.AddParameter("@Id_Topic", entity.IdTopic);

            return Connect.ExecuteScalar<Guid>(query);
        }

        public override bool Update(Guid key, MessageEntity entity)
        {
            Query query = new Query("UpdateMessage", true);
            query.AddParameter("@Id_Message", key);
            query.AddParameter("@Content", entity.Content);

            return Connect.ExecuteNonquery(query) == 1;
        }

        public IEnumerable<MessageEntity> GetAllOfTopic(Guid idTopic)
        {
            Query query = new Query($"SELECT * FROM {TableName} " +
                                    $" WHERE [Id_Topic] = @idTopic " +
                                    $" ORDER BY [Submit_Date] ASC");
            query.AddParameter("@idTopic", idTopic);

            return Connect.ExecuteReader(query, ConvertRecordToEntity);
        }

        protected override MessageEntity ConvertRecordToEntity(IDataRecord record)
        {
            return new MessageEntity()
            {
                Id = (Guid)record["Id_Message"],
                Content = record["Content"].ToString(),
                SubmitDate = Convert.ToDateTime(record["Submit_Date"]),
                UpdateDate = record["Update_Date"] is DBNull ? null :
                                            (DateTime?)Convert.ToDateTime(record["Update_Date"]),
                IdMember = (Guid)record["Id_Member"],
                IdTopic = (Guid)record["Id_Topic"],
            };
        }
    }
}
