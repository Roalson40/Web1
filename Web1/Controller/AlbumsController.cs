using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web1.Context;
using Web1.Model;

namespace Web1.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private IDataAccess dataAccess;

        public AlbumsController(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpPost]
        public async Task<ActionResult<Album>> CreateAlbum([FromBody] Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               
                Album newAlbum = await dataAccess.AddAlbumAsync(album);
                Console.WriteLine(album.AlbumTitle);
                return Created("https://localhost:5001/Album", newAlbum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<string>>> GetTitles()
        {
            try
            {
                ICollection<string> strings = await dataAccess.GetAlbumTitlesAsync();
                return Ok(strings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
            
        [HttpPost("Image", Name = nameof(Image))]
        public async Task<ActionResult> AddImageToAlbum([FromRoute] Image img, string title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Image newImg = new Image()
                {
                    ImageTitle = img.ImageTitle,
                    Description = img.Description,
                    Url = img.Url,
                    Topic = img.Topic
                };
                await dataAccess.AddImageToAlbumAsync(newImg, title);
                return Created("https://localhost:5001/Image/{title}", newImg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}