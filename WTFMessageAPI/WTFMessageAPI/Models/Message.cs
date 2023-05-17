namespace WTFMessageAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? TextMessage { get; set; }
        public DateTime? DateTime { get; set; }
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public bool IsRead { get; set; }

    }
}
