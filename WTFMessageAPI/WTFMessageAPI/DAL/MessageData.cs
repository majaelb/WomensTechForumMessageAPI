using Microsoft.EntityFrameworkCore;
using WTFMessageAPI.Data;
using WTFMessageAPI.Models;

namespace WTFMessageAPI.DAL
{
    public class MessageData
    {
        private readonly ApplicationDBContext _context;

        public MessageData(ApplicationDBContext context)
        {
            _context = context;
        }

        public MessageData()
        {
            
        }

        public async Task<List<Message>> GetMessages()
        {
            var messages = await _context.Messages.ToListAsync();

            return messages;
        }
    }
}
