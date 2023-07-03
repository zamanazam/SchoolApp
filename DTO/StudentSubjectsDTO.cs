using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.DTO
{
    public class StudentSubjectsDTO
    {
        public List<User> Students { get; set; }
        public List<SubjectsName> SubjectsNames{get; set;}
    }
}
