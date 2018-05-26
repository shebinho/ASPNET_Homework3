using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sedc.MusicManager.WebApp.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public ArtistType ArtistType { get;set;}

        public virtual ICollection<Album> Albums { get; set; }
    }
}