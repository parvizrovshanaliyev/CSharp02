using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Blog.Shared.Helpers
{
    public interface IMailHelper
    {
        Task<bool> SendAsync(EmailSendDto emailSendDto);
        Task<bool> SendContactMailAsync(EmailSendDto emailSendDto);
    }

    public class MailHelper : IMailHelper
    {
        #region fields
        private readonly SmtpSettings _smtpSettings;
        #endregion

        #region ctor

        public MailHelper(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        #endregion

        #region Implementation of IMailHelper



        #endregion

        #region Implementation of IMailHelper

        public async Task<bool> SendAsync(EmailSendDto emailSendDto)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_smtpSettings.Email, _smtpSettings.SenderName),
                    To = { new MailAddress(emailSendDto.Email, _smtpSettings.SenderName) },
                    Subject = emailSendDto.Subject,
                    IsBodyHtml = true,
                    Body = $"Message: {emailSendDto.Message}"
                };

                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = _smtpSettings.Host,
                    Port = _smtpSettings.Port,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_smtpSettings.Email, _smtpSettings.Password),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                await smtpClient.SendMailAsync(mail);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> SendContactMailAsync(EmailSendDto emailSendDto)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_smtpSettings.Email, "info@blog.com"),
                    To = { new MailAddress(_smtpSettings.Email, _smtpSettings.SenderName) },
                    Subject = emailSendDto.Subject,
                    IsBodyHtml = true,
                    Body = $"Sender: {emailSendDto.FullName}, Email: {emailSendDto.Email},\n Message: {emailSendDto.Message}"
                };
                using SmtpClient smtp = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(_smtpSettings.Email, _smtpSettings.Password);
                await smtp.SendMailAsync(mail);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}
