using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sedc.MusicManager.WebApp.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

    }
}