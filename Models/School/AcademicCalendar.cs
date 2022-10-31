using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class AcademicCalendar
    {
        public int AcademicCalendarId { get; set; }
        [StringLength(500)]
        public string AcademicCalendarPath { get; set; }

        public int SchoolId { get; set; }

        public int AcademyYearId { get; set; }

        public int IsActive { get; set; }
    }
}
