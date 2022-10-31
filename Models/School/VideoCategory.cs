using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class VideoCategory
    {
        [Key]
        public int VideoCategoryId { get; set; }

        public string VideoCategoryName { get; set; }

        public int IsActive { get; set; }
    }
}
