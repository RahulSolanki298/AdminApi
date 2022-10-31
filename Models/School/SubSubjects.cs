using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Models.School
{
    public class SubSubjects
    {
        [Key]
        public int SubSubjectId { get; set; }

        [Required]
        public string SubSubjectName { get; set; }

        public int IsActive { get; set; }

        public  int SubjectId { get; set; }

        [ValidateNever]
        public Subject Subject { get; set; }

    }
}
