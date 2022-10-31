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
    public class eBooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<eBook> _ebookRepo;

        public eBooksController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<eBook> ebookRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _ebookRepo = ebookRepo;
        }

        // GET: api/eBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<eBook>>> GeteBook()
        {
            var ebooklist = _ebookRepo.SelectAllByClause(includeProperties: "Subject,TeachingMedium,ClassMaster");
            var totalRecords = ebooklist.Count();
            return Ok(new { data = ebooklist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/eBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<eBook>> GeteBook(int id)
        {
            try
            {
                var singleebook = _ebookRepo.SelectById(id);
                return Ok(singleebook);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/eBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PuteBook(eBook eBook)
        {
            try
            {
                var objClassMaster = _context.eBook.SingleOrDefault(opt => opt.eBookId == eBook.eBookId);
                objClassMaster.eBookTitle = eBook.eBookTitle;
                objClassMaster.eBookDisplayOrder = eBook.eBookDisplayOrder;
                objClassMaster.eBookCoverPdf = eBook.eBookCoverPdf;
                objClassMaster.eBookCoverAudio = eBook.eBookCoverAudio;
                objClassMaster.eBookCoverVideo = eBook.eBookCoverVideo;
                objClassMaster.ClassMasterId = eBook.ClassMasterId;
                objClassMaster.SubjectId = eBook.SubjectId;
                objClassMaster.TeachingMediumId = eBook.TeachingMediumId;
                objClassMaster.SubSubjectId = eBook.SubSubjectId;
                objClassMaster.IsActive = eBook.IsActive;

                _context.SaveChanges();
                return Ok(objClassMaster);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/eBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<eBook>> PosteBook(eBook eBook)
        {
            try
            {
                var objCheck = _context.eBook.SingleOrDefault(opt => opt.eBookId == eBook.eBookId);
                if (objCheck == null)
                {
                    eBook.IsActive = 1;
                    if (ModelState.IsValid)
                    {
                        var obj = _ebookRepo.Insert(eBook);
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

        // DELETE: api/eBooks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteeBook(int id)
        {
            try
            {
                var singlesubject = _ebookRepo.Delete(id);
                return Ok(singlesubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool eBookExists(int id)
        {
            return _context.eBook.Any(e => e.eBookId == id);
        }
    }
}
