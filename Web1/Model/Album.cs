using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web1.Model
{
    public class Album
    {
        [Key, MaxLength(25)]
        public string AlbumTitle { get; set; }

        [MaxLength(150)]
        public string AlbumDescription { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        
        public ICollection<Image> Images { get; set; }
    }
}