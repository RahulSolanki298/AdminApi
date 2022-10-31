
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class Videos
    {
        [Key]
        public int VideoId { get; set; }

        public int VideoCategoryId { get; set; }

        public string VideoPath { get; set; }

        public string VideoName { get; set; }

        public string VideoThumbnail { get; set; }

        public int IsActive { get; set; }

        [ValidateNever]
        public virtual VideoCategory VideoCategories { get; set; }



    }
}
