using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class Parent
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? FatherName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNo { get; set; }

    public string? Relation { get; set; }

    public string? Religion { get; set; }

    public string? Gender { get; set; }

   // public string? Address { get; set; }

    public string? Cnic { get; set; }

    public bool? IsAlive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
