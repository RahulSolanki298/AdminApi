using System;

namespace AdminApi.Models.School
{
    public class Homework
    {
        public int HomeWorkId { get; set; }

        public DateTime  StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int ClassId { get; set; }

        public int SchoolId { get; set; }

        public int TeacherId { get; set; }

        public int SubjectID  { get; set; }

        public int BookId { get; set; }

        public int ChapterId { get; set; }

        public string FilePath { get; set; }

        public string Notes { get; set; }

        public int IsActive { get; set; }

        public string Type { get; set; }
    }
}
