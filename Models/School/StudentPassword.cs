

using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class StudentPassword
    {
        [Key]
        public int StudentPasswordId { get; set; }

        public int StudentId { get; set; }

        public int ChoiceId1 { get; set; }
        public int ChoiceId2 { get; set; }

        //public bool? FirstTimeLogin { get; set; }

        public bool IsActive { get; set; }
    }
}
