using Microsoft.EntityFrameworkCore;
using WTFMessageAPI.Data;
using WTFMessageAPI.Models;

namespace WTFMessageAPI.DAL
{
    public class MessageManager
    {
        private readonly ApplicationDBContext _context;

        public static List<Message> Messages { get; set; }

        public MessageManager(ApplicationDBContext context)
        {
            _context = context;
        }

        public static async Task<List<Message>> GetMessages()
        {
            var messages = await _context.Messages.ToListAsync();

            return messages;
        }


        public static async Task<List<Message>> GetAllMessages()
        {
            //var messageData = new MessageData();

            if(Messages == null || !Messages.Any())
            {
                Messages = await GetMessages();
            }

            return Messages;
        }
    }
}
