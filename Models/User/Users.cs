using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Models.User
{
    public class Users
    {
		public int UserId { get; set; }
		public int UserRoleId { get; set; }
		/*[Required]
		[StringLength(100)]
		public string FullName { get; set; }*/

		/*gulab fields start*/
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [StringLength(100)]
        public string? MiddleName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime? AccessTill { get; set; }

        public string? Gender { get; set; }

        public int? SchoolId { get; set; }

        public DateTime? DateofAdmission { get; set; }

        public string? AdmissionCode { get; set; }

        public int? ClassId { get; set; }

        public int? SchoolClassDivisionId { get; set; }

        public int? IsFather { get; set; }

        public int? IsMother { get; set; }

        public int? IsGuardian { get; set; }

        public int? IsEmployee { get; set; }

        public int? IsStudent { get; set; }

        public int? IsTeacher { get; set; }

        public int? AcademyYearId { get; set; }


        public int CityId { get; set; }

        public string? Address { get; set; }

        /*gulab fields end*/


        [StringLength(100)]
		public string Mobile { get; set; }
		[StringLength(100)]
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		[StringLength(500)]
		public string ImagePath { get; set; }
		[StringLength(50)]
		public string UserName { get; set; }
		[StringLength(100)]
		public string Password { get; set; }
		public bool IsActive { get; set; }
		public int AddedBy { get; set; }
		[DefaultValue(false)]
		public bool IsMigrationData { get; set; }
		[Required]
		public DateTime? DateAdded { get; set; }
		public DateTime? LastPasswordChangeDate { get; set; }
		public int? PasswordChangedBy { get; set; }
		public bool IsPasswordChange { get; set; }

		public bool? FirstTimeLogin { get; set; }
		public DateTime? LastUpdatedDate { get; set; }
		public int? LastUpdatedBy { get; set; }
	}
}
