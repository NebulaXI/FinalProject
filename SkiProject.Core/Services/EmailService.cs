using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;
using SkiProject.Core.Contracts;
using System.Net.Http.Headers;

namespace SkiProject.Core.Services
{
    public class EmailService:IEmailService
    {
        
      
            private readonly IHost host;

            public EmailService(IHost _host)
            {
                this.host = _host;

            }

            private async Task<IConfiguration> Config()
            {
                var config = host.Services.GetRequiredService<IConfiguration>();
                return config;

            }

            private async Task<ISendGridClient> GetClient()
            {
                var client = new SendGridClient(await GetApiKey());
                return client;
            }

        private async Task<string> GetApiKey()
            {
                var config = await Config();
                var apiKey = config.GetValue<string>("SendGridApiKey");
                return apiKey;
            }

            private async Task<Dictionary<string, string>> ConfigFromData()
            {
                var config = await Config();
                var fromEmail = config.GetValue<string>("FromEmail");
                var fromName = config.GetValue<string>("FromName");
                var returnData = new Dictionary<string, string>
             {
                 { "fromEmail", fromEmail },
                 { "fromName", fromName }
             };
                return returnData;
            }

            public async Task SendMessage(string toEmail)
            {
                var fromData = await ConfigFromData();

                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(fromData["fromEmail"], fromData["fromName"]),
                    Subject = "Welcome to Ski Forum",
                    PlainTextContent = "Welcome to Ski forum"
                };
                msg.AddTo(new EmailAddress(toEmail));
                //var msg1 = MailHelper.CreateSingleEmail(new EmailAddress(fromData["fromEmail"], fromData["fromName"]), new EmailAddress(toEmail),
                  //  "Welcome to Ski Forum", "Welcome to Ski forum", "<strong>and easy to do anywhere, even with C#</strong>");
                var client = await GetClient();
                var response =  client.SendEmailAsync(msg).Result;
            }
        
    }
}
