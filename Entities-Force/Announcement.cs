using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class Announcement
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public DateTime? AnnouncedOn { get; set; }

    public int? AnnouncementType { get; set; }

    public int? AnnouncedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual User? AnnouncedByNavigation { get; set; }

    public virtual AnnouncementType? AnnouncementTypeNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual User? User { get; set; }
}
