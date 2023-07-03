using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class Account
{
    public int Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? EmployeId { get; set; }

    public bool? AccountStatus { get; set; }

    public string? AccountNumber { get; set; }

    public string? BankName { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual User? AccountCreatedBy { get; set; }

    public virtual User? Employe { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<PayRollDetail> PayRollDetails { get; set; } = new List<PayRollDetail>();
}
