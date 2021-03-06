using Demo_ASP_Core_MVC.DAL.Entities;
using Demo_ASP_Core_MVC.DAL.Repositories;
using Demo_ASP_Core_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.DataServices
{
    public class TopicService
    {
        private TopicRepository _topicRepo;
        private MemberService _memberService;
        private MessageService _messageService;

        public TopicService(TopicRepository topicRepo, MemberService memberService, MessageService messageService)
        {
            _topicRepo = topicRepo;
            _memberService = memberService;
            _messageService = messageService;
        }


        public IEnumerable<Topic> GetAll()
        {
            return _topicRepo.GetAll().Select(t => new Topic()
            {
                Id = t.Id,
                Title = t.Title,
                Creator = _memberService.Get(t.IdCreator)
            });
        }

        public IEnumerable<TopicWithLastMessage> GetAllWithLastMessage()
        {
            return _topicRepo.GetAll().Select(t => new TopicWithLastMessage()
            {
                Id = t.Id,
                Title = t.Title,
                Creator = _memberService.Get(t.IdCreator),
                LastMessage = _messageService.GetLastOfTopic(t.Id)
            });
        }

        internal Guid Create(string title, string content, Guid idCreator)
        {

            Guid idTopic = _topicRepo.Insert(new TopicEntity()
            {
                Title = title,
                IdCreator = idCreator
            });

            _messageService.Create(idTopic, content, idCreator);

            return idTopic;
        }

        internal Topic Get(Guid id)
        {
            TopicEntity entity = _topicRepo.Get(id);

            return new Topic()
            {
                Id = entity.Id,
                Title = entity.Title,
                Creator = _memberService.Get(entity.IdCreator)
            };
        }
    }
}
