using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Models.School
{
    public class SchoolBookPrice
    {
        public int SchoolBookPriceId { get; set; }

        public int ClassId { get; set; }

        public int SchoolId { get; set; }

        public decimal Price { get; set; }


        public int AcademyYearId { get; set; }

        
    }
}
