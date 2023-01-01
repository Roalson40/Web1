using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web1.Model;

namespace Web1.Context
{
    public interface IDataAccess
    {
        Task<Album> AddAlbumAsync(Album album);

        Task<ICollection<string>> GetAlbumTitlesAsync();

        Task AddImageToAlbumAsync(Image image, string albumTitle);

        Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic);
    }
}