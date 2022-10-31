﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdminApi.Helpers;
using AdminApi.Models;
using AdminApi.Models.Helper;
using AdminApi.Models.User;
using AdminApi.ViewModels;
using AdminApi.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<Users> _userRepo;
        private readonly ISqlRepository<UserRole> _userRoleRepo;
        private readonly ISqlRepository<LogHistory> _logHistoryRepo;


        public UsersController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<Users> userRepo,
                                ISqlRepository<UserRole> userRoleRepo,
                                ISqlRepository<LogHistory> logHistoryRepo)
        {
            _config = config;
            _context = context;
            _userRepo = userRepo;
            _userRoleRepo = userRoleRepo;
            _logHistoryRepo = logHistoryRepo;
        }


        ///<summary>
        ///Get Log in Detail
        ///</summary>
        [AllowAnonymous]
        [HttpGet("{studentid}/{choice1}/{choice2}")]
        public ActionResult GetStudentLoginInfo(int StudentId, int choice1, int choice2)
        {
            try
            {
                var user = (from s in _context.StudentPassword
                            join u in _context.Users on s.StudentId equals u.UserId
                            join r in _context.UserRole on u.UserRoleId equals r.UserRoleId
                            where s.IsActive.Equals(true) && s.ChoiceId1 == choice1 && s.ChoiceId2 == choice2
                            select new { u.UserId, r.UserRoleId, r.RoleName, u.FirstName, u.MiddleName, u.LastName, u.Mobile, u.Email, u.ImagePath, u.ClassId, u.SchoolId, u.FirstTimeLogin, u.IsPasswordChange }).FirstOrDefault();
                /* var user1  = (from u in _context.Users
                             join r in _context.UserRole on u.UserRoleId
                 equals r.UserRoleId
                             where u.IsActive.Equals(true) && u.UserName.Equals(username) && u.Password.Equals(password)
                             select new { u.UserId, r.UserRoleId, r.RoleName, u.FirstName, u.MiddleName, u.LastName, u.Mobile, u.Email, u.ImagePath }).FirstOrDefault();*/
                if (user != null)
                {
                    UserInfo userInfo = new UserInfo { UserId = user.UserId, UserRoleId = user.UserRoleId, RoleName = user.RoleName, FirstName = user.FirstName, MiddleName = user.MiddleName, LastName = user.LastName, Mobile = user.Mobile, Email = user.Email, ImagePath = user.ImagePath, ClassId = user.ClassId, SchoolId = Convert.ToInt32(user.SchoolId), FirstTimeLogin = user.FirstTimeLogin, IsPasswordChange = user.IsPasswordChange };
                    var tokenString = GenerateJwtToken(userInfo);
                    return Ok(new Response { token = tokenString, Obj = userInfo });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Log in Detail
        ///</summary>
        [AllowAnonymous]
        [HttpGet("{username}/{password}")]
        public ActionResult GetLoginInfo(string username, string password)
        {
            try
            {
                var user = (from u in _context.Users
                            join r in _context.UserRole on u.UserRoleId
                equals r.UserRoleId
                            where u.IsActive.Equals(true) && u.UserName.Equals(username) // && u.Password.Equals(password)
                            select new { u.UserId, u.Password, r.UserRoleId, r.RoleName, u.FirstName, u.MiddleName, u.LastName, u.Mobile, u.Email, u.ImagePath, u.SchoolId, u.FirstTimeLogin, u.IsPasswordChange }).FirstOrDefault();

                if (user == null) { return Ok(new Confirmation { Status = "fail", ResponseMsg = "Login fail" }); }

                var userPwd = DataEncript.ConvertToDecrypt(user.Password);

                if (userPwd == password)
                {
                    UserInfo userInfo = new UserInfo { UserId = user.UserId, UserRoleId = user.UserRoleId, RoleName = user.RoleName, FirstName = user.FirstName, MiddleName = user.MiddleName, LastName = user.LastName, Mobile = user.Mobile, Email = user.Email, ImagePath = user.ImagePath, SchoolId = user.SchoolId, FirstTimeLogin = user.FirstTimeLogin, IsPasswordChange = user.IsPasswordChange };
                    var tokenString = GenerateJwtToken(userInfo);
                    return Ok(new Response { token = tokenString, Obj = userInfo });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Create Log History after login
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult CreateLoginHistory(LogHistory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = _logHistoryRepo.Insert(model);
                    return Ok(obj);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Update Login History
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{logCode}")]
        public ActionResult UpdateLoginHistory(string logCode)
        {
            try
            {
                var objLogHistory = _context.LogHistory.SingleOrDefault(opt => opt.LogCode == logCode);
                objLogHistory.LogOutTime = DateTime.Now;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get date wise Login summary
        ///</summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetLogInSummaryByDate(int id)
        {
            try
            {
                var objUser = _context.Users.Where(e => e.UserId == id).FirstOrDefault();
                if (objUser.UserRoleId == 1)
                {
                    var list = _context.LogHistory.GroupBy(e => e.LogInTime.Date.ToString()).OrderByDescending(e => e.Key).Take(10)
                    .Select(e => new { e.Key, Count = e.Count() });
                    var userList = list.Select(s => new UserLog { Date = s.Key, Count = s.Count });
                    return Ok(userList);
                }
                else
                {
                    var list = _context.LogHistory.Where(e => e.UserId == id).GroupBy(e => e.LogInTime.Date.ToString()).OrderByDescending(e => e.Key).Take(10)
                    .Select(e => new { e.Key, Count = e.Count() });
                    var userList = list.Select(s => new UserLog { Date = s.Key, Count = s.Count });
                    return Ok(userList);
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get month wise Login summary
        ///</summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetLogInSummaryByMonth(int id)
        {
            try
            {
                var objUser = _context.Users.Where(e => e.UserId == id).FirstOrDefault();
                if (objUser.UserRoleId == 1)
                {
                    var list = _context.LogHistory.GroupBy(e => e.LogInTime.Month)
                        .Select(e => new { e.Key, Count = e.Count() });
                    var userList = list.Select(s => new UserLog { Month = s.Key, Count = s.Count });
                    return Ok(userList);
                }
                else
                {
                    var list = _context.LogHistory.Where(e => e.UserId == id).GroupBy(e => e.LogInTime.Month)
                        .Select(e => new { e.Key, Count = e.Count() });
                    var userList = list.Select(s => new UserLog { Month = s.Key, Count = s.Count });
                    return Ok(userList);
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get month wise Login summary
        ///</summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetLogInSummaryByYear(int id)
        {
            try
            {
                var objUser = _context.Users.Where(e => e.UserId == id).FirstOrDefault();
                if (objUser.UserRoleId == 1)
                {
                    var list = _context.LogHistory.GroupBy(e => e.LogInTime.Year)
                        .Select(e => new { e.Key, Count = e.Count() });
                    var userList = list.Select(s => new UserLog { Year = s.Key, Count = s.Count });
                    return Ok(userList);
                }
                else
                {
                    var list = _context.LogHistory.Where(e => e.UserId == id).GroupBy(e => e.LogInTime.Year)
                        .Select(e => new { e.Key, Count = e.Count() });
                    var userList = list.Select(s => new UserLog { Year = s.Key, Count = s.Count });
                    return Ok(userList);
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Role wise User Count
        ///</summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetRoleWiseUser()
        {
            try
            {
                var list = _context.Users.Join(_context.UserRole,
                        user => user.UserRoleId,
                        role => role.UserRoleId,
                        (user, role) => new
                        {
                            UserId = user.UserId,
                            RoleName = role.RoleName
                        }).GroupBy(e => e.RoleName)
                        .Select(e => new { e.Key, Count = e.Count() });

                var userList = list.Select(s => new UserLog { RoleName = s.Key, Count = s.Count });
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Role List
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public ActionResult GetUserRoleList()
        {
            try
            {
                var list = (from r in _context.UserRole
                            join m in _context.MenuGroup on
                r.MenuGroupId equals m.MenuGroupID
                            select new { r.UserRoleId, r.RoleName, r.RoleDesc, m.MenuGroupName });

                var roleInfoList = list.Select(s => new RoleInfo { UserRoleId = s.UserRoleId, RoleName = s.RoleName, RoleDesc = s.RoleDesc, MenuGroupName = s.MenuGroupName });

                int totalRecords = roleInfoList.Count();
                return Ok(new { data = roleInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Role List
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{rolename}")]
        public ActionResult GetUserRoleListByName(string rolename)
        {
            try
            {
                var list = (from r in _context.UserRole
                            join m in _context.MenuGroup on
                r.MenuGroupId equals m.MenuGroupID
                            where r.RoleName.ToLower() == rolename
                            select new { r.UserRoleId, r.RoleName, r.RoleDesc, m.MenuGroupName });

                var roleInfoList = list.Select(s => new RoleInfo { UserRoleId = s.UserRoleId, RoleName = s.RoleName, RoleDesc = s.RoleDesc, MenuGroupName = s.MenuGroupName });

                int totalRecords = roleInfoList.Count();
                return Ok(new { data = roleInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get Single Role by ID
        ///</summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult GetSingleRole(int id)
        {
            try
            {
                var singleRole = _userRoleRepo.SelectById(id);
                return Ok(singleRole);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Delete Single Role by ID
        ///</summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult DeleteSingleRole(int id)
        {
            try
            {
                var singleRole = _userRoleRepo.Delete(id);
                return Ok(singleRole);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Create User Role
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult CreateUserRole(UserRole model)
        {
            try
            {
                var objCheck = _context.UserRole.SingleOrDefault(opt => opt.RoleName == model.RoleName);
                if (objCheck == null)
                {
                    model.DateAdded = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        var obj = _userRoleRepo.Insert(model);
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

        ///<summary>
        ///Update User Role
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult UpdateUserRole(UserRole model)
        {
            try
            {
                var objUserRole = _context.UserRole.SingleOrDefault(opt => opt.UserRoleId == model.UserRoleId);
                objUserRole.RoleName = model.RoleName;
                objUserRole.RoleDesc = model.RoleDesc;
                objUserRole.MenuGroupId = model.MenuGroupId;
                objUserRole.LastUpdatedBy = model.LastUpdatedBy;
                objUserRole.LastUpdatedDate = DateTime.Now;
                _context.SaveChanges();
                return Ok(objUserRole);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get User List
        ///</summary>
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult GetUserList()
        {
            try
            {
                var list = (from u in _context.Users
                            join r in _context.UserRole on
                u.UserRoleId equals r.UserRoleId
                            select new { u.UserId, u.UserRoleId, u.FirstName, u.MiddleName, u.LastName, r.RoleName, u.Mobile, u.Email, u.DateOfBirth, u.UserName });

                var userInfoList = list.Select(s => new UserInfo
                { UserId = s.UserId, UserRoleId = s.UserRoleId, RoleName = s.RoleName, FirstName = s.FirstName, MiddleName = s.MiddleName, LastName = s.LastName, Mobile = s.Mobile, Email = s.Email, DateOfBirth = s.DateOfBirth, UserName = s.UserName });

                int totalRecords = userInfoList.Count();
                return Ok(new { data = userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get User List
        ///</summary>
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{schoolid}/{role}")]
        public ActionResult GetUserListBySchool(int schoolid = 0, string role = "0")
        {
            try
            {
                //var list;
                if (schoolid == 0 || schoolid == null)
                {
                    var list = (from
                                 u in _context.Users
                                join r in _context.UserRole on
                                 u.UserRoleId equals r.UserRoleId
                                where r.RoleName.ToLower() == role
                                select new { u.UserId, u.UserRoleId, u.FirstName, u.MiddleName, u.LastName, r.RoleName, u.Mobile, u.Email, u.DateOfBirth, u.UserName });
                    var userInfoList = list.Select(s => new UserInfo
                    { UserId = s.UserId, UserRoleId = s.UserRoleId, RoleName = s.RoleName, FirstName = s.FirstName, MiddleName = s.MiddleName, LastName = s.LastName, Mobile = s.Mobile, Email = s.Email, DateOfBirth = s.DateOfBirth, UserName = s.UserName });

                    int totalRecords = userInfoList.Count();
                    return Ok(new { data = userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
                }
                else if (role == "0" || role == null)
                {
                    var list = (from
                               u in _context.Users
                                join r in _context.UserRole on
                                 u.UserRoleId equals r.UserRoleId
                                where u.SchoolId == schoolid
                                select new { u.UserId, u.UserRoleId, u.FirstName, u.MiddleName, u.LastName, r.RoleName, u.Mobile, u.Email, u.DateOfBirth, u.UserName });
                    var userInfoList = list.Select(s => new UserInfo
                    { UserId = s.UserId, UserRoleId = s.UserRoleId, RoleName = s.RoleName, FirstName = s.FirstName, MiddleName = s.MiddleName, LastName = s.LastName, Mobile = s.Mobile, Email = s.Email, DateOfBirth = s.DateOfBirth, UserName = s.UserName });

                    int totalRecords = userInfoList.Count();
                    return Ok(new { data = userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
                }
                else
                {
                    var list = (from
                                 u in _context.Users
                                join r in _context.UserRole on
                                 u.UserRoleId equals r.UserRoleId
                                where u.SchoolId == schoolid && r.RoleName.ToLower() == role
                                select new { u.UserId, u.UserRoleId, u.FirstName, u.MiddleName, u.LastName, r.RoleName, u.Mobile, u.Email, u.DateOfBirth, u.UserName });
                    var userInfoList = list.Select(s => new UserInfo
                    { UserId = s.UserId, UserRoleId = s.UserRoleId, RoleName = s.RoleName, FirstName = s.FirstName, MiddleName = s.MiddleName, LastName = s.LastName, Mobile = s.Mobile, Email = s.Email, DateOfBirth = s.DateOfBirth, UserName = s.UserName });

                    int totalRecords = userInfoList.Count();
                    return Ok(new { data = userInfoList, recordsTotal = totalRecords, recordsFiltered = totalRecords });
                }
                /* var list = (from u in _context.Users
                             join r in _context.UserRole on
                 u.UserRoleId equals r.UserRoleId
                 where r.RoleName.ToLower()=="student"
                             select new { u.UserId, u.UserRoleId, u.FirstName, u.MiddleName, u.LastName, r.RoleName, u.Mobile, u.Email, u.DateOfBirth, u.UserName });
                */

            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Get User List
        ///</summary>
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult GetStudentList()
        {
            var studentList = (from stud in _context.ParentStudent
                               join studDT in _context.Users on stud.StudentId equals studDT.UserId
                               join school in _context.Schools on stud.SchoolId equals school.SchoolId
                               join cls in _context.ClassMasters on school.SchoolId equals cls.SchoolId
                               select new StudentModel
                               {
                                   StudentId = stud.StudentId,
                                   FirstName = studDT.FirstName,
                                   MiddleName = studDT.MiddleName,
                                   LastName = studDT.LastName,
                                   SchoolId = studDT.SchoolId,
                                   ClassId = studDT.ClassId,
                                   Mobile = studDT.Mobile,
                                   Email = studDT.Email,
                                   SchoolName = school.SchoolName,
                                   ClassName = cls.ClassName,
                                   DateOfBirth = studDT.DateOfBirth,
                                   UserName = studDT.UserName,

                               }).ToList();
            var totalStudent = studentList.Count();
            return Ok(new { data = studentList, recordsTotal = totalStudent, recordsFiltered = totalStudent });

        }

        ///<summary>
        ///Get Single User by ID
        ///</summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult GetSingleUser(int id)
        {
            try
            {
                var singleUser = _userRepo.SelectById(id);
                return Ok(singleUser);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Delete Single User by ID
        ///</summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult DeleteSingleUser(int id)
        {
            try
            {
                var singleUser = _userRepo.Delete(id);
                return Ok(singleUser);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Create User
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult CreateUser(Users model)
        {
            var objCheck = _context.Users.SingleOrDefault(opt => opt.UserName == model.UserName);
            try
            {
                if (objCheck == null)
                {
                    if (ModelState.IsValid)
                    {
                        model.DateAdded = DateTime.Now;
                        model.IsActive = true;
                        model.UserName = model.Mobile;
                        model.Password = DataEncript.ConvertToEncrypt(model.Mobile);
                        model.IsPasswordChange = false;
                        model.FirstTimeLogin = true;
                        var obj = _userRepo.Insert(model);
                        return Ok(obj);
                    }
                }
                else if (objCheck != null)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate User name!" });
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Update User
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult UpdateUser(Users model)
        {
            try
            {
                var objUser = _context.Users.SingleOrDefault(opt => opt.UserId == model.UserId);
                objUser.UserRoleId = model.UserRoleId;
                objUser.FirstName = model.FirstName;
                objUser.MiddleName = model.MiddleName;
                objUser.LastName = model.LastName;
                objUser.Mobile = model.Mobile;
                objUser.Email = model.Email;
                objUser.DateOfBirth = model.DateOfBirth;
                objUser.UserName = model.UserName;
                objUser.Password = DataEncript.ConvertToEncrypt(model.Mobile);
                objUser.ImagePath = model.ImagePath;
                objUser.LastUpdatedBy = model.LastUpdatedBy;
                objUser.LastUpdatedDate = DateTime.Now;
                _context.SaveChanges();
                return Ok(objUser);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Update User Profile
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult UpdateUserProfile(UserInfo model)
        {
            try
            {
                var objUser = _context.Users.SingleOrDefault(opt => opt.UserId == model.UserId);
                objUser.FirstName = model.FirstName;
                objUser.MiddleName = model.MiddleName;
                objUser.LastName = model.LastName;
                objUser.Mobile = model.Mobile;
                objUser.Email = model.Email;
                objUser.DateOfBirth = model.DateOfBirth;
                objUser.ImagePath = model.ImagePath;
                objUser.LastUpdatedBy = model.LastUpdatedBy;
                objUser.LastUpdatedDate = DateTime.Now;
                _context.SaveChanges();
                return Ok(objUser);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Change User Password
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult ChangeUserPassword(UserInfo model)
        {
            try
            {
                var objUser = _context.Users.SingleOrDefault(opt => opt.UserId == model.UserId);
                if (objUser != null)
                {
                    objUser.Password = DataEncript.ConvertToEncrypt(model.Mobile);
                    objUser.LastPasswordChangeDate = DateTime.Now;
                    objUser.PasswordChangedBy = model.UserId;
                    objUser.IsPasswordChange = true;
                    model.FirstTimeLogin = false;
                    _context.SaveChanges();
                    return Ok(objUser);
                }
                else
                {
                    return Accepted(new Confirmation { Status = "NotFound", ResponseMsg = "User Name Not exists" });
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ResetUserPassword(string username)
        {
            try
            {
                var objUser = _context.Users.SingleOrDefault(opt => opt.UserName == username);
                if (objUser != null)
                {
                    /*objUser.Password = model.Password;
                    objUser.LastPasswordChangeDate = DateTime.Now;
                    objUser.PasswordChangedBy = model.UserId;
                    objUser.IsPasswordChange = true;*/
                    _context.SaveChanges();
                    return Ok(objUser);
                }
                else
                {
                    return Accepted(new Confirmation { Status = "NotFound", ResponseMsg = "User Name Not exists" });
                }
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }

        ///<summary>
        ///Dashboard User Status
        ///</summary>
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public ActionResult UserStatus()
        {
            try
            {
                int totalUser = _context.Users.Count();
                int activeUser = _context.Users.Where(q => q.IsActive == true).Count();
                int inActiveUser = _context.Users.Where(q => q.IsActive == false).Count();
                int adminUser = (from u in _context.Users
                                 join ur in _context.UserRole
                              on u.UserRoleId equals ur.UserRoleId
                                 where ur.RoleName == "Admin"
                                 select new { ur.RoleName }).Count();

                UserStatus objStatus = new UserStatus { TotalUser = totalUser, ActiveUser = activeUser, InActiveUser = inActiveUser, AdminUser = adminUser };
                return Ok(objStatus);
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }


        string GenerateJwtToken(UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserId.ToString()),
                new Claim("fullName", userInfo.FirstName.ToString()+Convert.ToString(userInfo.MiddleName)+userInfo.LastName.ToString()),
                new Claim("role",userInfo.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}