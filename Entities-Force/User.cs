using SchoolApp.Entities_Force;
using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? SId { get; set; }

    public string? FatherName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Cnic { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }

    public string? Image { get; set; }

    public string? City { get; set; }

    public string? Nationality { get; set; }

    public DateTime? CreatedOn { get; set; }

    public bool? Status { get; set; }

    public string? Password { get; set; }

    public string? PostalCode { get; set; }

    public string? Otp { get; set; }

    public string? SecretKey { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Religion { get; set; }

    public int? ParentId { get; set; }

    public virtual ICollection<OurTeam> TeacherOurTeam { get; set; }
    public virtual ICollection<OurTeam> ModifierOurTeam { get; set; }
    public virtual ICollection<OurTeam> AddedOurTeam { get; set; }

    public virtual ICollection<TeacherExperience> TeacherExperienceses { get; set; } 
    public virtual ICollection<TeacherExperience> TeacherExperiencesModifiedByNavigation { get; set; }

    public virtual ICollection<TeacherQualification> TeacherQualificationses { get; set; }
    public virtual ICollection<TeacherQualification> TeacherQualificationsModifiedByNavigation { get; set; }

    public virtual ICollection<Account> AccountCreatedByNavigations { get; set; } = new List<Account>();

    public virtual ICollection<Account> AccountEmployes { get; set; } = new List<Account>();

    public virtual ICollection<Account> AccountModifiedByNavigations { get; set; } = new List<Account>();

    public virtual ICollection<Announcement> AnnouncementAnnouncedByNavigations { get; set; } = new List<Announcement>();

    public virtual ICollection<Announcement> AnnouncementModifiedByNavigations { get; set; } = new List<Announcement>();

    public virtual ICollection<Announcement> AnnouncementUsers { get; set; } = new List<Announcement>();

    public virtual ICollection<ClassName> ClassNameAddedByNavigations { get; set; } = new List<ClassName>();

    public virtual ICollection<ClassName> ClassNameModifiedByNavigations { get; set; } = new List<ClassName>();

    public virtual ICollection<Fee> FeeCollectedByNavigations { get; set; } = new List<Fee>();

    public virtual ICollection<Fee> FeeModifiedByNavigations { get; set; } = new List<Fee>();

    public virtual ICollection<Fee> FeeUsers { get; set; } = new List<Fee>();

    public virtual Parent? Parent { get; set; }
    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();

    public virtual ICollection<PayRollDetail> PayRollDetailGivenByNavigations { get; set; } = new List<PayRollDetail>();

    public virtual ICollection<PayRollDetail> PayRollDetailModifiedByNavigations { get; set; } = new List<PayRollDetail>();

    public virtual ICollection<SectionName> SectionNameCreatedByNavigations { get; set; } = new List<SectionName>();

    public virtual ICollection<SectionName> SectionNameModifiedByNavigations { get; set; } = new List<SectionName>();

    //public virtual ICollection<Course> SubjectAddedByNavigations { get; set; } = new List<Course>();

    //public virtual ICollection<Course> SubjectModifiedByNavigations { get; set; } = new List<Course>();

    public virtual ICollection<UserRole> UserRoleCreatedByNavigations { get; set; } = new List<UserRole>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual ICollection<VisionandMission> ModifierVisionandMission { get; set; }
    public virtual ICollection<PrimaryEducation> ModifierPrimaryEducation { get; set; }
    public virtual ICollection<MiddleEducation> ModifierMiddleEducation { get; set; }
    public virtual ICollection<SecondaryEducation> ModifierSecondaryEducation { get; set; }
    public virtual ICollection<StudentResults> ResultUploadNavigation { get; set; }
    public virtual ICollection<StudentResults> ResultModifiedNavigation { get; set; }
    public virtual ICollection<StudentResults> StudentResults { get; set; }
    public virtual ICollection<SubjectsName> NewSubjectAddNavigation { get; set; }
    public virtual ICollection<SubjectsName> NewSubjectModifierNavigation { get; set; }
    public virtual ICollection<StudentCourse> StudentCoursesAddNavigation { get; set; }
    public virtual ICollection<StudentCourse> StudentCoursesModifierNavigation { get; set; }
    public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    public virtual ICollection<Attendance> UserAttendance { get; set; }
    public virtual ICollection<Attendance> AttendanceAddNavigation { get; set; }
    public virtual ICollection<Attendance> AttendanceModifierNavigation { get; set; }
}
