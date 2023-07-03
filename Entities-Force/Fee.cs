using SchoolApp.Entities_Force;
using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class Fee
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? FeesDecided { get; set; }

    public int? FeesGiven { get; set; }

    public bool? FeeStatus { get; set; }

    public int? CollectedBy { get; set; }
    public int? MonthId { get; set; }
    public int? Year { get; set; }
    public DateTime? CollectedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual User? CollectedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual User? User { get; set; }
    public virtual Month? ForMonth { get; set; }
}
