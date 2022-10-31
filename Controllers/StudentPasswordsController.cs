using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminApi.Models;
using AdminApi.Models.School;
using AdminApi.Models.Menu;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.Helper;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentPasswordsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<StudentPassword> _studentPasswordRepo;

        public StudentPasswordsController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<StudentPassword> studentPasswordRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _studentPasswordRepo = studentPasswordRepo;
        }

        // GET: api/StudentPasswords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentPassword>>> GetStudentPassword()
        {
            var teachingplanlist = _studentPasswordRepo.SelectAllByClause();
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/StudentPasswords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentPassword>> GetStudentPassword(int id)
        {
            try
            {
                var singleebookchapter = _studentPasswordRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/StudentPasswords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutStudentPassword(StudentPassword studentPassword)
        {
            try
            {
                var objClassMaster = _context.StudentPassword.SingleOrDefault(opt => opt.StudentPasswordId == studentPassword.StudentPasswordId);
                objClassMaster.StudentId = studentPassword.StudentId;
                objClassMaster.ChoiceId1 = studentPassword.ChoiceId1;
                objClassMaster.ChoiceId2 = studentPassword.ChoiceId2;
                objClassMaster.IsActive = studentPassword.IsActive;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/StudentPasswords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentPassword>> PostStudentPassword(StudentPassword studentPassword)
        {
            try
            {
                var objCheck = _context.StudentPassword.SingleOrDefault(opt => opt.StudentId == studentPassword.StudentId);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _studentPasswordRepo.Insert(studentPassword);
                        return Ok(obj);
                    }
                }
                else if (objCheck != null)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate Role name!" });
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "unknown", ResponseMsg = ex.Message });
            }
        }

        // DELETE: api/StudentPasswords/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentPassword(int id)
        {
            try
            {
                var singleAcademicYear = _studentPasswordRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool StudentPasswordExists(int id)
        {
            return _context.StudentPassword.Any(e => e.StudentPasswordId == id);
        }
    }
}
