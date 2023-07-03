using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class AnnouncementType
{
    public int Id { get; set; }

    public string? Announcement { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
}
