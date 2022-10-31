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
    public class AcademyYearsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<AcademyYear> _academicYearRepo;

        public AcademyYearsController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<AcademyYear> academicYearRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _academicYearRepo = academicYearRepo;
        }

        // GET: api/AcademyYears
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<AcademyYear>>> GetAcademyYears()
        {
           var academicYear= _academicYearRepo.SelectAll();
            var totalRecords = academicYear.Count();
            return Ok(new { data = academicYear, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            //return Ok(academicYear); //await _context.AcademyYears.ToListAsync();
        }

        // GET: api/AcademyYears/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AcademyYear>> GetAcademyYear(int id)
        {
            try
            {
                var academyYear = _academicYearRepo.SelectById(id);
                return Ok(academyYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }

           
            //var academyYear = await _context.AcademyYears.FindAsync(id);

           
        }

        // PUT: api/AcademyYears/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult PutAcademyYear(AcademyYear academyYear)
        {
            try
            {
                var objAcademyYears = _context.AcademyYears.SingleOrDefault(opt => opt.AcademyYearId == academyYear.AcademyYearId);
                objAcademyYears.AcademyYearName = academyYear.AcademyYearName;
                
                _context.SaveChanges();
                return Ok(objAcademyYears);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }           
        }

        // POST: api/AcademyYears
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public  ActionResult PostAcademyYear(AcademyYear model)
        {
            try
            {
                var objCheck = _context.AcademyYears.SingleOrDefault(opt => opt.AcademyYearName == model.AcademyYearName);
                if (objCheck == null)
                {
                   
                    if (ModelState.IsValid)
                    {
                        var obj = _academicYearRepo.Insert(model);
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




            /*_context.AcademyYears.Add(academyYear);
            await _context.SaveChangesAsync();
            return Ok();*/

            //return CreatedAtAction("GetAcademyYear", new { id = academyYear.AcademyYearId }, academyYear);
        }

        // DELETE: api/AcademyYears/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public  IActionResult DeleteAcademyYear(int id)
        {
            try
            {
                var singleAcademicYear = _academicYearRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }

            /* var academyYear = await _context.AcademyYears.FindAsync(id);
             if (academyYear == null)
             {
                 return NotFound();
             }

             var singleyear = _academicYearRepo.Delete(id);
             //var singleyear= _context.AcademyYears.Remove(academyYear);
             await _context.SaveChangesAsync();
             return Ok(singleyear);*/
            // return NoContent();
        }

        private bool AcademyYearExists(int id)
        {
            return _context.AcademyYears.Any(e => e.AcademyYearId == id);
        }
    }
}
