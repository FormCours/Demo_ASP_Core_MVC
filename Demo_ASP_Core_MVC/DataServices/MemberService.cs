using Demo_ASP_Core_MVC.DAL.Entities;
using Demo_ASP_Core_MVC.DAL.Repositories;
using Demo_ASP_Core_MVC.DataServices.Mappers;
using Demo_ASP_Core_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.DataServices
{
    public class MemberService
    {
        private MemberRepository _memberRepo;

        public MemberService(MemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public Member Get(Guid id)
        {
            MemberEntity entity = _memberRepo.Get(id);

            return entity.ToClient();

            //return new Member()
            //{
            //    Id = entity.Id,
            //    Pseudo = entity.Pseudo,
            //    Email = entity.Email
            //}; 
        }

        public Member GetByCredentials(string email, string password)
        {
            MemberEntity entity = _memberRepo.GetByCredentials(email, password);

            return entity.ToClient();
        }

        public Member Create(Member newMember)
        {
            Guid id = _memberRepo.Insert(newMember.ToGlobal());
            return Get(id);
        }

        public bool CheckEmailIsAvailable(string email)
        {
            // - Solution : Check dans le serveur backend
            //return _memberRepo.GetAll().Any(m => m.Email == email);

            // - Solution : Utilisation de la DB pour réaliser la validation
            return _memberRepo.CheckEmailIsAvailable(email);
        }

        public bool CheckPseudoIsAvailable(string pseudo)
        {
            return _memberRepo.CheckPseudoIsAvailable(pseudo);
        }
    }
}
