using Microsoft.AspNetCore.Http.HttpResults;
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
        //TODO:
        //Create
        public async Task CreateMessage(Message message) //Används av httpPost i controller
        {
            if (Messages == null || !Messages.Any())
            {
                await GetAllMessages();
            }

            message.DateTime = DateTime.Now;
            _context.Messages.Add(message); //spara inlägget
            await _context.SaveChangesAsync();
        }

        //Update
        public async Task UpdateMessage(Message message, int id)
        {
            if (Messages == null || !Messages.Any())
            {
                await GetAllMessages();
            }

            var existingMessage = Messages.FirstOrDefault(m => m.Id == id);

            if (existingMessage != null)
            {
                existingMessage.Title = message.Title;
                existingMessage.TextMessage = message.TextMessage;
                existingMessage.DateTime = message.DateTime;
                existingMessage.SenderId = message.SenderId;
                existingMessage.ReceiverId = message.ReceiverId;
                existingMessage.IsRead = true;

                await _context.SaveChangesAsync();

            }
        }

        //Delete from DB
        public async Task DeleteMessage(int id)
        {
            Models.Message message = await _context.Messages.FindAsync(id);

            if (message != null)
            {
                _context.Messages.Remove(message); //ta bort inlägget
                await _context.SaveChangesAsync(); //Spara
            }
        }

        //Get messages from DB
        public async Task<List<Message>> GetDBMessages()
        {
            var messages = await _context.Messages.ToListAsync();

            return messages;
        }
    }
}
