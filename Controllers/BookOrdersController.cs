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
using AdminApi.ViewModels.BookOrder;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<BookOrder> _bookOrderRepo;

        public BookOrdersController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<BookOrder> bookOrderRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _bookOrderRepo = bookOrderRepo;
        }

        // GET: api/BookOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookOrderData>>> GetBookOrder()
        {
            var bookOrders = await (from bo in _context.BookOrder
                                    join sc in _context.Schools on bo.SchoolId equals sc.SchoolId
                                    join cls in _context.ClassMasters on bo.ClassId equals cls.ClassId
                                    select new BookOrderData
                                    {
                                        BookOrderId = bo.BookOrderId,
                                        BillTo = bo.BillTo,
                                        OrderDate = bo.OrderDate,
                                        Quantity = bo.Quantity,
                                        OrderNumber = bo.OrderNumber,
                                        OrderAmount=bo.OrderAmount,
                                        OrderStatus=bo.OrderStatus,
                                        ClassId = bo.ClassId,
                                        ClassName = cls.ClassName,
                                        SchoolId = bo.SchoolId,
                                        SchoolName = sc.SchoolName
                                    }).ToListAsync();

            var totalRecords = bookOrders.Count();
            return Ok(new { data = bookOrders, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/BookOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookOrderData>> GetBookOrder(int id)
        {
            try
            {
                var bookOrder = await (from bo in _context.BookOrder
                                       join sc in _context.Schools on bo.SchoolId equals sc.SchoolId
                                       join cls in _context.ClassMasters on bo.ClassId equals cls.ClassId
                                       where bo.BookOrderId == id
                                       select new BookOrderData
                                       {
                                           BookOrderId = bo.BookOrderId,
                                           BillTo = bo.BillTo,
                                           OrderDate = bo.OrderDate,
                                           Quantity = bo.Quantity,
                                           OrderNumber = bo.OrderNumber,
                                           OrderAmount = bo.OrderAmount,
                                           OrderStatus = bo.OrderStatus,
                                           ClassId = bo.ClassId,
                                           ClassName = cls.ClassName,
                                           SchoolId = bo.SchoolId,
                                           SchoolName = sc.SchoolName
                                       }).FirstOrDefaultAsync();
                return Ok(bookOrder);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/BookOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutBookOrder(BookOrder bookOrder)
        {
            try
            {
                var objAcademyYears = _context.BookOrder.SingleOrDefault(opt => opt.BookOrderId == bookOrder.BookOrderId);
                objAcademyYears.SchoolId = bookOrder.SchoolId;
                objAcademyYears.OrderDate = bookOrder.OrderDate;
                objAcademyYears.OrderNumber = bookOrder.OrderNumber;
                objAcademyYears.OrderStatus = bookOrder.OrderStatus;
                objAcademyYears.OrderAmount = bookOrder.OrderAmount;
                objAcademyYears.ClassId = bookOrder.ClassId;
                objAcademyYears.BillTo = bookOrder.BillTo;
                objAcademyYears.Quantity = bookOrder.Quantity;


                await _context.SaveChangesAsync();
                return Ok(objAcademyYears);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // POST: api/BookOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookOrder>> PostBookOrder(BookOrder bookOrder)
        {
            try
            {
                var objCheck = _context.BookOrder.SingleOrDefault(opt => opt.BookOrderId == bookOrder.BookOrderId);
                if (objCheck == null)
                {

                    if (ModelState.IsValid)
                    {
                        var obj = _bookOrderRepo.Insert(bookOrder);
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

        // DELETE: api/BookOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookOrder(int id)
        {
            try
            {
                var singleAcademicYear = _bookOrderRepo.Delete(id);
                return Ok(singleAcademicYear);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool BookOrderExists(int id)
        {
            return _context.BookOrder.Any(e => e.BookOrderId == id);
        }
    }
}
