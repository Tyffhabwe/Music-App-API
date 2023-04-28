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

        [HttpGet("/songs/{songId}")]
        public ActionResult getASpecificSong(long id) 
        {
            var songWeFound = _musicContext.Songs.Where(s => s.songId == id).ToList();

            Console.WriteLine(songWeFound);

            return Ok(songWeFound);
        }

        [HttpDelete("/songs/{songId}")]
        public ActionResult deleteASpecficiSong(long id) 
        {
            var songToDelete = _musicContext.Songs.Where(s => s.songId == id);

            return Ok(songToDelete);
        }

        [HttpPut("/songs/{songId}")]
        public ActionResult updateSpecifcSong(long id, [FromBody] Song songUpdateDetails) 
        {
            var songToUpdate = _musicContext.Songs.Where(s => s.songId == id);

            return Ok(songUpdateDetails);
        }
    }
}
