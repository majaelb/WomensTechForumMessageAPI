using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WTFMessageAPI.DAL;
using WTFMessageAPI.Models;

namespace WTFMessageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Message>> GetMessages()
        {
            var messagemanagaer = new MessageManager();

            var messages = DAL.MessageManager.GetAllMessages();

            return await messages;
        }
    }
}
