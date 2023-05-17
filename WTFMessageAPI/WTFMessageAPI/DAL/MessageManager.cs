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
        //TODO:
        //Create

        //Update

        //Delete from DB
        public async Task DeleteProduct(int id)
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
