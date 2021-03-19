using Demo_ASP_Core_MVC.DAL.Entities;
using Demo_ASP_Core_MVC.DAL.Repositories;
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

            return new Member()
            {
                Id = entity.Id,
                Pseudo = entity.Pseudo,
                Email = entity.Email
            }; 
        }
    }
}
