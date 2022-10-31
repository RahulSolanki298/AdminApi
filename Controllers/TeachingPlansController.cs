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
using AdminApi.ViewModels;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachingPlansController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<TeachingPlan> _teachingPlanRepo;

        public TeachingPlansController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<TeachingPlan> teachingPlanRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _teachingPlanRepo = teachingPlanRepo;
        }

        // GET: api/TeachingPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachingPlanData>>> GetTeachingPlan()
        {
            var teachingplanlist = await (from tplan in _context.TeachingPlan
                                          join ebook in _context.eBookChapter on tplan.eBookChapterId equals ebook.eBookChapterId
                                          join acdYear in _context.AcademyYears on tplan.AcademyYearId equals acdYear.AcademyYearId
                                          select new TeachingPlanData
                                          {
                                              eBookChapterId = ebook.eBookChapterId,
                                              eBookChapterTitle = ebook.eBookChapterTitle,
                                              AcademyYearId = tplan.AcademyYearId,
                                              AcademyYearName = acdYear.AcademyYearName,
                                              TeachingPlanId = tplan.TeachingPlanId,
                                              DayNumber = tplan.DayNumber,
                                              TeachingPlanName = tplan.TeachingPlanName
                                          }).ToListAsync();
            var totalRecords = teachingplanlist.Count();
            return Ok(new { data = teachingplanlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/TeachingPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeachingPlanData>> GetTeachingPlan(int id)
        {
            try
            {
                var singleebookchapter = await (from tplan in _context.TeachingPlan
                                                join ebook in _context.eBookChapter on tplan.eBookChapterId equals ebook.eBookChapterId
                                                join acdYear in _context.AcademyYears on tplan.AcademyYearId equals acdYear.AcademyYearId
                                                where tplan.TeachingPlanId == id
                                                select new TeachingPlanData
                                                {
                                                    eBookChapterId = ebook.eBookChapterId,
                                                    eBookChapterTitle = ebook.eBookChapterTitle,
                                                    AcademyYearId = tplan.AcademyYearId,
                                                    AcademyYearName = acdYear.AcademyYearName,
                                                    TeachingPlanId = tplan.TeachingPlanId,
                                                    DayNumber = tplan.DayNumber,
                                                    TeachingPlanName = tplan.TeachingPlanName
                                                }).FirstOrDefaultAsync();
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/TeachingPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutTeachingPlan(TeachingPlan teachingPlan)
        {
            try
            {
                var objClassMaster = _context.TeachingPlan.SingleOrDefault(opt => opt.TeachingPlanId == teachingPlan.TeachingPlanId);
                objClassMaster.TeachingPlanName = teachingPlan.TeachingPlanName;
                objClassMaster.AcademyYearId = teachingPlan.AcademyYearId;
                objClassMaster.DayNumber = teachingPlan.DayNumber;
                objClassMaster.eBookChapterId = teachingPlan.eBookChapterId;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/TeachingPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeachingPlan>> PostTeachingPlan(TeachingPlanData teachingPlan)
        {
            try
            {
                var data = new TeachingPlan
                {
                    AcademyYearId = teachingPlan.AcademyYearId,
                    DayNumber = teachingPlan.DayNumber,
                    eBookChapterId = teachingPlan.eBookChapterId,
                    TeachingPlanId = teachingPlan.TeachingPlanId,
                    TeachingPlanName = teachingPlan.TeachingPlanName,
                };
                var objCheck = await _context.TeachingPlan.SingleOrDefaultAsync(opt => opt.TeachingPlanName == teachingPlan.TeachingPlanName);
                if (objCheck == null && teachingPlan.TeachingPlanId == 0)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _teachingPlanRepo.Insert(data);
                        return Ok(obj);
                    }
                }
                else if (objCheck != null && teachingPlan.TeachingPlanId == 0)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate Role name!" });
                }
                else
                {
                    objCheck = await _context.TeachingPlan.FirstOrDefaultAsync(opt => opt.TeachingPlanId == teachingPlan.TeachingPlanId);
                    objCheck.TeachingPlanName = teachingPlan.TeachingPlanName;
                    objCheck.AcademyYearId = teachingPlan.AcademyYearId;
                    objCheck.DayNumber = teachingPlan.DayNumber;
                    objCheck.eBookChapterId = teachingPlan.eBookChapterId;
                    var obj = _teachingPlanRepo.Update(objCheck);
                    return Ok(obj);
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "unknown", ResponseMsg = ex.Message });
            }
        }

        // DELETE: api/TeachingPlans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteTeachingPlan(int id)
        {
            try
            {
                var singleAcademicYear = _teachingPlanRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool TeachingPlanExists(int id)
        {
            return _context.TeachingPlan.Any(e => e.TeachingPlanId == id);
        }
    }
}
