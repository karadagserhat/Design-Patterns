﻿using BaseProject.Models;
using System.Net;
using System.Net.Mail;

namespace Observer.Observer
{
    public class UserObserverSendEmail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendEmail>>();

            var mailMessage = new MailMessage();

            var smptClient = new SmtpClient("srvm11.trwww.com");

            mailMessage.From = new MailAddress("deneme@kariyersistem.com");

            mailMessage.To.Add(new MailAddress(appUser.Email));

            mailMessage.Subject = "Sitemize hoş geldiniz.";

            mailMessage.Body = "<p>Sitemizin genel kuralları : bıdı bıdı....</p>";

            mailMessage.IsBodyHtml = true;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential("deneme@kariyersistem.com", "Password12*");

            smptClient.Send(mailMessage);
            logger.LogInformation($"Email was send to user :{appUser.UserName}");
        }
    }
}