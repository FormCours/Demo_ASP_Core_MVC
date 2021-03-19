using Demo_ASP_Core_MVC.DAL.Entities;
using Demo_ASP_Core_MVC.DAL.Repositories;
using Demo_ASP_Core_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.DataServices
{
    public class MessageService
    {
        private MessageRepository messageRepo;
        private MemberService memberService;

        public MessageService()
        {
            messageRepo = new MessageRepository();
            memberService = new MemberService();
        }

        public Message GetLastOfTopic(Guid idTopic)
        {
            MessageEntity entity = messageRepo.GetLastOfTopic(idTopic);

            return new Message()
            {
                Id = entity.Id,
                Content = entity.Content,
                SubmitDate = entity.SubmitDate,
                UpdateDate = entity.UpdateDate,
                Creator = memberService.Get(entity.IdMember)
            };
        }
    }
}
