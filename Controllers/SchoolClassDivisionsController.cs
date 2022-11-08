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
using AdminApi.Migrations;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SchoolClassDivisionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<SchoolClassDivision> _schoolClassDivisionRepo;

        public SchoolClassDivisionsController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<SchoolClassDivision> schoolClassDivisionRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _schoolClassDivisionRepo = schoolClassDivisionRepo;
        }

        // GET: api/SchoolClassDivisions
        [HttpGet("{schoolId}")]
        public async Task<ActionResult<IEnumerable<SchoolClassDivision>>> GetschoolClassDivisions(int? schoolId)
        {
            var teachingplanlist = _schoolClassDivisionRepo.SelectAllByClause(s => s.SchoolId == schoolId);
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/SchoolClassDivisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolClassDivision>> GetSchoolClassDivision(int id)
        {
            try
            {
                var singleebookchapter = _schoolClassDivisionRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/SchoolClassDivisions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutSchoolClassDivision(SchoolClassDivision schoolClassDivision)
        {
            try
            {
                var objClassMaster = _context.schoolClassDivisions.SingleOrDefault(opt => opt.SchoolClassDivisionId == schoolClassDivision.SchoolClassDivisionId);
                objClassMaster.SchoolId = schoolClassDivision.SchoolId;
                objClassMaster.ClassId = schoolClassDivision.ClassId;
                objClassMaster.Division = schoolClassDivision.Division;
                objClassMaster.IsActive = schoolClassDivision.IsActive;
                objClassMaster.AcademyYearId = schoolClassDivision.AcademyYearId;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/SchoolClassDivisions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolClassDivision>> PostSchoolClassDivision(SchoolClassDivision schoolClassDivision)
        {
            try
            {
                var objCheck = _context.schoolClassDivisions.SingleOrDefault(opt => opt.SchoolClassDivisionId == schoolClassDivision.SchoolClassDivisionId);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _schoolClassDivisionRepo.Insert(schoolClassDivision);
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

        // DELETE: api/SchoolClassDivisions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteSchoolClassDivision(int id)
        {
            try
            {
                var singleAcademicYear = _schoolClassDivisionRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool SchoolClassDivisionExists(int id)
        {
            return _context.schoolClassDivisions.Any(e => e.SchoolClassDivisionId == id);
        }
    }
}
