using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Music_Web_API.Models
{
    public class Song
    {
        public long songId { get; set; }
        public string name { get; set; }
        public string artist { get; set; }
        public long length { get; set; }

        public Song(long songId, string name, string artist, long length)
        {
            this.songId = songId;
            this.name = name;
            this.artist = artist;
            this.length = length;
        }
    }
}
;