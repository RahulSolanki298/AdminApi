using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class StudentPasswordImages
    {
        [Key]
        public int StudentPasswordImageId { get; set; }

        public string StudentPasswordImagePath { get; set; }

        public string StudentPasswordImageName { get; set; }

        public string StudentPasswordImageCategory { get; set; }

        public bool IsActive { get; set; }
    }
}
