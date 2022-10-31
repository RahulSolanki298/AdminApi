using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Models.School
{
    public class ParentStudent
    {
        [Key]
        public int ParentStudentId { get; set; }

        public int StudentId { get; set; }

        public int FatherId { get; set; }

        public int MotherId { get; set; }

        public int GuardianId { get; set; }

        public int SchoolId { get; set; }
    }
}
