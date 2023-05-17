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
        private readonly MessageManager _messageManager;
        public MessagesController(MessageManager messageManager)
        {

            _messageManager = messageManager;

        }

        [HttpGet]
        public async Task<IEnumerable<Message>> GetMessages()
        {

            var messages = await _messageManager.GetAllMessages();

            return messages;
        }
    }
}
