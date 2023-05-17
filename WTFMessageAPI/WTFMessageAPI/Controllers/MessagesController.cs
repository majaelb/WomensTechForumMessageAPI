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

        [HttpGet("{id}")]
        public async Task<Models.Message> GetOneProduct(int id)
        {
            var message = await _messageManager.GetOneMessage(id);

            return message;
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await _messageManager.DeleteProduct(id);
        }
    }
}
