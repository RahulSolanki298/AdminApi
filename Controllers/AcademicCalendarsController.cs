using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminApi.Models;
using AdminApi.Models.School;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AdminApi.Models.Menu;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.Helper;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AcademicCalendarsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<AcademicCalendar> _academicCalendarRepo;

        public AcademicCalendarsController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<AcademicCalendar> academicCalendarRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _academicCalendarRepo = academicCalendarRepo;
        }

        // GET: api/AcademicCalendars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicCalendar>>> GetAcademicCalendar()
        {
            var academicYear = _academicCalendarRepo.SelectAll();
            var totalRecords = academicYear.Count();
            return Ok(new { data = academicYear, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/AcademicCalendars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicCalendar>> GetAcademicCalendar(int id)
        {
            try
            {
                var academyYear = _academicCalendarRepo.SelectById(id);
                return Ok(academyYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/AcademicCalendars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutAcademicCalendar(AcademicCalendar academicCalendar)
        {
            try
            {
                var objAcademyYears = _context.AcademicCalendar.SingleOrDefault(opt => opt.AcademicCalendarId == academicCalendar.AcademicCalendarId);
                objAcademyYears.SchoolId = academicCalendar.SchoolId;
                objAcademyYears.AcademicCalendarPath = academicCalendar.AcademicCalendarPath;
                objAcademyYears.AcademyYearId = academicCalendar.AcademyYearId;
                objAcademyYears.IsActive = academicCalendar.IsActive;

                _context.SaveChanges();
                return Ok(objAcademyYears);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/AcademicCalendars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicCalendar>> PostAcademicCalendar(AcademicCalendar academicCalendar)
        {
            try
            {
                var objCheck = _context.AcademicCalendar.SingleOrDefault(opt => opt.AcademicCalendarId == academicCalendar.AcademicCalendarId);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _academicCalendarRepo.Insert(academicCalendar);
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

        // DELETE: api/AcademicCalendars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicCalendar(int id)
        {
            try
            {
                var singleAcademicYear = _academicCalendarRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool AcademicCalendarExists(int id)
        {
            return _context.AcademicCalendar.Any(e => e.AcademicCalendarId == id);
        }
    }
}
