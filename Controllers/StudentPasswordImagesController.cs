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

    public class StudentPasswordImagesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<StudentPasswordImages> _studentPasswordImageRepo;

        public StudentPasswordImagesController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<StudentPasswordImages> studentPasswordImageRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _studentPasswordImageRepo = studentPasswordImageRepo;
        }

        // GET: api/StudentPasswordImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentPasswordImages>>> GetStudentPasswordImages()
        {
            var teachingplanlist = _studentPasswordImageRepo.SelectAllByClause();
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/StudentPasswordImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentPasswordImages>> GetStudentPasswordImages(int id)
        {
            try
            {
                var singleebookchapter = _studentPasswordImageRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/StudentPasswordImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutStudentPasswordImages(StudentPasswordImages studentPasswordImages)
        {
            try
            {
                var objClassMaster = _context.StudentPasswordImages.SingleOrDefault(opt => opt.StudentPasswordImageId == studentPasswordImages.StudentPasswordImageId);
                objClassMaster.StudentPasswordImagePath = studentPasswordImages.StudentPasswordImagePath;
                objClassMaster.StudentPasswordImageName = studentPasswordImages.StudentPasswordImageName;
                objClassMaster.StudentPasswordImageCategory = studentPasswordImages.StudentPasswordImageCategory;
                objClassMaster.IsActive = studentPasswordImages.IsActive;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/StudentPasswordImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<StudentPasswordImages>> PostStudentPasswordImages(StudentPasswordImages studentPasswordImages)
        {
            try
            {
                var objCheck = _context.StudentPasswordImages.SingleOrDefault(opt => opt.StudentPasswordImageName == studentPasswordImages.StudentPasswordImageName);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _studentPasswordImageRepo.Insert(studentPasswordImages);
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

        // DELETE: api/StudentPasswordImages/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentPasswordImages(int id)
        {
            try
            {
                var singleAcademicYear = _studentPasswordImageRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool StudentPasswordImagesExists(int id)
        {
            return _context.StudentPasswordImages.Any(e => e.StudentPasswordImageId == id);
        }
    }
}
