using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AdminApi.Models.School
{
    public class eBookChapter
    {
        [Key]
        public int eBookChapterId { get; set; }

        [Required]
        public string eBookChapterTitle { get; set; }
        [Required]
        public int ChapterDisplayOrder { get; set; }

        public string? ChapterPdf { get; set; }

        public string? ChapterVideo { get; set; }

        public string? ChapterAudio { get; set; }

        public int eBookId { get; set; }
       

        public int IsActive { get; set; }

        [ValidateNever]
        public eBook eBook { get; set; }
    }
}
