using Microsoft.AspNetCore.Mvc;
using Music_Web_API.Models;

namespace Music_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private readonly MusicContext _musicContext;

        public SongController(MusicContext musicContext)
        {
            _musicContext = musicContext;
        }

        [HttpPost("/songs")]
        public ActionResult addASongToDataBase(Song songToAdd) 
        {
            _musicContext.Songs.Add(songToAdd);
            _musicContext.SaveChanges();

            return Ok();
        }

        [HttpGet("/songs")]
        public ActionResult getAllTheSongs() 
        {
            var songs = _musicContext.Songs;

            return Ok(songs);
        }

        [HttpGet("/songs/{songId}")]
        public ActionResult getASpecificSong(int songId) 
        {
            var songWefound = _musicContext.Songs.FirstOrDefault(s => s.songId == songId);

            if(songWefound == null)
            {
                return NotFound();
            }
            return Ok(songWefound);
        }

        [HttpDelete("/songs/{songId}")]
        public ActionResult deleteASpecificSong(int songId) 
        {
            var songToDelete = _musicContext.Songs.FirstOrDefault(s => s.songId == songId);

            if (songToDelete == null)
            {
                return NotFound();
            }
            _musicContext.Songs.Remove(songToDelete);
            _musicContext.SaveChanges();
            return Ok(songToDelete);
        }

        [HttpPut("/songs/{songId}")]
        public ActionResult updateSpecificSong(int songId, [FromBody] Song songUpdateDetails) 
        {
            var songToUpdate = _musicContext.Songs.FirstOrDefault(s => s.songId == songId);

            if (songToUpdate == null)
            {
                return NotFound();
            }
            songToUpdate.artist = songUpdateDetails.artist;
            songToUpdate.name = songUpdateDetails.name;
            songToUpdate.length = songUpdateDetails.length;

            _musicContext.SaveChanges();
            return Ok(songToUpdate);
        }
    }
}
