using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminApi.Models;
using AdminApi.Models.School;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AdminApi.ViewModels;
using AdminApi.Models.User;
using Microsoft.Extensions.Configuration;
using AdminApi.Models.Helper;
using AdminApi.Helpers;

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
        SchoolPublicMethods schoolPublicMethods;
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
            model.IsActive = CustomAttributes.ValueTrue;
            Users principle = new Users
            {
                UserRoleId = setUserRole(CustomAttributes.Principle),
                FirstName = model.SchoolPrincipleFirstName,
                MiddleName = model.SchoolPrincipleMiddelName,
                LastName = model.SchoolPrincipleLastName,
                Mobile = model.SchoolPrinciplePhone,
                Password = DataEncript.ConvertToEncrypt(model.SchoolPrinciplePhone),
                UserName = model.SchoolPrinciplePhone,
                Email = model.SchoolPrincipleEmail,
                SchoolId = model.SchoolId
            };

            Users Owner = new Users
            {
                UserRoleId = setUserRole(CustomAttributes.Admin),
                FirstName = model.SchoolOwnerFirstName,
                MiddleName = model.SchoolOwnerMiddelName,
                LastName = model.SchoolOwnerLastName,
                Mobile = model.SchoolOwnerPhone,
                Password = DataEncript.ConvertToEncrypt(model.SchoolOwnerPhone),
                UserName = model.SchoolOwnerPhone,
                Email = model.SchoolOwnerEmail,
                SchoolId = model.SchoolId
            };
            Users coordinator = new Users
            {
                UserRoleId = setUserRole(CustomAttributes.Coordinator),
                FirstName = model.SchoolCoordinatorFirstName,
                MiddleName = model.SchoolCoordinatorMiddelName,
                LastName = model.SchoolCoordinatorLastName,
                Mobile = model.SchoolCoordinatorPhone,
                Password = DataEncript.ConvertToEncrypt(model.SchoolCoordinatorPhone),
                UserName = model.SchoolCoordinatorPhone,
                Email = model.SchoolCoordinatorEmail,
                SchoolId = model.SchoolId
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
                objCheckPrinciple.UserRoleId = setUserRole(CustomAttributes.Principle);
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
                Owner.IsActive = CustomAttributes.ActiveTrue;
                Owner.IsPasswordChange = CustomAttributes.ActiveFalse;
                var obj = _userRepo.Insert(Owner);
            }
            else if (objCheckOwner != null && model.SchoolId == 0)
            {
                return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
            }
            else
            {
                objCheckOwner.UserRoleId = setUserRole(CustomAttributes.Admin);
                objCheckOwner.FirstName = model.SchoolOwnerFirstName;
                objCheckOwner.MiddleName = model.SchoolOwnerMiddelName;
                objCheckOwner.LastName = model.SchoolOwnerLastName;
                objCheckOwner.Mobile = model.SchoolOwnerPhone;
                objCheckOwner.Password = DataEncript.ConvertToEncrypt(model.SchoolOwnerPhone);
                objCheckOwner.UserName = model.SchoolOwnerPhone;
                objCheckOwner.Email = model.SchoolOwnerEmail;
                var obj = _userRepo.Update(objCheckOwner);
            }

            var objCheckCoordinator = _context.Users.SingleOrDefault(opt => opt.UserName == coordinator.UserName);
            if (objCheckCoordinator == null)
            {
                coordinator.DateAdded = DateTime.Now;
                coordinator.IsActive = true;
                coordinator.IsPasswordChange = false;
                var obj = _userRepo.Insert(coordinator);
            }
            else if (objCheckCoordinator != null && model.SchoolId == 0)
            {
                return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
            }
            else
            {
                objCheckCoordinator.UserRoleId = setUserRole(CustomAttributes.Coordinator);
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
            var CoordinatorId = coordinator.UserId;

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
                result.IsActive = CustomAttributes.ValueTrue;
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
                    IsActive = CustomAttributes.ValueTrue,
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
                            IsActive = CustomAttributes.ValueTrue,
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
                    int AcademicYear = Convert.ToInt32(model.AcademicYear);
                    decimal objbookprice = Convert.ToDecimal(kvp.Value);

                    SchoolBookPrice schoolBookPrice = new SchoolBookPrice
                    {
                        SchoolId = schoolId,
                        AcademyYearId = AcademicYear,
                        ClassId = classId,
                        Price = objbookprice,
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
        public IActionResult DeleteSchool(int id)
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

        // Manage Role
        private int setUserRole(string RoleName)
        {
            return (from x in _context.UserRole
                    where x.RoleName == RoleName
                    select x.UserRoleId).FirstOrDefault();
        }
    }
}
