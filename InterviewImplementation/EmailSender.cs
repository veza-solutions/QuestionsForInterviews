using InterviewContracts;
using MimeKit;
using MailKit.Net.Smtp;
using ServiceConstants;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Models.EmailModels;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace InterviewImplementation
{
    public class EmailSender : IEmailSender
    {
        private readonly SMTPConfigModel _smtpConfig;

        public EmailSender(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }
        public async Task SendTestEmail(UserEmailOptions userEmailOptions, string emailBody)
        {
            userEmailOptions.Subject = "Тестов имейл";

            userEmailOptions.Body = "Това е тестов имейл";

            await SendEmail(userEmailOptions);
        }

        public async Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions, string emailBody)
        {
            userEmailOptions.Subject = "Потвърждаване на акаунт";

            userEmailOptions.Body = "Моля потвърдете акаунта си чрез натискане на следният линк : " + emailBody;

            await SendEmail(userEmailOptions);
        }

        public async Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions, string emailBody)
        {
            userEmailOptions.Subject = "Забравена парола";

            userEmailOptions.Body = "Здравейте моля потвърдете че искате да ви се смени паролата чрез натискане на този линк : " + emailBody;

            await SendEmail(userEmailOptions);
        }      

        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHtml
            };

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }

            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.Username, _smtpConfig.Password);

            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };

            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }       
    }


}

