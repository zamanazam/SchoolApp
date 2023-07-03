using Microsoft.AspNetCore.Mvc;
using SchoolApp.DBServices.ClassSer;
using SchoolApp.Entities;
using SchoolApp.Repositories.ClassRepository;
using SchoolApp.Repositories.UserRepository;

namespace SchoolApp.DBServices.ClassService
{
    public class ClassServices : IClassServices
    {
        private readonly IClassRepository _classRepository;
        public ClassServices(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public List<ClassName> GetAllClasses()
        {
            return _classRepository.GetAllClasses();
        }
    }
}
