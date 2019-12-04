using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuatorProjectVIdeoPlayer.Models
{
    public static class SessionHelper
    {
        private const string MemberIdKey = "memberid";
        private const string UsernameKey = "username";

        public static void LogUserIn(IHttpContextAccessor context, int memberId, string username)
        {
            context.HttpContext.Session.SetInt32(MemberIdKey, memberId);
            context.HttpContext.Session.SetString(UsernameKey, username);
        }

        public static bool IsLoggedIn(IHttpContextAccessor conext)
        {
            if (conext.HttpContext.Session.GetInt32(MemberIdKey).HasValue)
            {
                return true;
            }

            return false;
        }

        public static void LogOut(IHttpContextAccessor context)
        {
            context.HttpContext.Session.Clear();
        }

        public static int? WhosLoggedIn(IHttpContextAccessor context)
        {
            return context.HttpContext.Session.GetInt32(MemberIdKey);
        }
    }
}
