using MicroXYZ.Database;
using MicroXYZ.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MicroXYZ.Helpers
{
    public interface IEmailHelper
    {
        public Task SendEmailAsync(string receiverEmaill, string eMailSMTPTemplatesEnum, string eMailSMTPSettingsEnum, EmailBodyHelper emailBodyHelper);

        public MailMessage CreateMailAdress(string receiverEmail, string senderEmailAddress, string sendEpostaTitle, string sendEpostaBody);

        public SmtpClient CrateSmtpClient(string senderEmailAddress, string senderEmailPassword);

        public void AddEmailErrorToDataBase(int id, Exception e, string receiverEmail, string senderEmail);

        public EmailSent AddEmailSentToDatabase(int templateId, string sendEpostaBody, string receiverEmail, string senderEmail);

        public void UpdateEmailSentToDatabase(int id);

        public EmailTemplate GetEMailTemplate(string eMailSMTPTemplatesEnum);

        public string GetEMailSMTPSettingForEMailBody(string eMailSMTPSettingsEnum);
    }
}
