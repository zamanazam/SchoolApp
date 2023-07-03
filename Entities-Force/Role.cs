using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? RolesName { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
