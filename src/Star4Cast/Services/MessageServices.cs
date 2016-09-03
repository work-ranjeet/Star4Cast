﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }



        public Task SendEmailAsync(string email, string subject, string message)
        {
            return null;
        }

        //{
        //    // Plug in your email service here to send an email.
        //    var myMessage = new SendGrid.SendGridMessage();
        //    myMessage.AddTo(email);
        //    myMessage.From = new System.Net.Mail.MailAddress("work.ranjeet@gmail.com", "Ranjeet - work");
        //    myMessage.Subject = subject;
        //    myMessage.Text = message;
        //    myMessage.Html = message;
        //    var credentials = new System.Net.NetworkCredential(Options.SendGridUser, Options.SendGridKey)
        //    {
        //        UserName = "work.ranjeet@gmail.com",
        //        Password = "janemanjaneman",
        //        Domain = "smtp.gmail.com"
                
        //    };
        //    var transportWeb = new SendGrid.Web(credentials);   // Create a Web transport for sending email.

        //    // Send the email.
        //    return transportWeb.DeliverAsync(myMessage);
        //}

        




















        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
