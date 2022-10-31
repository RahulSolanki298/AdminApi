using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class ClassMaster
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public string ClassName { get; set; }

        public int IsActive { get; set; }

        public int? SchoolId { get; set; }
    }
}
