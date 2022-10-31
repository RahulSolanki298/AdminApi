using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class eBook
    {
        [Key]
        public int eBookId { get; set; }

        [Required]
        public string eBookTitle { get; set; }

        [Required]
        public int eBookDisplayOrder { get; set; }
        public string? eBookCoverPdf { get; set; }

        public string? eBookCoverVideo { get; set; }

        public string? eBookCoverAudio { get; set; }

        public int ClassMasterId { get; set; }

        public int? SubjectId { get; set; }
        public int? SubSubjectId { get; set; }

        public int? TeachingMediumId { get; set; }

        public int IsActive { get; set; }

        [ValidateNever]
        public  Subject Subject { get; set; }
       // [ValidateNever]
        //public  SubSubjects SubSubjects { get; set; }
        [ValidateNever]
        public  TeachingMedium TeachingMedium { get; set; }
        [ValidateNever]
        public  ClassMaster ClassMaster { get; set; }





    }
}
