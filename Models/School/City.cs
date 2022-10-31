

using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models.School
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int IsActive { get; set; }
    }
}
