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
    public class VideoCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
       
        private readonly ISqlRepository<VideoCategory> _videoCategoryRepo;
       

        public VideoCategoriesController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<VideoCategory> videoCategoryRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _videoCategoryRepo = videoCategoryRepo;
           
        }

        // GET: api/VideoCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoCategory>>> GetVideoCategories()
        {
            var subsubjetlist = _videoCategoryRepo.SelectAllByClause();
            var totalRecords = subsubjetlist.Count();
            return Ok(new { data = subsubjetlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/VideoCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoCategory>> GetVideoCategory(int id)
        {
            try
            {
                var singlesubsubject = _videoCategoryRepo.SelectById(id);
                return Ok(singlesubsubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/VideoCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutVideoCategory(VideoCategory videoCategory)
        {
            try
            {
                var objsubsubject = _context.VideoCategories.SingleOrDefault(opt => opt.VideoCategoryId == videoCategory.VideoCategoryId);
                objsubsubject.VideoCategoryName = videoCategory.VideoCategoryName;
                objsubsubject.IsActive = videoCategory.IsActive;

                _context.SaveChanges();
                return Ok(objsubsubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/VideoCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VideoCategory>> PostVideoCategory(VideoCategory videoCategory)
        {
            try
            {
                var objCheck = _context.VideoCategories.SingleOrDefault(opt => opt.VideoCategoryId == videoCategory.VideoCategoryId);
                if (objCheck == null)
                {
                    videoCategory.IsActive = 1;
                    if (ModelState.IsValid)
                    {
                        var obj = _videoCategoryRepo.Insert(videoCategory);
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

        // DELETE: api/VideoCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteVideoCategory(int id)
        {
            try
            {
                var singlesubject = _videoCategoryRepo.Delete(id);
                return Ok(singlesubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool VideoCategoryExists(int id)
        {
            return _context.VideoCategories.Any(e => e.VideoCategoryId == id);
        }
    }
}
