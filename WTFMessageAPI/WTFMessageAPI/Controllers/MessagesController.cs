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
        public async Task<Message> GetOneMessage(int id)
        {
            var message = await _messageManager.GetOneMessage(id);

            return message;
        }


        [HttpPost]
        public async Task PostMessage([FromBody] Message message) //Skapa ny (Create)
        {
            await _messageManager.CreateMessage(message);
        }

        [HttpPut("{id}")]
        public async Task PutMessage(int id, [FromBody] Message message) //Uppdatera (Update)
        {
            await _messageManager.UpdateMessage(message, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMessage(int id)
        {
            await _messageManager.DeleteMessage(id);
        }
    }
}
