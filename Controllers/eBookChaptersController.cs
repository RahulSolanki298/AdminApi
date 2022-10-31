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
    public class eBookChaptersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<eBookChapter> _ebookChapterRepo;

        public eBookChaptersController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<eBookChapter> ebookChapterRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _ebookChapterRepo = ebookChapterRepo;
        }

        // GET: api/eBookChapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<eBookChapter>>> GeteBookChapter()
        {
            var ebookchapterlist = _ebookChapterRepo.SelectAllByClause(includeProperties: "eBook");
            var totalRecords = ebookchapterlist.Count();
            return Ok(new { data = ebookchapterlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/eBookChapters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<eBookChapter>> GeteBookChapter(int id)
        {
            try
            {
                var singleebookchapter = _ebookChapterRepo.SelectById(id);
                return Ok(singleebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/eBookChapters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PuteBookChapter(eBookChapter eBookChapter)
        {
            try
            {
                var objebookchapter = _context.eBookChapter.SingleOrDefault(opt => opt.eBookChapterId == eBookChapter.eBookChapterId);
                objebookchapter.eBookChapterTitle = eBookChapter.eBookChapterTitle;
                objebookchapter.ChapterDisplayOrder = eBookChapter.ChapterDisplayOrder;
                objebookchapter.ChapterPdf = eBookChapter.ChapterPdf;
                objebookchapter.ChapterVideo = eBookChapter.ChapterVideo;
                objebookchapter.ChapterAudio = eBookChapter.ChapterAudio;

                _context.SaveChanges();
                return Ok(objebookchapter);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/eBookChapters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<eBookChapter>> PosteBookChapter(eBookChapter eBookChapter)
        {
            try
            {
                var objCheck = _context.eBookChapter.SingleOrDefault(opt => opt.eBookChapterId == eBookChapter.eBookChapterId);
                if (objCheck == null)
                {
                    eBookChapter.IsActive = 1;
                    if (ModelState.IsValid)
                    {
                        var obj = _ebookChapterRepo.Insert(eBookChapter);
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

        // DELETE: api/eBookChapters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteeBookChapter(int id)
        {
            try
            {
                var singlesubject = _ebookChapterRepo.Delete(id);
                return Ok(singlesubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool eBookChapterExists(int id)
        {
            return _context.eBookChapter.Any(e => e.eBookChapterId == id);
        }
    }
}
