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
    public class HomeworkController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<Homework> _homeworkRepo;


        public HomeworkController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                             ISqlRepository<Homework> homeworkRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _homeworkRepo = homeworkRepo;

        }

        // GET: api/Homework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetHomeworks()
        {
            var subsubjetlist = _homeworkRepo.SelectAllByClause();// (includeProperties: "VideoCategory");
            var totalRecords = subsubjetlist.Count();
            return Ok(new { data = subsubjetlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/Homework/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Homework>> GetHomework(int id)
        {
            try
            {
                var singlesubsubject = _homeworkRepo.SelectById(id);
                return Ok(singlesubsubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/Homework/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutHomework(Homework homework)
        {
            try
            {
                var objsubsubject = _context.Homeworks.SingleOrDefault(opt => opt.HomeWorkId == homework.HomeWorkId);
                objsubsubject.StartDate = homework.StartDate;
                objsubsubject.EndDate = homework.EndDate;
                objsubsubject.ClassId = homework.ClassId;
                objsubsubject.SchoolId = homework.SchoolId;
                objsubsubject.TeacherId = homework.TeacherId;
                objsubsubject.SubjectID = homework.SubjectID;
                objsubsubject.BookId = homework.BookId;
                objsubsubject.ChapterId = homework.ChapterId;
                objsubsubject.FilePath = homework.FilePath;
                objsubsubject.Notes = homework.Notes;
                objsubsubject.IsActive = homework.IsActive;

                _context.SaveChanges();
                return Ok(objsubsubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/Homework
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Homework>> PostHomework(Homework homework)
        {
            try
            {
                var objCheck = _context.Homeworks.SingleOrDefault(opt => opt.HomeWorkId == homework.HomeWorkId);
                if (objCheck == null)
                {
                    homework.IsActive = 1;
                    if (ModelState.IsValid)
                    {
                        var obj = _homeworkRepo.Insert(homework);
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

        // DELETE: api/Homework/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomework(int id)
        {
            try
            {
                var singlesubject = _homeworkRepo.Delete(id);
                return Ok(singlesubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool HomeworkExists(int id)
        {
            return _context.Homeworks.Any(e => e.HomeWorkId == id);
        }
    }
}
