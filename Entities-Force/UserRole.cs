using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class UserRole
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
