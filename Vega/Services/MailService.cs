using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vega.Data;
using Vega.Entities;
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
        private VegaContext _db;
        public MailService(IConfiguration configuration, ViewRenderService viewRenderService, VegaContext db)
        {
            Configuration = configuration;
            _viewRenderService = viewRenderService;
            _db = db;
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

        public async Task SendVerificationMail(int Id, Request requestData)
        {
            User userData = await _db.Users.FirstOrDefaultAsync(x => x.Id == Id && !x.DeletedAt.HasValue);
            mailMessage.Subject = "Vega | Mail Verification";
            mailMessage.Body = await _viewRenderService.RenderToStringAsync("~/Mailing/MailVerification.cshtml", requestData);
            mailMessage.To.Add(userData.MailAddress);
            await mailServer.SendMailAsync(mailMessage);
        }

        public async Task SendResetPasswordMail(User userData, Request requestData)
        {
            mailMessage.Subject = "Vega | Reset Password";
            mailMessage.Body = await _viewRenderService.RenderToStringAsync("~/Mailing/ResetPassword.cshtml", requestData);
            mailMessage.To.Add(userData.MailAddress);
            await mailServer.SendMailAsync(mailMessage);
        }
    }
}