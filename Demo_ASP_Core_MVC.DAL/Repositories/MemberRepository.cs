using Demo_ASP_Core_MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Toolbox.Database;

namespace Demo_ASP_Core_MVC.DAL.Repositories
{
    public class MemberRepository : RepositoryBase<Guid, MemberEntity>
    {
        //protected override Member ConvertRecordToEntity(IDataRecord record)
        //{
        //    return new Member()
        //    {
        //        Id = record.GetGuid(record.GetOrdinal(IdName)),
        //        Pseudo = record.GetString(record.GetOrdinal("Pseudo")),
        //        Email = record.GetString(record.GetOrdinal("Email")),
        //        Password = null
        //    };
        //}

        protected override MemberEntity ConvertRecordToEntity(IDataRecord record)
        {
            return new MemberEntity()
            {
                Id = (Guid)record[IdName],
                Pseudo = record["Pseudo"].ToString(),
                Email = record["Email"].ToString(),
                Password = null
            };
        }

        public override Guid Insert(MemberEntity entity)
        {
            Query query = new Query("AddMember", true);
            query.AddParameter("@Pseudo", entity.Pseudo);
            query.AddParameter("@Email", entity.Email);
            query.AddParameter("@Password", entity.Password);

            return Connect.ExecuteScalar<Guid>(query);
        }

        public override bool Update(Guid key, MemberEntity entity)
        {
            Query query = new Query("UpdateMember", true);
            query.AddParameter("@Id_Member", key);
            query.AddParameter("@Pseudo", entity.Pseudo);
            query.AddParameter("@Email", entity.Email);
            query.AddParameter("@Password", entity.Password);

            return Connect.ExecuteNonquery(query) == 1;
        }
    }
}
