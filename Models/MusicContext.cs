using Microsoft.EntityFrameworkCore;
namespace Music_Web_API.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }
        public DbSet<Song> Songs { get; set; }
    }
}
