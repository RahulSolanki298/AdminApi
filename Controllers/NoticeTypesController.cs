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
    public class NoticeTypesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<NoticeType> _noticeTypeRepo;

        public NoticeTypesController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<NoticeType> noticeTypeRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _noticeTypeRepo = noticeTypeRepo;
        }

        // GET: api/NoticeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoticeType>>> GetNoticeType()
        {
            var teachingplanlist = _noticeTypeRepo.SelectAllByClause();
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/NoticeTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoticeType>> GetNoticeType(int id)
        {
            try
            {
                var singleebookchapter = _noticeTypeRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/NoticeTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutNoticeType(NoticeType noticeType)
        {
            try
            {
                var objClassMaster = _context.NoticeType.SingleOrDefault(opt => opt.NoticeTypeId == noticeType.NoticeTypeId);
                objClassMaster.NoticeTypeName = noticeType.NoticeTypeName;
                objClassMaster.IsActive = noticeType.IsActive;
               

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/NoticeTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoticeType>> PostNoticeType(NoticeType noticeType)
        {
            try
            {
                var objCheck = _context.NoticeType.SingleOrDefault(opt => opt.NoticeTypeId == noticeType.NoticeTypeId);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _noticeTypeRepo.Insert(noticeType);
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

        // DELETE: api/NoticeTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteNoticeType(int id)
        {
            try
            {
                var singleAcademicYear = _noticeTypeRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool NoticeTypeExists(int id)
        {
            return _context.NoticeType.Any(e => e.NoticeTypeId == id);
        }
    }
}
