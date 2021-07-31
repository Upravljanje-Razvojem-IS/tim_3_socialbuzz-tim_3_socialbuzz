using ChatService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ChatUser> ChatUsers { get; set; }
        public virtual DbSet<Message> Messages{ get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }
    }
}
