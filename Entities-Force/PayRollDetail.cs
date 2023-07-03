using SchoolApp.Entities_Force;
using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class PayRollDetail
{
    public int Id { get; set; }

    public int? AccountId { get; set; }
    public int? Monthid { get; set; }
    public int? Year { get; set; }

    public int? PayRollDecided { get; set; }

    public int? NewPayRoll { get; set; }

    public int? PayRollGiven { get; set; }

    public bool? PayRollStatus { get; set; }

    public int? GivenBy { get; set; }

    public DateTime? GivenOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Month? ForMonth { get; set; }
    public virtual Account? Account { get; set; }

    public virtual User? GivenByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }
}
