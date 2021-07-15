using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Homeland.SASF.Notification.Controllers
{
    [ApiController]
    [Route("notification/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly string Mensagem = "Olá, {0}! Por favor resposta o seu questionário diário de saúde em:\nhttp://homeland.servehttp.com/Ocorrencia/Novo";

        public NotificationController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Opa!");
        }

        [HttpPost("Send")]
        public IActionResult Send([FromBody] Homeland.SASF.Model.Notification model)
        {
            if (ModelState.IsValid)
            {
                if (model.tipo == "WhatsApp")
                {
                    return WhatsApp(model);
                }
                else
                if (model.tipo == "E-mail")
                {
                    return Email(model);
                }
            }

            return BadRequest(ModelState);
        }
        public IActionResult WhatsApp([FromBody] Homeland.SASF.Model.Notification model)
        {
            if (ModelState.IsValid)
            {
                var accountSid = configuration.GetValue<string>("AuthKeys:accountSid");
                var authToken = configuration.GetValue<string>("AuthKeys:authToken");
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber($@"whatsapp:{model.telefone}"));
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = String.Format(Mensagem, model.nome);

                var message = MessageResource.Create(messageOptions);
                return Ok(message);
            }

            return BadRequest(ModelState);
        }

        public IActionResult Email([FromBody] Homeland.SASF.Model.Notification model)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Homeland - SASF",
            "naoresposa@homeland.com.br");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(model.nome,
            model.email);
            message.To.Add(to);

            message.Subject = "Homeland - SASF - Questionário Diário de Saúde";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"<h1>{String.Format(Mensagem, model.nome)}</h1>";

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("taylorfmartins@gmail.com", "ipm34prime");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return Ok("E-mail enviado!");
        }
    }
}
