using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class AcademyYear
    {
        [Key]
        public int AcademyYearId { get; set; }

        [Required]
        [StringLength(100)]
        public string AcademyYearName { get; set; }
    }
}
