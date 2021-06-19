using Homeland.SASF.Model;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Homeland.SASF.Notification.Controllers
{
    [ApiController]
    [Route("notification/[controller]")]
    public class WhatsAppController : ControllerBase
    {
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
                var notification = model;

                var accountSid = "AC9be58b8f756d1d53ada4f294fc531761";
                var authToken = "f1ca2165fc4fac10975d6168cd860657";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber($@"whatsapp:{model.phone}"));
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = $@"{notification.message}";

                var message = MessageResource.Create(messageOptions);
                return Ok(message);
            }

            return BadRequest(ModelState);
        }
    }
}
