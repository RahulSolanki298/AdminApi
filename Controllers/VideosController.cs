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
    public class VideosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
       
        private readonly ISqlRepository<Videos> _videosRepo;

        public VideosController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                             ISqlRepository<Videos> videosRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _videosRepo = videosRepo;
           
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videos>>> GetVideos()
        {
            var subsubjetlist = _videosRepo.SelectAllByClause(includeProperties: "VideoCategories");
            var totalRecords = subsubjetlist.Count();
            return Ok(new { data = subsubjetlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videos>> GetVideos(int id)
        {
            try
            {
                var singlesubsubject = _videosRepo.SelectById(id);
                return Ok(singlesubsubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutVideos(Videos videos)
        {
            try
            {
                var objsubsubject = _context.Videos.SingleOrDefault(opt => opt.VideoId == videos.VideoId);
                objsubsubject.VideoPath = videos.VideoPath;
                objsubsubject.VideoThumbnail = videos.VideoThumbnail;
                objsubsubject.VideoCategoryId = videos.VideoCategoryId;
                objsubsubject.VideoName = videos.VideoName;
                objsubsubject.IsActive = videos.IsActive;

                _context.SaveChanges();
                return Ok(objsubsubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/Videos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Videos>> PostVideos(Videos videos)
        {
            try
            {
                var objCheck = _context.Videos.SingleOrDefault(opt => opt.VideoId == videos.VideoId);
                if (objCheck == null)
                {
                    videos.IsActive = 1;
                    if (ModelState.IsValid)
                    {
                        var obj = _videosRepo.Insert(videos);
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

        // DELETE: api/Videos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteVideos(int id)
        {
            try
            {
                var singlesubject = _videosRepo.Delete(id);
                return Ok(singlesubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool VideosExists(int id)
        {
            return _context.Videos.Any(e => e.VideoId == id);
        }
    }
}
