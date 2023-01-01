using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web1.Model
{
    public class Image
    {
        [Key]
        public string Id { get; set; }
        
        [Required, MaxLength(25)]
        public string ImageTitle { get; set; }
        
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Topic { get; set; }
        
        [ForeignKey("AlbumTitle")]
        public string AlbumTitle { get; set; }
    }
}