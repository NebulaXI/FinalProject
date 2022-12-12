using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Models
{
    public class ShowMessageViewModel
    {   public string? ReceiverId { get; set; } 
        public string? SenderId { get; set; }
        public List<Message>? Messages { get; set; }
        public List<ChatViewModel>? Chats { get; set; }
        public string? Content { get; set; }
    }
}
