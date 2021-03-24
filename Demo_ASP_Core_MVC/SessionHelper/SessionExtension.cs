using Demo_ASP_Core_MVC.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.SessionHelper
{
    public static class SessionExtension
    {
        private const string KEY_MEMBER = "Member";

        public static void SetMember(this ISession session, Member member)
        {
            session.SetString(KEY_MEMBER, JsonSerializer.Serialize(member));
        }

        public static Member GetMember(this ISession session)
        {
            string json = session.GetString(KEY_MEMBER);

            if(!string.IsNullOrEmpty(json))
            {
                return JsonSerializer.Deserialize<Member>(json);
            }
            return null;
        }

        public static bool IsLogged(this ISession session)
        {
            return session.GetMember() != null;
        }
    }
}
