using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdminApi.Helpers
{
    public class SchoolPublicMethods
    {
        private readonly AppDbContext _context;

        public SchoolPublicMethods()
        {
        }

        public SchoolPublicMethods(AppDbContext context)
        {
            _context = context;
        }

        public int setUserRole(string RoleName)
        {
            return (from x in _context.UserRole
                    where x.RoleName == RoleName
                    select x.UserRoleId).FirstOrDefault();
        }
    }
}
