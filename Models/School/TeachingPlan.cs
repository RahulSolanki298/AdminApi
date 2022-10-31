using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Models.School
{
    public class TeachingPlan
    {
        [Key]
        public int TeachingPlanId { get; set; }

        public string? TeachingPlanName { get; set; }

        public int eBookChapterId { get; set; }

        [Required]
        public int DayNumber { get; set; }
        public int? AcademyYearId { get; set; }

    }
}
