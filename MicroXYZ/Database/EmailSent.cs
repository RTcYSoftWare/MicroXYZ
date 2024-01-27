using System;

namespace MicroXYZ.Database
{
    public class EmailSent : BaseEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string ReceiverMail { get; set; }
        public string SenderMail { get; set; }
        public int? TemplateId { get; set; }
        public string Message { get; set; }
        public bool? SendingStatus { get; set; }
    }
}
