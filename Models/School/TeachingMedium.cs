using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Models.School
{
    public class TeachingMedium
    {
        public int TeachingMediumId { get; set; }
        [Required]
        public string TeachingMediumName { get; set; }

        public int IsActive { get; set; }
    }
}
