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
        private TopicRepository topicRepo;
        private MemberService memberService;
        private MessageService messageService;

        public TopicService()
        {
            topicRepo = new TopicRepository();
            memberService = new MemberService();
            messageService = new MessageService();
        }


        public IEnumerable<Topic> GetAll()
        {
            return topicRepo.GetAll().Select(t => new Topic()
            {
                Id = t.Id,
                Title = t.Title,
                Creator = memberService.Get(t.IdCreator)
            });
        } 

        public IEnumerable<TopicWithLastMessage> GetAllWithLastMessage()
        {
            return topicRepo.GetAll().Select(t => new TopicWithLastMessage()
            {
                Id = t.Id,
                Title = t.Title,
                Creator = memberService.Get(t.IdCreator),
                LastMessage = messageService.GetLastOfTopic(t.Id)
            });
        }
    }
}
