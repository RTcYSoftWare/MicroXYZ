using MicroXYZ.Database;
using MicroXYZ.Enums;
using MicroXYZ.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MicroXYZ.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        private readonly MicroXYZDBContext _context;


        public EmailHelper(MicroXYZDBContext context)
        {
            _context = context;
        }

        public async Task SendEmailAsync(string receiverEmaill, string eMailSMTPTemplatesEnum, string eMailSMTPSettingsEnum, EmailBodyHelper emailBodyHelper)
        {
            // TODO: dinamik e mail template ayarlanacak yani qr code maili için veya forget password maili için mail içerikleri değişecek. Hepsini kaplayan bir data model oluşturulabilir. o da en MakeEMailBody fonksiyonuna gönderilebilir.

            EmailSent eMailSent = new EmailSent();
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMessage = new MailMessage();

            EmailTemplate eMailTemplate = new EmailTemplate();

            eMailTemplate = GetEMailTemplate(eMailSMTPTemplatesEnum); // gerekli olan e mail template'ini getiriyor.

            string sendEpostaBody = "";
            string sendEpostaTitle = eMailTemplate.Title;
            string receiverEmail = receiverEmaill;

            string senderEmailAddress = _context.EmailSmtpsettings.Where(x => x.Name == EMailSMTPSettingsEnum.SMTP_EPOSTA_ADDRESS.ToString()).Select(x => x.Value).FirstOrDefault(); //"info@rtcysoftware.com";
            string senderEmailPassword = _context.EmailSmtpsettings.Where(x => x.Name == EMailSMTPSettingsEnum.SMTP_EPOSTA_PASSWORD.ToString()).Select(x => x.Value).FirstOrDefault(); //"88726789infoRTcY.";


            string emailBody = MakeEMailBody(eMailSMTPTemplatesEnum, eMailSMTPSettingsEnum, emailBodyHelper);


            sendEpostaBody = _context.EmailSmtpsettings.Where(x => x.Name == eMailSMTPSettingsEnum).Select(x => x.Value).FirstOrDefault();
            //sendEpostaBody = sendEpostaBody.Replace("$code", emailBodyHelper.ForgetPasswordCode);
            sendEpostaBody = emailBody;
            mailMessage = CreateMailAdress(receiverEmail, senderEmailAddress, sendEpostaTitle, sendEpostaBody);

            smtpClient = CrateSmtpClient(senderEmailAddress, senderEmailPassword);

            eMailSent = AddEmailSentToDatabase(1, sendEpostaBody, receiverEmail, senderEmailAddress);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception e)
            {
                e.ToString();
                AddEmailErrorToDataBase(eMailSent.Id, e, receiverEmail, senderEmailAddress);
                UpdateEmailSentToDatabase(eMailSent.Id);
            }
        }

        public MailMessage CreateMailAdress(string receiverEmail, string senderEmailAddress, string sendEpostaTitle, string sendEpostaBody)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(receiverEmail));
            mailMessage.From = new MailAddress(senderEmailAddress);
            mailMessage.Subject = sendEpostaTitle;
            mailMessage.Body = sendEpostaBody;
            mailMessage.IsBodyHtml = true;

            return mailMessage;
        }

        public SmtpClient CrateSmtpClient(string senderEmailAddress, string senderEmailPassword)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = _context.EmailSmtpsettings.Where(x => x.Name == EMailSMTPSettingsEnum.SMTP_EPOSTA_HOST.ToString()).Select(x => x.Value).FirstOrDefault(); //"mail.rtcysoftware.com";
            smtpClient.Credentials = new System.Net.NetworkCredential(senderEmailAddress, senderEmailPassword);
            smtpClient.Port = int.Parse(_context.EmailSmtpsettings.Where(x => x.Name == EMailSMTPSettingsEnum.SMTP_EPOSTA_PORT.ToString()).Select(x => x.Value).FirstOrDefault()); // 587;
            smtpClient.EnableSsl = bool.Parse(_context.EmailSmtpsettings.Where(x => x.Name == EMailSMTPSettingsEnum.SMTP_EPOSTA_SSL.ToString()).Select(x => x.Value).FirstOrDefault()); // true;            
            return smtpClient;
        }

        public void AddEmailErrorToDataBase(int id, Exception e, string receiverEmail, string senderEmail)
        {
            EmailSendError eMailSendError = new EmailSendError();

            eMailSendError.ErrorCode = e.GetHashCode();
            eMailSendError.ErrorMessage = e.ToString();
            eMailSendError.ReceiverMail = receiverEmail;
            eMailSendError.SenderMail = senderEmail;
            eMailSendError.SendingMailId = id;
            eMailSendError.IsActive = true;
            eMailSendError.SendedAt = DateTime.Now;

            _context.EmailSendErrors.Add(eMailSendError);
            _context.SaveChanges();
        }

        public EmailSent AddEmailSentToDatabase(int templateId, string sendEpostaBody, string receiverEmail, string senderEmail)
        {
            EmailSent eMailSent = new EmailSent();

            eMailSent.Message = sendEpostaBody;
            eMailSent.ReceiverMail = receiverEmail;
            eMailSent.SenderMail = senderEmail;
            eMailSent.SendingStatus = true;
            eMailSent.TemplateId = templateId;

            _context.EmailSents.Add(eMailSent);
            _context.SaveChanges();

            return eMailSent;
        }

        public void UpdateEmailSentToDatabase(int id)
        {
            EmailSent updateEmailSent = _context.EmailSents.Where(x => x.Id == id).FirstOrDefault();
            updateEmailSent.SendingStatus = false;
            _context.SaveChanges();
        }

        public EmailTemplate GetEMailTemplate(string eMailSMTPTemplatesEnum)
        {
            EmailTemplate eMailTemplate = _context.EmailTemplates.Where(x => x.Label == eMailSMTPTemplatesEnum).FirstOrDefault();

            return eMailTemplate;
        }

        public string GetEMailSMTPSettingForEMailBody(string eMailSMTPSettingsEnum)
        {
            return _context.EmailSmtpsettings.Where(x => x.Name == eMailSMTPSettingsEnum).Select(x => x.Value).FirstOrDefault();
        }

        public string MakeEMailBody(string eMailSMTPTemplatesEnum, string eMailSMTPSettingsEnum, EmailBodyHelper emailBodyHelper)
        {
            EmailTemplate eMailTemplate = new EmailTemplate();

            eMailTemplate = GetEMailTemplate(eMailSMTPTemplatesEnum);

            //string[] keyWords = eMailTemplate.Keywords.Split(",");

            // TODO: email body farklı yerden çekilmesi saçma düzeltilmesi gerek
            //string ePostaBody = GetEMailSMTPSettingForEMailBody(eMailSMTPSettingsEnum);

            string ePostaBody = eMailTemplate.Text;

            //if (eMailSMTPTemplatesEnum == EMailSMTPTemplatesEnum.DOWNLOAD_QR_CODES_TEMPLATE.ToString())
            //{
            //    ePostaBody = ePostaBody.Replace("$qrCodeZipUrl", emailBodyHelper.QrCodeZipUrl).Replace("$qrCodeZipFileName", emailBodyHelper.QrCodeZipFileName).Replace("$userName", emailBodyHelper.RecieverName);
            //}

            if (eMailSMTPTemplatesEnum == EMailSMTPTemplatesEnum.FORGET_PASSWORD_TEMPLATE.ToString())
            {
                ePostaBody = ePostaBody.Replace("$code", emailBodyHelper.ForgetPasswordCode).Replace("$userName", emailBodyHelper.RecieverName).Replace("$mailAdress", emailBodyHelper.RecieverEmail);
            }

            if (eMailSMTPTemplatesEnum == EMailSMTPTemplatesEnum.CONTACT_US_FORM_TEMPLATE.ToString())
            {
                ePostaBody = ePostaBody.Replace("$userName", emailBodyHelper.RecieverName).Replace("$mailAdress", emailBodyHelper.RecieverEmail).Replace("$subject", emailBodyHelper.Subject).Replace("$message", emailBodyHelper.ContactFormMessage);
            }

            if (eMailSMTPTemplatesEnum == EMailSMTPTemplatesEnum.PRODUCT_BUY_REQUEST_TEMPLATE.ToString())
            {
                ePostaBody = ePostaBody.Replace("$userName", emailBodyHelper.RecieverName).Replace("$mailAdress", emailBodyHelper.RecieverEmail).Replace("$phone", emailBodyHelper.RecieverPhone).Replace("$productName", emailBodyHelper.ProductName).Replace("$productInfo", emailBodyHelper.ProductInfo.ToString());
            }

            if (eMailSMTPTemplatesEnum == EMailSMTPTemplatesEnum.PRODUCT_BUY_CUSTOMER_TEMPLATE.ToString())
            {
                ePostaBody = ePostaBody.Replace("$userName", emailBodyHelper.RecieverName).Replace("$productName", emailBodyHelper.ProductName);
            }

            return ePostaBody;
        }

    }
}
