using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Vega.Interfaces;
using Vega.Models;

namespace Vega.Services
{
    public class MailService : IMailService
    {
        private ViewRenderService _viewRenderService;
        private IConfiguration Configuration { get; }
        private SmtpClient mailServer;
        private MailMessage mailMessage;
        public MailService(IConfiguration configuration, ViewRenderService viewRenderService)
        {
            Configuration = configuration;
            _viewRenderService = viewRenderService;
            mailServer = new()
            {
                Credentials = new NetworkCredential(Configuration["MailService:MailAddress"], Configuration["MailService:Password"]),
                Port = int.Parse(Configuration["MailService:Port"]),
                Host = Configuration["MailService:Host"],
                EnableSsl = bool.Parse(Configuration["MailService:SSL"])
            };
            mailMessage = new()
            {
                From = new MailAddress(Configuration["MailService:MailAddress"]),
                
            };
        }

        public async Task SendRegisterMail(string mailAddress)
        {
            mailMessage.Subject = "Vega | Welcome to new journey!"; 
            mailMessage.Body = await _viewRenderService.RenderToStringAsync("~/Mailing/Register.cshtml", new RegisterViewModel { MailAddress = mailAddress });
            mailMessage.To.Add(mailAddress);
            await mailServer.SendMailAsync(mailMessage);
        }
    }
}