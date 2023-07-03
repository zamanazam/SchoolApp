using SchoolApp.DBServices.UserSer;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Services;

namespace SchoolApp.Repositories.StudentCourseRepository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
            private readonly SchoolDbContext _dbContext;
            private readonly IUserService _currentUserService;
           // private readonly IUserService _currentUserService;
            public StudentCourseRepository(SchoolDbContext dbContext, IUserService currentUserService)
            {
                _dbContext = dbContext;
                _currentUserService= currentUserService;
            }
            public int AddStudentCourse(List<int> SectionId, int StudentId)
            {
                // int UserId= _userService.GetUserId();
                for (int i = 0; i < SectionId.Count; i++)
                {
                    StudentCourse course = new();
                    course.SectionId = SectionId[i];
                    course.StudentId = StudentId;
                    course.AddedOn = DateTime.Now;
                    course.AddedBy = _currentUserService.GetUserId();
                    _dbContext.StudentCourse.Add(course);
                    StudentCourseSaveChanges();
                }
                return StudentId;
        }
        public int UpdateStudentCourse(List<int> SectionId,int StudentId)
        {
               var OldCourse =  _dbContext.StudentCourse.Where(x=>x.StudentId == StudentId).ToList();
               _dbContext.StudentCourse.RemoveRange(OldCourse);
               StudentCourseSaveChanges();
               return AddStudentCourse(SectionId, StudentId);
        }
        public int StudentCourseSaveChanges()
        {
           return _dbContext.SaveChanges();
        }

        public List<SubjectsName> GetSubjectbyClassandSectionName(int ClassId, string SectionName)
        {
            return _dbContext.StudentCourse.Where(x=>x.Section.ClassId == ClassId && x.Section.Name == SectionName).Select(y=> new SubjectsName() { 
            Name = y.Section.SubjectsName.Name,
            Id =  y.Section.SubjectsName.Id,
            }).ToList();
        }
        public SectionName GetSectionClassNamebyStudentId(int StudentId)
        {
            return _dbContext.StudentCourse.Where(x=>x.StudentId == StudentId).Select(y=> new SectionName()
            {
                Name = y.Section.Name,
                ClassNames = y.Section.ClassNames,
                ClassId = y.Section.ClassId,
                Id = y.Section.Id,
            }).FirstOrDefault();
        }
    }
}
