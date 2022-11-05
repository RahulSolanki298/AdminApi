using AdminApi.Models.Menu;
using AdminApi.Models.School;
using AdminApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq;
using AdminApi.ViewModels;
using AdminApi.Migrations;
using AdminApi.Helpers;
using AdminApi.Models.Helper;
using AdminApi.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin,Student")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISqlRepository<AppMenu> _menuRepo;
        private readonly ISqlRepository<MenuGroup> _menuGroupRepo;
        private readonly ISqlRepository<MenuGroupWiseMenuMapping> _menuGroupWiseMenuMappingRepo;
        private readonly ISqlRepository<AcademyYear> _academicYearRepo;
        private readonly ISqlRepository<eBook> _ebook;
        private readonly ISqlRepository<eBookChapter> _ebookChapter;
        private readonly ISqlRepository<Users> _userRepo;

        public StudentController(AppDbContext context,
                            IConfiguration config,
                            ISqlRepository<AppMenu> menuRepo,
                            ISqlRepository<MenuGroup> menuGroupRepo,
                            ISqlRepository<MenuGroupWiseMenuMapping> menuGroupWiseMenuMappingRepo,
                            ISqlRepository<AcademyYear> academicYearRepo, ISqlRepository<eBook> ebook,
                            ISqlRepository<eBookChapter> ebookChapter, ISqlRepository<Users> userRepo)
        {
            _context = context;
            _config = config;
            _menuRepo = menuRepo;
            _menuGroupRepo = menuGroupRepo;
            _menuGroupWiseMenuMappingRepo = menuGroupWiseMenuMappingRepo;
            _academicYearRepo = academicYearRepo;
            _ebook = ebook;
            _ebookChapter = ebookChapter;
            _userRepo = userRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {

            var singleStudent = await (from stud in _context.ParentStudent
                                 join studDT in _context.Users on stud.StudentId equals studDT.UserId
                                 join father in _context.Users on stud.FatherId equals father.UserId into fatherGroup from ftype in fatherGroup.DefaultIfEmpty()
                                 join mother in _context.Users on stud.MotherId equals mother.UserId into motherGroup from mtype in motherGroup.DefaultIfEmpty()
                                 join guard in _context.Users on stud.GuardianId equals guard.UserId into guardinGroup from gtype in guardinGroup.DefaultIfEmpty()
                                 join school in _context.Schools on stud.SchoolId equals school.SchoolId into schoolGroup from stype in schoolGroup.DefaultIfEmpty()
                                 join cls in _context.ClassMasters on studDT.ClassId equals cls.ClassId into classGroup from ctype in classGroup.DefaultIfEmpty()
                                 where stud.StudentId == id
                                 select new StudentModel
                                 {
                                     FirstName = studDT.FirstName,
                                     MiddleName = studDT.MiddleName,
                                     LastName = studDT.LastName,
                                     SchoolId = studDT.SchoolId,
                                     ClassId = studDT.ClassId,
                                     Mobile = studDT.Mobile,
                                     Email = studDT.Email,
                                     SchoolName = stype.SchoolName,
                                     ClassName = ctype.ClassName,
                                     DateOfBirth = studDT.DateOfBirth,
                                     FatherEmail = ftype.Email,
                                     FatherFirstName = ftype.FirstName,
                                     FatherMiddleName = ftype.MiddleName,
                                     FatherLastName = ftype.LastName,
                                     FatherMobile = ftype.Mobile,
                                     MotherEmail = mtype.Email,
                                     MotherFirstName = mtype.FirstName,
                                     MotherMiddleName = mtype.MiddleName,
                                     MotherLastName = mtype.LastName,
                                     MotherMobile = mtype.Mobile,
                                     GuardianEmail = gtype.Email,
                                     GuardianFirstName = gtype.FirstName,
                                     GuardianMiddleName = gtype.MiddleName,
                                     GuardianLastName = gtype.LastName,
                                     GuardianMobile = gtype.Mobile,
                                     UserName = studDT.UserName,
                                 }).FirstOrDefaultAsync();
            return Ok(singleStudent);
        }

        [HttpPost]
        public async Task<ActionResult<StudentModel>> CreateStudent(StudentModel model)
        {
            Users father = new Users
            {
                UserRoleId = 7,
                IsFather = 1,
                FirstName = model.FatherFirstName,
                MiddleName = model.FatherMiddleName,
                LastName = model.FatherLastName,
                Mobile = model.FatherMobile,
                Password = DataEncript.ConvertToEncrypt(model.FatherMobile),
                UserName = model.FatherMobile,
                Email = model.FatherEmail
                //SchoolId = school.SchoolId
            };

            Users mother = new Users
            {

                UserRoleId = 7,
                IsMother = 1,
                FirstName = model.MotherFirstName,
                MiddleName = model.MotherMiddleName,
                LastName = model.MotherLastName,
                Mobile = model.MotherMobile,
                Password = DataEncript.ConvertToEncrypt(model.MotherMobile),
                UserName = model.MotherMobile,
                Email = model.MotherEmail
                //SchoolId = school.SchoolId
            };
            Users guardian = new Users
            {
                UserRoleId = 7,
                FirstName = model.GuardianFirstName,
                MiddleName = model.GuardianMiddleName,
                LastName = model.GuardianLastName,
                Mobile = model.GuardianMobile,
                Password = DataEncript.ConvertToEncrypt(model.GuardianMobile),
                UserName = model.GuardianMobile,
                Email = model.GuardianEmail
                //SchoolId = school.SchoolId
            };

            var objCheckFather = _context.Users.SingleOrDefault(opt => opt.UserName == father.UserName);
            if (objCheckFather == null && model.StudentId == 0)
            {
                father.DateAdded = DateTime.Now;
                father.IsActive = true;
                father.IsPasswordChange = false;
                var obj = _userRepo.Insert(father);
            }
            else if (objCheckFather != null && model.StudentId == 0)
            {
                return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
            }
            else
            {
                var objFatherData = _context.Users.SingleOrDefault(opt => opt.UserId == father.UserId);
                objFatherData.UserRoleId = 3;
                objFatherData.FirstName = model.FirstName;
                objFatherData.MiddleName = model.MiddleName;
                objFatherData.LastName = model.LastName;
                objFatherData.Mobile = model.Mobile;
                objFatherData.Password = DataEncript.ConvertToEncrypt(model.Mobile);
                objFatherData.UserName = model.UserName;
                objFatherData.Email = model.Email;
                var obj = _userRepo.Update(objFatherData);
            }

            var objCheckMother = _context.Users.SingleOrDefault(opt => opt.UserName == mother.UserName);
            if (objCheckMother == null && model.StudentId == 0)
            {
                mother.DateAdded = DateTime.Now;
                mother.IsActive = true;
                mother.IsPasswordChange = false;
                var obj = _userRepo.Insert(mother);
            }
            else if (objCheckMother != null && model.SchoolId == 0)
            {
                return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
            }
            else
            {
                objCheckMother = _context.Users.SingleOrDefault(opt => opt.UserId == mother.UserId);
                objCheckMother.UserRoleId = 1;
                objCheckMother.FirstName = model.FirstName;
                objCheckMother.MiddleName = model.MiddleName;
                objCheckMother.LastName = model.LastName;
                objCheckMother.Mobile = model.Mobile;
                objCheckMother.Password = DataEncript.ConvertToEncrypt(model.Mobile);
                objCheckMother.UserName = model.Mobile;
                objCheckMother.Email = model.Email;
                var obj = _userRepo.Update(objCheckMother);
            }

            var objCheckGuard = _context.Users.SingleOrDefault(opt => opt.UserName == guardian.UserName);
            if (objCheckGuard == null && model.StudentId == 0)
            {
                guardian.DateAdded = DateTime.Now;
                guardian.IsActive = true;
                guardian.IsPasswordChange = false;
                var obj = _userRepo.Insert(guardian);
            }
            else if (objCheckGuard != null && model.SchoolId == 0)
            {
                return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
            }
            else
            {
                objCheckGuard = _context.Users.SingleOrDefault(opt => opt.UserId == guardian.UserId);
                objCheckGuard.UserRoleId = 7;
                objCheckGuard.FirstName = model.FirstName;
                objCheckGuard.MiddleName = model.MiddleName;
                objCheckGuard.LastName = model.LastName;
                objCheckGuard.Mobile = model.Mobile;
                objCheckGuard.Password = DataEncript.ConvertToEncrypt(model.Mobile);
                objCheckGuard.UserName = model.Mobile;
                objCheckGuard.Email = model.Email;
                var obj = _userRepo.Update(objCheckGuard);
            }

            var FatherId = father.UserId;
            var MotherId = mother.UserId;
            var Guardian = guardian.UserId;

            if (model.StudentId > 0)
            {
                var result = _context.Users.Where(x => x.UserId == model.StudentId).FirstOrDefault();
                result.FirstName = model.FirstName;
                result.MiddleName = model.MiddleName;
                result.LastName = model.LastName;
                result.UserName = model.UserName;
                result.Mobile = model.Mobile;
                result.Email = model.Email;
                result.IsStudent = 1;
                result.DateOfBirth = model.DateOfBirth;
                result.UserRoleId = 6;
                result.DateofAdmission = DateTime.Now;
                result.ClassId = model.ClassId;
                result.IsActive = true;
                var obj = _userRepo.Update(result);
                return Ok(obj);
            }
            else
            {
                var student = new Users
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    UserName = model.Mobile,
                    Mobile = model.Mobile,
                    Password = DataEncript.ConvertToEncrypt(model.Mobile),
                    Email = model.Email,
                    IsStudent = 1,
                    DateAdded = DateTime.Now,
                    DateOfBirth = model.DateOfBirth,
                    UserRoleId = 6,
                    DateofAdmission = DateTime.Now,
                    ClassId = model.ClassId,
                    IsActive = true,
                };
                try
                {
                    var obj = _userRepo.Insert(student);
                    return Ok(obj);
                }
                catch (Exception ex) { throw; }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClassBooks(int id)
        {

            var ebooklist = _ebook.SelectAllByClause(p => p.ClassMasterId == id).OrderBy(s => s.eBookDisplayOrder);
            var totalebook = ebooklist.Count();
            return Ok(new { data = ebooklist, recordsTotal = totalebook, recordsFiltered = totalebook });
        }


        [HttpGet("{id}")]
        public IActionResult GetClassBookChapters(int id)
        {

            var ebookchapterlist = _ebookChapter.SelectAllByClause(p => p.eBookId == id, includeProperties: "eBook").OrderBy(s => s.ChapterDisplayOrder);
            var totalebookchapter = ebookchapterlist.Count();
            return Ok(new { data = ebookchapterlist, recordsTotal = totalebookchapter, recordsFiltered = totalebookchapter });
        }
    }
}
