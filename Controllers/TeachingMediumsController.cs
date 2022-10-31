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
    public class TeachingMediumsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<TeachingMedium> _teachingMediumRepo;

        public TeachingMediumsController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<TeachingMedium> teachingMediumRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _teachingMediumRepo = teachingMediumRepo;
        }

        // GET: api/TeachingMediums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachingMedium>>> GetTeachingMedia()
        {
            var teachingmediumlist = _teachingMediumRepo.SelectAllByClause();
            var totalRecords = teachingmediumlist.Count();
            return Ok(new { data = teachingmediumlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/TeachingMediums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeachingMedium>> GetTeachingMedium(int id)
        {
            try
            {
                var singleebookchapter = _teachingMediumRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/TeachingMediums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutTeachingMedium(TeachingMedium teachingMedium)
        {
            try
            {
                var objClassMaster = _context.TeachingMedium.SingleOrDefault(opt => opt.TeachingMediumId == teachingMedium.TeachingMediumId);
                objClassMaster.TeachingMediumName = teachingMedium.TeachingMediumName;
                objClassMaster.IsActive=teachingMedium.IsActive;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/TeachingMediums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeachingMedium>> PostTeachingMedium(TeachingMedium teachingMedium)
        {
            try
            {
                var objCheck = _context.TeachingMedium.SingleOrDefault(opt => opt.TeachingMediumName == teachingMedium.TeachingMediumName);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _teachingMediumRepo.Insert(teachingMedium);
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

        // DELETE: api/TeachingMediums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteTeachingMedium(int id)
        {
            try
            {
                var singleAcademicYear = _teachingMediumRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool TeachingMediumExists(int id)
        {
            return _context.TeachingMedium.Any(e => e.TeachingMediumId == id);
        }
    }
}
