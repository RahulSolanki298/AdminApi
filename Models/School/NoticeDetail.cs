using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Models.School
{
    public class NoticeDetail
    {
        [Key]
        public int NoticeDetailId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ApplicableTo { get; set; }

        public int NoticeTypeId { get; set; }

        public int? ClassId { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

       

        public string? Classes { get; set; }

        public int SchoolId { get; set; }

        public int AcademyYearId { get; set; }

        public int IsActive { get; set; }
       
    }
}
