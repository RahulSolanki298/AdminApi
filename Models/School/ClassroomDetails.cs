using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class ClassroomDetails
    {
        [Key]
        public int ClassroomDetailId { get; set; }

        public int ClassId { get; set; }
       

        public int SchoolClassDivisionId { get; set; }
        

        public int? SubjectId { get; set; }

        

        public int? SubSubjectId { get; set; }

       

        public int? SubjectTeacher { get; set; }

        public int? ClassTeacher { get; set; }

        public int SchoolId { get; set; }

        public int AcademyYearId { get; set; }

        public int IsActive { get; set; }

        [ValidateNever]
        public AcademyYear? AcademyYear
        {
            get; set;
        }
    }
}
