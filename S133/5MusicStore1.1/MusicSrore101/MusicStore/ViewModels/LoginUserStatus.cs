using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class LoginUserStatus
    {
        public bool IsLogin { get; set; }
        public string Message { get; set; }
        public string GotoController { get; set; }
        public string GotoAction { get; set; }
        
    }
    public class LoginUserSessionModel
    {
        public ApplicationUser User { get; set; }
        public Person Person { get; set; }
        public string RoleName { get; set; }
    }
}