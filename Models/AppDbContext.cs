using AdminApi.Models.Helper;
using AdminApi.Models.Menu;
using AdminApi.Models.School;
using AdminApi.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Models
{
    public class AppDbContext:DbContext
    {     
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<LogHistory> LogHistory { get; set; }
        public virtual DbSet<AppMenu> Menu { get; set; }
        public virtual DbSet<MenuGroup> MenuGroup { get; set; }
        public virtual DbSet<MenuGroupWiseMenuMapping> MenuGroupWiseMenuMapping { get; set; }

        /*Gulab Start*/

        public DbSet<AcademyYear> AcademyYears { get; set; }

        public DbSet<AdminApi.Models.School.School> Schools { get; set; }


        public DbSet<ClassMaster> ClassMasters { get; set; }

        public DbSet<ClassroomDetails> ClassroomDetails { get; set; }

        public DbSet<SchoolClassDivision> schoolClassDivisions { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubSubjects> SubSubjects { get; set; }

        public DbSet<ParentStudent> ParentStudent { get; set; }

        public DbSet<SchoolBookPrice> SchoolBookPrice { get; set; }

        public DbSet<BookOrder> BookOrder { get; set; }

        public DbSet<TeachingMedium> TeachingMedium { get; set; }

        public DbSet<eBook> eBook { get; set; }

        public DbSet<eBookChapter> eBookChapter { get; set; }

        public DbSet<NoticeType> NoticeType { get; set; }

        public DbSet<NoticeDetail> NoticeDetail { get; set; }

        public DbSet<AcademicCalendar> AcademicCalendar { get; set; }

        public DbSet<TeachingPlan> TeachingPlan { get; set; }

        public DbSet<StudentPasswordImages> StudentPasswordImages { get; set; }

        public DbSet<StudentPassword> StudentPassword { get; set; }

        public DbSet<VideoCategory> VideoCategories { get; set; }
        public DbSet<Videos> Videos { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<City> cities { get; set; }

        /*Gulab End*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Seed();//use this for Sql server,Mysql,Sqlite and PostgreSql
            //modelBuilder.SeedOracle();//use this only for Oracle
        }

    }
}
