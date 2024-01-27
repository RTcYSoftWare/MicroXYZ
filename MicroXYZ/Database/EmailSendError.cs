using System;

namespace MicroXYZ.Database
{
    public class EmailSendError : BaseEntity
    {        
        public string ReceiverMail { get; set; }
        public string SenderMail { get; set; }
        public int? SendingMailId { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }        
        public DateTime SendedAt { get; set; }
    }
}
