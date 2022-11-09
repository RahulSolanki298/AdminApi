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
    public class ClassMastersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<ClassMaster> _classMasterRepo;

        public ClassMastersController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<ClassMaster> classMasterRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _classMasterRepo = classMasterRepo;
        }

        // GET: api/ClassMasters
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ClassMaster>>> GetClassMasters()
        {
            var classmasterlist = _classMasterRepo.SelectAll();
            var totalRecords = classmasterlist.Count();
            return Ok(new { data = classmasterlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/ClassMasters/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ClassMaster>> GetClassMaster(int id)
        {
            try
            {
                var singleclassmaster = _classMasterRepo.SelectById(id);
                return Ok(singleclassmaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/ClassMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutClassMaster(ClassMaster classMaster)
        {
            try
            {
                var objClassMaster = _context.ClassMasters.SingleOrDefault(opt => opt.ClassId == classMaster.ClassId);
                objClassMaster.ClassName = classMaster.ClassName;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/ClassMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ClassMaster>> PostClassMaster(ClassMaster classMaster)
        {
            try
            {
                var objCheck = _context.ClassMasters.SingleOrDefault(opt => opt.ClassName == classMaster.ClassName);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _classMasterRepo.Insert(classMaster);
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

        // DELETE: api/ClassMasters/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClassMaster(int id)
        {
            try
            {
                var singleAcademicYear = _classMasterRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool ClassMasterExists(int id)
        {
            return _context.ClassMasters.Any(e => e.ClassId == id);
        }
    }
}
