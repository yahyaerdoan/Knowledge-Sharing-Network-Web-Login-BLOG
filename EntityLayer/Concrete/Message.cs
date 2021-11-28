using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key] 
        public int MessageId { get; set; }
        public string MessageSender { get; set; }
        public int? MessageSenderId { get; set; }
        public string MessageReceiver { get; set; }
        public int? MessageReceiverId { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public Writer MessageOfSender { get; set; }
        public Writer MessagesOfReceiver { get; set; }
    }
}
