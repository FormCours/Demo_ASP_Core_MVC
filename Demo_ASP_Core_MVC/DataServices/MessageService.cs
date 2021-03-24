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
        private MessageRepository _messageRepo;
        private MemberService _memberService;

        public MessageService(MessageRepository messageRepo, MemberService memberService)
        {
            _messageRepo = messageRepo;
            _memberService = memberService;
        }

        public Message GetLastOfTopic(Guid idTopic)
        {
            MessageEntity entity = _messageRepo.GetLastOfTopic(idTopic);

            return new Message()
            {
                Id = entity.Id,
                Content = entity.Content,
                SubmitDate = entity.SubmitDate,
                UpdateDate = entity.UpdateDate,
                Creator = _memberService.Get(entity.IdMember)
            };
        }

        internal Guid Create(Guid idTopic, string content, Guid idCreator)
        {
            Guid idMessage = _messageRepo.Insert(new MessageEntity()
            {
                IdTopic = idTopic,
                IdMember = idCreator,
                Content = content
            });

            return idMessage;
        }

        internal IEnumerable<Message> GetAllOfTopic(Guid idTopic)
        {
            return _messageRepo.GetAllOfTopic(idTopic).Select(m => new Message()
            {
                Id = m.Id,
                Content = m.Content,
                SubmitDate = m.SubmitDate,
                UpdateDate = m.UpdateDate,
                Creator = _memberService.Get(m.IdMember)
            });
        }
    }
}
