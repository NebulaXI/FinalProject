using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Models
{
    public class ChatViewModel
    {
        public ApplicationUser  User1 { get; set; }
        public string user1Id { get; set; }
        public ApplicationUser  User2 { get; set; }
        public string user2Id { get; set; }
        public List<Message> MessagesBetweenUsers { get; set; }
        public string NewMessageContent { get; set; }
    }
}
