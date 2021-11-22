using Models.EmailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewContracts
{
    public interface  IEmailSender
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions, string emailBody);

        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions, string emailBody);

        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions, string emailBody);
    }
}
