using SchoolApp.Entities;

namespace SchoolApp.DTO
{
    public class ReturnClassSection
    {
        public List<ClassName> Class{get; set;} 
        public List<SectionName> Sections{get; set;}    
    }
}
