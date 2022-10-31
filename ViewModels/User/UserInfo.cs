using System;
using System.ComponentModel.DataAnnotations;

namespace AdminApi.ViewModels.User
{
    public class UserInfo
    {
        public int UserId { get; set; }	
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public string FirstName { get; set; }

      
        public string? MiddleName { get; set; }
       
        public string LastName { get; set; }
        public string Mobile { get; set; }
		public string Email { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? LastUpdatedBy { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int? SchoolId { get; set; }
        public int? ClassId { get; set; }
        public bool? FirstTimeLogin { get; set; }
        public bool IsPasswordChange { get; set; }
    }
}