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
    public class SchoolBookPricesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<SchoolBookPrice> _schoolBookPriceRepo;

        public SchoolBookPricesController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<SchoolBookPrice> schoolBookPriceRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _schoolBookPriceRepo = schoolBookPriceRepo;
        }

        // GET: api/SchoolBookPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolBookPrice>>> GetSchoolBookPrice()
        {
            var teachingplanlist = _schoolBookPriceRepo.SelectAllByClause();
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SchoolBookPrice>>> GetSchoolBookPriceBySchool(int id)
        {
            var teachingplanlist = _schoolBookPriceRepo.SelectAllByClause().Where(p=>p.SchoolId==id);
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/SchoolBookPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolBookPrice>> GetSchoolBookPrice(int id)
        {
            try
            {
                var singleebookchapter = _schoolBookPriceRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/SchoolBookPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutSchoolBookPrice(SchoolBookPrice schoolBookPrice)
        {
            try
            {
                var objClassMaster = _context.SchoolBookPrice.SingleOrDefault(opt => opt.SchoolBookPriceId == schoolBookPrice.SchoolBookPriceId);
                objClassMaster.SchoolId = schoolBookPrice.SchoolId;
                objClassMaster.ClassId = schoolBookPrice.ClassId;
                objClassMaster.Price = schoolBookPrice.Price;
                //objClassMaster.IsActive = schoolBookPrice.IsActive;
                objClassMaster.AcademyYearId = schoolBookPrice.AcademyYearId;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/SchoolBookPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolBookPrice>> PostSchoolBookPrice(SchoolBookPrice schoolBookPrice)
        {
            try
            {
                var objCheck = _context.SchoolBookPrice.SingleOrDefault(opt => opt.SchoolBookPriceId == schoolBookPrice.SchoolBookPriceId);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _schoolBookPriceRepo.Insert(schoolBookPrice);
                        return Ok(obj);
                    }
                }
                else if (objCheck != null)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate Price!" });
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "unknown", ResponseMsg = ex.Message });
            }
        }

        // DELETE: api/SchoolBookPrices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteSchoolBookPrice(int id)
        {
            try
            {
                var singleAcademicYear = _schoolBookPriceRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool SchoolBookPriceExists(int id)
        {
            return _context.SchoolBookPrice.Any(e => e.SchoolBookPriceId == id);
        }
    }
}
