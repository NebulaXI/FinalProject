﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace SkiProject.Core.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public SendGridEmailSender(IConfiguration configuration, ILogger<SendGridEmailSender> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string sendGridApiKey = configuration.GetValue<string>("SendGridApiKey");
            if (string.IsNullOrEmpty(sendGridApiKey))
            {
                throw new Exception("The 'SendGridApiKey' is not configured");
            }

            var client = new SendGridClient(sendGridApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(configuration["FromEmail"], configuration["FromName"]),
                Subject = subject,
                PlainTextContent = "Welcome to Ski Forum",
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(email));
            //Disable click tracking
            msg.SetClickTracking(false, false);
            var response =  await client.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation("Email queued successfully");
            }
            else
            {
                logger.LogError("Failed to send email");
                // Adding more information related to the failed email could be helpful in debugging failure,
                // but be careful about logging PII, as it increases the chance of leaking PII
            }
        }

        //private async Task<IConfiguration> Config()
        //{
        //    var config = host.Services.GetRequiredService<IConfiguration>();
        //    return config;

        //}
    }
}
