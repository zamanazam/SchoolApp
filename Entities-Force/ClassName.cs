using SchoolApp.Entities_Force;
using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class ClassName
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? AddedOn { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual User? AddedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }
    public virtual ICollection<SectionName> SectionNames { get; set; }

}
