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

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParentStudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<ParentStudent> _parentStudentRepo;

        public ParentStudentsController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<ParentStudent> parentStudentRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _parentStudentRepo = parentStudentRepo;
        }

        // GET: api/ParentStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentStudent>>> GetParentStudent()
        {
            var teachingplanlist = _parentStudentRepo.SelectAllByClause();
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }
            // GET: api/ParentStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParentStudent>> GetParentStudent(int id)
        {
            try
            {
                var singleebookchapter = _parentStudentRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/ParentStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutParentStudent(ParentStudent parentStudent)
        {
            try
            {
                var objClassMaster = _context.ParentStudent.SingleOrDefault(opt => opt.ParentStudentId == parentStudent.ParentStudentId);
                objClassMaster.StudentId = parentStudent.StudentId;
                objClassMaster.FatherId = parentStudent.FatherId;
                objClassMaster.MotherId = parentStudent.MotherId;
                objClassMaster.GuardianId = parentStudent.GuardianId;
                objClassMaster.SchoolId = parentStudent.SchoolId;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/ParentStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParentStudent>> PostParentStudent(ParentStudent parentStudent)
        {
            try
            {
                var objCheck = _context.ParentStudent.SingleOrDefault(opt => opt.StudentId == parentStudent.StudentId);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _parentStudentRepo.Insert(parentStudent);
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

        // DELETE: api/ParentStudents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteParentStudent(int id)
        {
            try
            {
                var singleAcademicYear = _parentStudentRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool ParentStudentExists(int id)
        {
            return _context.ParentStudent.Any(e => e.ParentStudentId == id);
        }
    }
}
