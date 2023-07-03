using SchoolApp.Entities_Force;
using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class Course
{
    public int Id { get; set; }
    public int? SectionId { get; set; }

    public string? SubjectId { get; set; }

    public DateTime? AddedOn { get; set; }

    public int? AddedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    //public virtual User? AddedByNavigation { get; set; }

    //public virtual User? ModifiedByNavigation { get; set; }
    //public virtual SectionName? SectionNames{ get; set; }
    //public virtual ICollection<StudentResults> StudentResults { get; set; }
    //public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    //public virtual SubjectsName? SubjectsName { get; set; }

}
