namespace MicroXYZ.Models
{
    public class EmailBodyHelper
    {
        public string ForgetPasswordCode { get; set; }
        public string QrCodeZipUrl { get; set; }
        public string QrCodeZipFileName { get; set; }
        public string RecieverName { get; set; }
        public string RecieverEmail { get; set; }
        public string RecieverPhone { get; set; }
        public string ContactFormMessage { get; set; }
        public string Subject { get; set; }
        public string ProductName { get; set; }
        public object ProductInfo { get; set; }
    }
}
