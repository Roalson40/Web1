using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Web1.Model;

namespace Web1.Context
{
    public class KindContext : DbContext, IDataAccess
    {
        public DbSet<Album> Albums { get; set; }
        
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DnpExam.db");
        }

        public async Task<Album> AddAlbumAsync(Album album)
        {
            EntityEntry<Album> newAlbum = await Albums.AddAsync(album);
            Console.WriteLine(album.AlbumTitle);
            await SaveChangesAsync();
            return newAlbum.Entity;
        }

        public async Task<ICollection<string>> GetAlbumTitlesAsync()
        {
            ICollection<string> collection = new List<string>();
            for (int i = 0; i < Albums.ToListAsync().Result.Count; i++)
            {
                collection.Add(Albums.ToListAsync().Result[i].AlbumTitle);
            }

            return collection;
        }

        public Task AddImageToAlbumAsync(Image image, string albumTitle)
        {
            for (int i = 0; i < Albums.ToListAsync().Result.Count; i++)
            {
                if (Albums.ToListAsync().Result[i].AlbumTitle == albumTitle)
                { 
                    Albums.ToListAsync().Result[i].Images.Add(image);
                }
            }
            return SaveChangesAsync();
        }

        public async Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic)
        {
            ICollection<Image> images = new List<Image>();
            
            for (int i = 0; i < Albums.ToListAsync().Result.Count; i++)
            {
                if (Albums.ToListAsync().Result[i].CreatedBy == albumCreator)
                {
                    for (int j = 0; j < Albums.ToListAsync().Result[i].Images.Count; j++)
                    {
                        if (Albums.ToListAsync().Result[i].Images.ToList()[j].Topic == topic)
                        {
                            images.Add(Albums.ToListAsync().Result[i].Images.ToList()[j]);
                        }
                    }
                }
            }
            return images;
        }
    }
}