using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using C = Demo_ASP_Core_MVC.Models;
using G = Demo_ASP_Core_MVC.DAL.Entities;

namespace Demo_ASP_Core_MVC.DataServices.Mappers
{
    public static class MemberMapper
    {
        // Création de mapper sous forme de méthode d'extension

        public static C.Member ToClient(this G.MemberEntity entity)
        {
            if (entity is null) return null;

            return new C.Member()
            {
                Id = entity.Id,
                Pseudo = entity.Pseudo,
                Email = entity.Email,
                Password = null
            };
        }

        public static G.MemberEntity ToGlobal(this C.Member client)
        {
            if (client is null) return null;

            return new G.MemberEntity()
            {
                Id = client.Id,
                Email = client.Email,
                Pseudo = client.Pseudo,
                Password = client.Password
            };
        }
    }
}
