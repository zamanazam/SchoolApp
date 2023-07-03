using Microsoft.Identity.Client;
using SchoolApp.Entities_Force;
using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class SectionName
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }
    public int? ClassId { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }
    public int? SubjectId { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }
    public virtual ClassName? ClassNames { get; set; }
    public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    public virtual ICollection<StudentResults> StudentResults { get; set; }
    public virtual SubjectsName? SubjectsName { get; set; }

}
