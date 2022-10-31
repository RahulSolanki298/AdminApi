using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Models.School
{
    public class NoticeType
    {
        public int NoticeTypeId { get; set; }

        [Required]
        public string NoticeTypeName { get; set; }

        public int IsActive { get; set; }
    }
}
