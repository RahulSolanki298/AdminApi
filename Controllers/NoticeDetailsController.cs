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
    public class NoticeDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<NoticeDetail> _noticeDetailRepo;

        public NoticeDetailsController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<NoticeDetail> noticeDetailRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _noticeDetailRepo = noticeDetailRepo;
        }

        // GET: api/NoticeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoticeDetail>>> GetNoticeDetail()
        {
            var teachingplanlist = _noticeDetailRepo.SelectAllByClause();
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/NoticeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoticeDetail>> GetNoticeDetail(int id)
        {
            try
            {
                var singleebookchapter = _noticeDetailRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/NoticeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutNoticeDetail(NoticeDetail noticeDetail)
        {
            try
            {
                var objClassMaster = _context.NoticeDetail.SingleOrDefault(opt => opt.NoticeDetailId == noticeDetail.NoticeDetailId);
                objClassMaster.StartDate = noticeDetail.StartDate;
                objClassMaster.EndDate = noticeDetail.EndDate;
                objClassMaster.ApplicableTo = noticeDetail.ApplicableTo;
                objClassMaster.NoticeTypeId = noticeDetail.NoticeTypeId;
                objClassMaster.ClassId = noticeDetail.ClassId;
                objClassMaster.Topic = noticeDetail.Topic;
                objClassMaster.Description = noticeDetail.Description;
                objClassMaster.Classes = noticeDetail.Classes;
                objClassMaster.AcademyYearId = noticeDetail.AcademyYearId;
                objClassMaster.SchoolId = noticeDetail.SchoolId;
                objClassMaster.IsActive = noticeDetail.IsActive;


                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/NoticeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoticeDetail>> PostNoticeDetail(NoticeDetail noticeDetail)
        {
            try
            {
                var objCheck = _context.NoticeDetail.SingleOrDefault(opt => opt.NoticeDetailId == noticeDetail.NoticeDetailId);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _noticeDetailRepo.Insert(noticeDetail);
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

        // DELETE: api/NoticeDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteNoticeDetail(int id)
        {
            try
            {
                var singleAcademicYear = _noticeDetailRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool NoticeDetailExists(int id)
        {
            return _context.NoticeDetail.Any(e => e.NoticeDetailId == id);
        }
    }
}
