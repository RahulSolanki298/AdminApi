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
using AdminApi.ViewModels;
using AdminApi.Migrations;
using AdminApi.Models.User;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.Helper;
using AdminApi.ViewModels.User;
using AdminApi.Helpers;
using System.Reflection;

namespace AdminApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SchoolsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ISqlRepository<Users> _userRepo;
        private readonly ISqlRepository<UserRole> _userRoleRepo;
        private readonly ISqlRepository<LogHistory> _logHistoryRepo;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<School> _schoolRepo;

        public SchoolsController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<Users> userRepo,
                                ISqlRepository<UserRole> userRoleRepo,
                                ISqlRepository<LogHistory> logHistoryRepo,
                                ISqlRepository<School> schoolRepo)
        {
            _context = context;
            _config = config;
            _userRepo = userRepo;
            _userRoleRepo = userRoleRepo;
            _logHistoryRepo = logHistoryRepo;
            _schoolRepo = schoolRepo;
        }

        // GET: api/Schools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            var subsubjetlist = _schoolRepo.SelectAllByClause();// (includeProperties: "VideoCategories");
            var totalRecords = subsubjetlist.Count();
            return Ok(new { data = subsubjetlist, recordsTotal = totalRecords, recordsFiltered = totalRecords });
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolModel>> GetSchool(int id)
        {
            try
            {
                var schoolDetails = (from _school in _context.Schools
                                     join _principle in _context.Users on _school.SchoolPrincipleId equals _principle.UserId
                                     join _owner in _context.Users on _school.SchoolOwnerId equals _owner.UserId
                                     join _coordi in _context.Users on _school.SchoolCoordinatorId equals _coordi.UserId
                                     where _school.SchoolId == id
                                     select new SchoolModel
                                     {
                                         SchoolId = id,
                                         AcademicEndDate = _school.AcademicEndDate,
                                         AcademicStartDate = _school.AcademicStartDate,
                                         AcademicYear = _school.AcademicYear,
                                         EstablishmentDate = _school.EstablishmentDate,
                                         GeoLocation = _school.GeoLocation,
                                         SchoolCity = _school.SchoolCity,
                                         SchoolAddress = _school.SchoolAddress,
                                         SchoolCode = _school.SchoolCode,
                                         IsActive = _school.IsActive,
                                         SchoolEmail = _school.SchoolEmail,
                                         DashboardPicPath = _school.DashboardPicPath,
                                         SchoolGSTNo = _school.SchoolGSTNo,
                                         SchoolName = _school.SchoolName,
                                         SchoolLogo1Path = _school.SchoolLogo1Path,
                                         SchoolLogo2Path = _school.SchoolLogo2Path,
                                         SchoolPAN = _school.SchoolPAN,
                                         SchoolPhone = _school.SchoolPhone,
                                         SchoolState = _school.SchoolPhone,
                                         SchoolPinCode = _school.SchoolPinCode,
                                         SchoolTrustName = _school.SchoolTrustName,
                                         SchoolWebsite = _school.SchoolWebsite,
                                         SchoolOwnerEmail = _owner.Email,
                                         SchoolOwnerFirstName = _owner.FirstName,
                                         SchoolOwnerMiddelName = _owner.MiddleName,
                                         SchoolOwnerLastName = _owner.LastName,
                                         SchoolOwnerPhone = _owner.Mobile,
                                         SchoolCoordinatorFirstName = _coordi.FirstName,
                                         SchoolCoordinatorMiddelName = _coordi.MiddleName,
                                         SchoolCoordinatorLastName = _coordi.LastName,
                                         SchoolCoordinatorEmail = _coordi.Email,
                                         SchoolCoordinatorPhone = _coordi.Mobile,
                                         SchoolPrincipleFirstName = _principle.FirstName,
                                         SchoolPrincipleMiddelName = _principle.MiddleName,
                                         SchoolPrincipleLastName = _principle.LastName,
                                         SchoolPrincipleEmail = _coordi.Email,
                                         SchoolPrinciplePhone = _coordi.Mobile,
                                     }).FirstOrDefault();
                return Ok(schoolDetails);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutSchool(School school)
        {
            try
            {
                var objsubsubject = _context.Schools.SingleOrDefault(opt => opt.SchoolId == school.SchoolId);
                objsubsubject.SchoolName = school.SchoolName;
                objsubsubject.SchoolAddress = school.SchoolAddress;
                objsubsubject.SchoolCity = school.SchoolCity;
                objsubsubject.AcademicYear = school.AcademicYear;
                objsubsubject.IsActive = school.IsActive;

                _context.SaveChanges();
                return Ok(objsubsubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<SchoolModel>> CreateSchool(SchoolModel model)
        {
            model.IsActive = 1;

            Users principle = new Users
            {
                UserRoleId = 3,
                FirstName = model.SchoolPrincipleFirstName,
                MiddleName = model.SchoolPrincipleMiddelName,
                LastName = model.SchoolPrincipleLastName,
                Mobile = model.SchoolPrinciplePhone,
                Password = DataEncript.ConvertToEncrypt(model.SchoolPrinciplePhone),
                UserName = model.SchoolPrinciplePhone,
                Email = model.SchoolPrincipleEmail
                //SchoolId = school.SchoolId
            };

            Users Owner = new Users
            {

                UserRoleId = 1,
                FirstName = model.SchoolOwnerFirstName,
                MiddleName = model.SchoolOwnerMiddelName,
                LastName = model.SchoolOwnerLastName,
                Mobile = model.SchoolOwnerPhone,
                Password = DataEncript.ConvertToEncrypt(model.SchoolOwnerPhone),
                UserName = model.SchoolOwnerPhone,
                Email = model.SchoolOwnerEmail
                //SchoolId = school.SchoolId
            };
            Users Coordinator = new Users
            {
                UserRoleId = 14,
                FirstName = model.SchoolCoordinatorFirstName,
                MiddleName = model.SchoolCoordinatorMiddelName,
                LastName = model.SchoolCoordinatorLastName,
                Mobile = model.SchoolCoordinatorPhone,
                Password = DataEncript.ConvertToEncrypt(model.SchoolCoordinatorPhone),
                UserName = model.SchoolCoordinatorPhone,
                Email = model.SchoolCoordinatorEmail
                //SchoolId = school.SchoolId
            };

            var objCheckPrinciple = _context.Users.SingleOrDefault(opt => opt.UserName == principle.UserName);
            if (objCheckPrinciple == null)
            {
                principle.DateAdded = DateTime.Now;
                principle.IsActive = true;
                principle.IsPasswordChange = false;
                var obj = _userRepo.Insert(principle);
            }
            else if (objCheckPrinciple != null && model.SchoolId == 0)
            {
                return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
            }
            else
            {
                objCheckPrinciple.UserRoleId = 3;
                objCheckPrinciple.FirstName = model.SchoolPrincipleFirstName;
                objCheckPrinciple.MiddleName = model.SchoolPrincipleMiddelName;
                objCheckPrinciple.LastName = model.SchoolPrincipleLastName;
                objCheckPrinciple.Mobile = model.SchoolPrinciplePhone;
                objCheckPrinciple.Password = DataEncript.ConvertToEncrypt(model.SchoolPrinciplePhone);
                objCheckPrinciple.UserName = model.SchoolPrinciplePhone;
                objCheckPrinciple.Email = model.SchoolPrincipleEmail;
                var obj = _userRepo.Update(objCheckPrinciple);
            }

            var objCheckOwner = _context.Users.SingleOrDefault(opt => opt.UserName == Owner.UserName);
            if (objCheckOwner == null)
            {
                Owner.DateAdded = DateTime.Now;
                Owner.IsActive = true;
                Owner.IsPasswordChange = false;
                var obj = _userRepo.Insert(Owner);
            }
            else if (objCheckOwner != null && model.SchoolId == 0)
            {
                return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
            }
            else
            {
                objCheckOwner.UserRoleId = 1;
                objCheckOwner.FirstName = model.SchoolOwnerFirstName;
                objCheckOwner.MiddleName = model.SchoolOwnerMiddelName;
                objCheckOwner.LastName = model.SchoolOwnerLastName;
                objCheckOwner.Mobile = model.SchoolOwnerPhone;
                objCheckOwner.Password = DataEncript.ConvertToEncrypt(model.SchoolOwnerPhone);
                objCheckOwner.UserName = model.SchoolOwnerPhone;
                objCheckOwner.Email = model.SchoolOwnerEmail;
                var obj = _userRepo.Update(objCheckOwner);
            }

            var objCheckCoordinator = _context.Users.SingleOrDefault(opt => opt.UserName == Coordinator.UserName);
            if (objCheckCoordinator == null)
            {
                Coordinator.DateAdded = DateTime.Now;
                Coordinator.IsActive = true;
                Coordinator.IsPasswordChange = false;
                var obj = _userRepo.Insert(Coordinator);
            }
            else if (objCheckCoordinator != null && model.SchoolId == 0)
            {
                return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
            }
            else
            {
                objCheckCoordinator.UserRoleId = 14;
                objCheckCoordinator.FirstName = model.SchoolCoordinatorFirstName;
                objCheckCoordinator.MiddleName = model.SchoolCoordinatorMiddelName;
                objCheckCoordinator.LastName = model.SchoolCoordinatorLastName;
                objCheckCoordinator.Mobile = model.SchoolCoordinatorPhone;
                objCheckCoordinator.Password = DataEncript.ConvertToEncrypt(model.SchoolCoordinatorPhone);
                objCheckCoordinator.UserName = model.SchoolCoordinatorPhone;
                objCheckCoordinator.Email = model.SchoolCoordinatorEmail;
                var obj = _userRepo.Update(objCheckCoordinator);
            }

            var OwnerId = Owner.UserId;
            var principleId = principle.UserId;
            var CoordinatorId = Coordinator.UserId;

            if (model.SchoolId > 0)
            {
                var result = _context.Schools.Where(x => x.SchoolId == model.SchoolId).FirstOrDefault();
                result.SchoolName = model.SchoolName;
                result.SchoolAddress = model.SchoolAddress;
                result.SchoolCity = model.SchoolCity;
                result.SchoolState = model.SchoolState;
                result.SchoolPinCode = model.SchoolPinCode;
                result.SchoolPhone = model.SchoolPhone;
                result.AcademicYear = model.AcademicYear;
                result.SchoolCode = model.SchoolCode;
                result.EstablishmentDate = model.EstablishmentDate;
                result.AcademicStartDate = model.AcademicStartDate;
                result.AcademicEndDate = model.AcademicEndDate;
                result.GeoLocation = model.GeoLocation;
                result.SchoolOwnerId = OwnerId;
                result.SchoolPrincipleId = principleId;
                result.SchoolCoordinatorId = CoordinatorId;
                result.SchoolLogo1Path = model.SchoolLogo1Path;
                result.SchoolLogo2Path = model.SchoolLogo2Path;
                result.DashboardPicPath = model.DashboardPicPath;
                result.SchoolEmail = model.SchoolEmail;
                result.SchoolWebsite = model.SchoolWebsite;
                result.SchoolTrustName = model.SchoolTrustName;
                result.SchoolPAN = model.SchoolPAN;
                result.SchoolGSTNo = model.SchoolGSTNo;
                result.IsActive = 1;
                await _context.SaveChangesAsync();
            }
            else
            {
                School school = new School
                {
                    SchoolName = model.SchoolName,
                    SchoolAddress = model.SchoolAddress,
                    SchoolCity = model.SchoolCity,
                    SchoolState = model.SchoolState,
                    SchoolPinCode = model.SchoolPinCode,
                    SchoolPhone = model.SchoolPhone,
                    AcademicYear = model.AcademicYear,
                    SchoolCode = model.SchoolCode,
                    EstablishmentDate = model.EstablishmentDate,
                    AcademicStartDate = model.AcademicStartDate,
                    AcademicEndDate = model.AcademicEndDate,
                    GeoLocation = model.GeoLocation,
                    SchoolOwnerId = OwnerId,
                    SchoolPrincipleId = principleId,
                    SchoolCoordinatorId = CoordinatorId,
                    SchoolLogo1Path = model.SchoolLogo1Path,
                    SchoolLogo2Path = model.SchoolLogo2Path,
                    DashboardPicPath = model.DashboardPicPath,
                    SchoolEmail = model.SchoolEmail,
                    SchoolWebsite = model.SchoolWebsite,
                    SchoolTrustName = model.SchoolTrustName,
                    SchoolPAN = model.SchoolPAN,
                    SchoolGSTNo = model.SchoolGSTNo,

                    IsActive = 1,
                };

                var objschool = _context.Schools.Add(school);
                await _context.SaveChangesAsync();

                IDictionary<int, int> divisions = model.ClassDivision; //new Dictionary<int, int>();
                IDictionary<int, decimal> bookprice = model.BookPrice;// new Dictionary<int, decimal>();

                foreach (KeyValuePair<int, int> kvp in divisions)
                {
                    // Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

                    var schoolId = school.SchoolId;
                    int classId = kvp.Key;
                    int IsActive = 1;
                    int AcademicYear = Convert.ToInt32(model.AcademicYear);
                    int divisioncnt = Convert.ToInt32(kvp.Value);
                    // decimal objbookprice = Convert.ToDecimal(kvp.Value);

                    for (int j = 1; j <= divisioncnt; j++)
                    {
                        int divnumber = 65;
                        SchoolClassDivision schoolClassDivision = new SchoolClassDivision
                        {
                            SchoolId = school.SchoolId,
                            ClassId = classId,
                            IsActive = 1,
                            AcademyYearId = AcademicYear,
                            Division = ((char)divnumber).ToString()

                        };
                        _context.schoolClassDivisions.Add(schoolClassDivision);
                        await _context.SaveChangesAsync();

                        divnumber++;
                    }

                }

                foreach (KeyValuePair<int, decimal> kvp in bookprice)
                {
                    // Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

                    var schoolId = school.SchoolId;
                    int classId = kvp.Key;
                    int IsActive = 1;
                    int AcademicYear = Convert.ToInt32(model.AcademicYear);
                    //int divisioncnt = Convert.ToInt32(Form["TotalDivisions_" + i]);
                    decimal objbookprice = Convert.ToDecimal(kvp.Value);

                    SchoolBookPrice schoolBookPrice = new SchoolBookPrice
                    {
                        SchoolId = schoolId,
                        AcademyYearId = AcademicYear,
                        ClassId = classId,
                        Price = objbookprice
                    };

                    _context.SchoolBookPrice.Add(schoolBookPrice);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(model);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetSchool", new { id = model.SchoolId }, model);
        }

        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchool", new { id = school.SchoolId }, school);
        }

        // DELETE: api/Schools/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            try
            {
                var singlesubject = _schoolRepo.Delete(id);
                return Ok(singlesubject);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        private bool SchoolExists(int id)
        {
            return _context.Schools.Any(e => e.SchoolId == id);
        }
    }
}
