using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web1.Context;
using Web1.Model;

namespace Web1.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        private IDataAccess dataAccess;

        public ImagesController(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Image>>> GetImages(string albumCreator, string topic)
        {
            try
            {
                ICollection<Image> images = await dataAccess.GetImagesAsync(albumCreator, topic);
                return Ok(images);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}