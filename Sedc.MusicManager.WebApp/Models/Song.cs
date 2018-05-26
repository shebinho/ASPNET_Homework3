using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sedc.MusicManager.WebApp.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is requred")]
        [StringLength(maximumLength: 20, MinimumLength = 6)]
        public string Title { get; set; }

        [StringLength(maximumLength: 100)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        [ForeignKey("Album")]
        [Display(AutoGenerateField = false)]
        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}