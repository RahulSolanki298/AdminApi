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
    public class ClassroomDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<ClassroomDetails> _classroomDetailRepo;

        public ClassroomDetailsController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<ClassroomDetails> classroomDetailRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _classroomDetailRepo = classroomDetailRepo;
        }

        // GET: api/ClassroomDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassroomDetails>>> GetClassroomDetails()
        {
            var ebookchapterlist = _classroomDetailRepo.SelectAllByClause();
            var totalRecords = ebookchapterlist.Count();
            return Ok(new { data = ebookchapterlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/ClassroomDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassroomDetails>> GetClassroomDetails(int id)
        {
            try
            {
                var singleebookchapter = _classroomDetailRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/ClassroomDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutClassroomDetails(ClassroomDetails classroomDetails)
        {
            try
            {
                var objebookchapter = _context.ClassroomDetails.SingleOrDefault(opt => opt.ClassroomDetailId == classroomDetails.ClassroomDetailId);
                objebookchapter.ClassId = classroomDetails.ClassId;
                objebookchapter.SchoolClassDivisionId = classroomDetails.SchoolClassDivisionId;
                objebookchapter.SubjectId = classroomDetails.SubjectId;
                objebookchapter.SubSubjectId = classroomDetails.SubSubjectId;
                objebookchapter.SubjectTeacher = classroomDetails.SubjectTeacher;
                objebookchapter.ClassTeacher = classroomDetails.ClassTeacher;
                objebookchapter.SchoolId = classroomDetails.SchoolId;
                objebookchapter.AcademyYearId = classroomDetails.AcademyYearId;
                objebookchapter.IsActive = classroomDetails.IsActive;

                _context.SaveChanges();
                return Ok(objebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/ClassroomDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassroomDetails>> PostClassroomDetails(ClassroomDetails classroomDetails)
        {
            try
            {
                var objCheck = _context.ClassroomDetails.SingleOrDefault(opt => opt.ClassroomDetailId == classroomDetails.ClassroomDetailId);
                if (objCheck == null)
                {
                    classroomDetails.IsActive = 1;
                    if (ModelState.IsValid)
                    {
                        var obj = _classroomDetailRepo.Insert(classroomDetails);
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

        // DELETE: api/ClassroomDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroomDetails(int id)
        {
            try
            {
                var singlesubject = _classroomDetailRepo.Delete(id);
                return Ok(singlesubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool ClassroomDetailsExists(int id)
        {
            return _context.ClassroomDetails.Any(e => e.ClassroomDetailId == id);
        }
    }
}
