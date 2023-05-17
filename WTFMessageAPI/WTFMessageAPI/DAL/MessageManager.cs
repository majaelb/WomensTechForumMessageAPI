using Microsoft.EntityFrameworkCore;
using WTFMessageAPI.Data;
using WTFMessageAPI.Models;

namespace WTFMessageAPI.DAL
{
    public class MessageManager
    {
        private readonly ApplicationDBContext _context;
        public List<Message> Messages { get; set; }
        public MessageManager(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<List<Message>> GetAllMessages()
        {
            //var messageData = new MessageData();

            if(Messages == null || !Messages.Any())
            {
                Messages = await GetDBMessages();
            }

            return Messages;
        }

        public async Task<Models.Message> GetOneMessage(int id)
        {
            if (Messages == null || !Messages.Any())
            {
                Messages = await GetDBMessages();
            }

            var existingMessage = Messages.Where(p => p.Id == id).SingleOrDefault();

            if (existingMessage != null)
            {
                return existingMessage;
            }
            else
            {
                return null;
            }
        }

        //Hämtar från databasen
        public async Task<List<Message>> GetDBMessages()
        {
            var messages = await _context.Messages.ToListAsync();

            return messages;
        }
    }
}
