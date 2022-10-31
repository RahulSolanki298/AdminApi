using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Models.School
{
    public class SchoolClassDivision
    {
        [Key]
        public int SchoolClassDivisionId { get; set; }

        public int SchoolId { get; set; }

        public int ClassId { get; set; }

        [Required]
        public string Division { get; set; }

        public int IsActive { get; set; }

        public int AcademyYearId { get; set; }

       
    }
}
