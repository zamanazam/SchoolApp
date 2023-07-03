using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Entities_Force;

namespace SchoolApp.Entities;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<OurTeam> OurTeam { get; set; }
    public virtual DbSet<VisionandMission> VisionandMission { get; set; }
    public virtual DbSet<PrimaryEducation> PrimaryEducation { get; set; }
    public virtual DbSet<MiddleEducation> MiddleEducation { get; set; }
    public virtual DbSet<SecondaryEducation> SecondaryEducation { get; set; }
    public virtual DbSet<Announcement> Announcements { get; set; }
    public virtual DbSet<TeacherExperience> TeacherExperience { get; set; }
    public virtual DbSet<TeacherQualification> TeacherQualification { get; set; }

    public virtual DbSet<AnnouncementType> AnnouncementTypes { get; set; }

    public virtual DbSet<ClassName> ClassNames { get; set; }
    public virtual DbSet<StudentResults> StudentResults { get; set; }

    public virtual DbSet<Month> Month { get; set; }
    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<PayRollDetail> PayRollDetails { get; set; }
    public virtual DbSet<Attendance> Attendance { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SectionName> SectionNames { get; set; }

    public virtual DbSet<StudentCourse> StudentCourse { get; set; }
    public virtual DbSet<SubjectsName> SubjectsName { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=SchoolDb; TrustServerCertificate=True; Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC0726C2DBEC");

            entity.ToTable("Account");

            entity.Property(e => e.AccountNumber).IsUnicode(false);
            entity.Property(e => e.BankName).IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AccountCreatedBy).WithMany(p => p.AccountCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Account__Created__59063A47");

            entity.HasOne(d => d.Employe).WithMany(p => p.AccountEmployes)
                .HasForeignKey(d => d.EmployeId)
                .HasConstraintName("FK__Account__Employe__59FA5E80");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AccountModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Account__Modifie__5AEE82B9");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Announce__3214EC071C9DC5ED");

            entity.Property(e => e.AnnouncedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AnnouncedByNavigation).WithMany(p => p.AnnouncementAnnouncedByNavigations)
                .HasForeignKey(d => d.AnnouncedBy)
                .HasConstraintName("FK__Announcem__Annou__4316F928");

            entity.HasOne(d => d.AnnouncementTypeNavigation).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.AnnouncementType)
                .HasConstraintName("FK__Announcem__Annou__4222D4EF");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AnnouncementModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Announcem__Modif__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.AnnouncementUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Announcem__UserI__412EB0B6");
        });
        
        modelBuilder.Entity<OurTeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OurTea__3214EC071C9DC5ED");

            entity.Property(e => e.UploadOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.Property(e => e.Text).IsUnicode(false);
            entity.Property(e => e.Designation).IsUnicode(false);

            entity.HasOne(d => d.TeacherOurTeam).WithMany(p => p.TeacherOurTeam)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("FK__OurTeam__TeacherId__4316F928");

            entity.HasOne(d => d.ModifierOurTeam).WithMany(p => p.ModifierOurTeam)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__OurTeam__ModifiedBy__4222D4EF");
            
            entity.HasOne(d => d.AddedOurTeam).WithMany(p => p.AddedOurTeam)
                .HasForeignKey(d => d.UploadBy)
                .HasConstraintName("FK__OurTeam__UploaddBy__4222D4EF");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attend__3214EC071C9DC5ED");

            entity.Property(e => e.attendancedate).HasColumnType("datetime");
            entity.Property(e => e.AddedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.AttendanceStatus).IsUnicode(false);


            entity.HasOne(d => d.User).WithMany(p => p.UserAttendance)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Attendance__UserId__4316F928");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.AttendanceAddNavigation)
                .HasForeignKey(d => d.AddedBy)
                .HasConstraintName("FK__Attendance__AddedBy__4222D4EF");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AttendanceModifierNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Attendance__UModifiedBy__4222D4EF");
        });

        modelBuilder.Entity<VisionandMission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VisionandMi__3214EC071C9DC5ED");

            entity.Property(e => e.UploadOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.Property(e => e.OurPlanText).IsUnicode(false);
            entity.Property(e => e.VisionText).IsUnicode(false);
            entity.Property(e => e.MissionText).IsUnicode(false);

            entity.Property(e => e.VisionImage).IsUnicode(false);
            entity.Property(e => e.MissionImage).IsUnicode(false);
            entity.Property(e => e.MainImage).IsUnicode(false);


            entity.HasOne(d => d.ModifierVisionandMission).WithMany(p => p.ModifierVisionandMission)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__VisionandMission__ModifiedBy__4316F928");
        });

        modelBuilder.Entity<Month>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Month__3214EC071C9DC5ED");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<PrimaryEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrimaryEduc__3214EC071C9DC5ED");

            entity.Property(e => e.UploadOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.Property(e => e.PrimaryTextHeading).IsUnicode(false);
            entity.Property(e => e.Text).IsUnicode(false);
            entity.Property(e => e.MainText).IsUnicode(false);

            entity.Property(e => e.MainImage).IsUnicode(false);
            entity.Property(e => e.PrimaryImage).IsUnicode(false);


            entity.HasOne(d => d.Modifier).WithMany(p => p.ModifierPrimaryEducation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__PrimaryEduc__ModifiedBy__4316F928");
        }); 
        
        modelBuilder.Entity<MiddleEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MiddleE__3214EC071C9DC5ED");

            entity.Property(e => e.UploadOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.Property(e => e.MiddleTextHeading).IsUnicode(false);
            entity.Property(e => e.Text).IsUnicode(false);
            entity.Property(e => e.MainText).IsUnicode(false);

            entity.Property(e => e.MainImage).IsUnicode(false);
            entity.Property(e => e.MiddleImage).IsUnicode(false);


            entity.HasOne(d => d.Modifier).WithMany(p => p.ModifierMiddleEducation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__PrimaryEduc__ModifiedBy__4316F928");
        }); 
        
        modelBuilder.Entity<SecondaryEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SecondaryEduc__3214EC071C9DC5ED");

            entity.Property(e => e.UploadOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.Property(e => e.SecondaryTextHeading).IsUnicode(false);
            entity.Property(e => e.Text).IsUnicode(false);
            entity.Property(e => e.MainText).IsUnicode(false);

            entity.Property(e => e.MainImage).IsUnicode(false);
            entity.Property(e => e.SecondaryImage).IsUnicode(false);


            entity.HasOne(d => d.Modifier).WithMany(p => p.ModifierSecondaryEducation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__SecondaryEduc__ModifiedBy__4316F928");
        });

        modelBuilder.Entity<TeacherExperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherExpe__3214EC071C9DC5ED");

            entity.Property(e => e.Designation).IsUnicode(false);
            entity.Property(e => e.Institution).IsUnicode(false);
            entity.Property(e => e.Duration).IsUnicode(false);

            entity.Property(e => e.UploadOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.TeacherExperiences).WithMany(p => p.TeacherExperienceses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherExper__TeacherId__4316F928");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.TeacherExperiencesModifiedByNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__TeacherExper__Modif__440B1D61");

        });

        modelBuilder.Entity<TeacherQualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherQualif__3214EC071C9DC5ED");

            entity.Property(e => e.DegreeName).IsUnicode(false);
            entity.Property(e => e.Institute).IsUnicode(false);
            entity.Property(e => e.PassingYear).IsUnicode(false);

            entity.Property(e => e.UploadOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.TeacherQualifications).WithMany(p => p.TeacherQualificationses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherQualif__TeacherId__4316F928");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.TeacherQualificationsModifiedByNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__TeacherQualif__Modif__440B1D61");
        });

        modelBuilder.Entity<SubjectsName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubjectsN__3214EC071C9DC5ED");

            entity.Property(e => e.Name).IsUnicode(false);

            entity.Property(e => e.AddedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.NewSubjectAddNavigation)
                .HasForeignKey(d => d.AddedBy)
                .HasConstraintName("FK__SubjectsNam__AddedBy__4316F928");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.NewSubjectModifierNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__SubjectsNam__Modif__440B1D61");
        });


        modelBuilder.Entity<AnnouncementType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Announce__3214EC07DCCE6560");

            entity.Property(e => e.Announcement)
                .HasMaxLength(545)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentResults>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentRes__3214EC071C9DC5ED");

            entity.Property(e => e.UploadOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Score)
                     .HasMaxLength(245)
                     .IsUnicode(false);

            entity.Property(e => e.Total)
                     .HasMaxLength(245)
                     .IsUnicode(false);
            entity.Property(e => e.BatchYear)
                     .HasMaxLength(245)
                     .IsUnicode(false);

            entity.HasOne(d => d.OnMonth).WithMany(p => p.ResultOnMonth)
                .HasForeignKey(d => d.MonthId)
                .HasConstraintName("FK__StudentResults__MonthId__4AB81AF0");
            
            entity.HasOne(d => d.UploadByNavigation).WithMany(p => p.ResultUploadNavigation)
                .HasForeignKey(d => d.UploadBy)
                .HasConstraintName("FK__StudentResults__Added__4AB81AF0");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ResultModifiedNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__StudentResults__Modif__4BAC3F29");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentResults)
               .HasForeignKey(d => d.StudentId)
               .HasConstraintName("FK__StudentResults__StudentId__4BAC3F29");

            entity.HasOne(d => d.Section).WithMany(p => p.StudentResults)
               .HasForeignKey(d => d.SectionId)
               .HasConstraintName("FK__StudentResults__SectionId__4BAC3F29");
        });

        modelBuilder.Entity<ClassName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassNam__3214EC07C516959F");

            entity.ToTable("ClassName");

            entity.Property(e => e.AddedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.ClassNameAddedByNavigations)
                .HasForeignKey(d => d.AddedBy)
                .HasConstraintName("FK__ClassName__Added__4AB81AF0");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ClassNameModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ClassName__Modif__4BAC3F29"); 
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fees__3214EC07D54A77CE");
            entity.Property(e => e.Year).HasMaxLength(245)
                 .IsUnicode(false);

            entity.Property(e => e.CollectedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CollectedByNavigation).WithMany(p => p.FeeCollectedByNavigations)
                .HasForeignKey(d => d.CollectedBy)
                .HasConstraintName("FK__Fees__CollectedB__6383C8BA");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.FeeModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Fees__ModifiedBy__6477ECF3");

            entity.HasOne(d => d.User).WithMany(p => p.FeeUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Fees__UserId__628FA481");

            entity.HasOne(d => d.ForMonth).WithMany(p => p.FeesForMonth)
                .HasForeignKey(d => d.MonthId)
                .HasConstraintName("FK__Fees__MonthId__628FA481");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Parent__3214EC079FA78EFD");

            entity.ToTable("Parent");

            entity.Property(e => e.Cnic)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CNIC");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(245)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(245)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IsAlive).HasColumnName("isAlive");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(245)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(245)
                .IsUnicode(false);
            entity.Property(e => e.Relation)
                .HasMaxLength(245)
                .IsUnicode(false);
            entity.Property(e => e.Religion)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.Parents)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Parent__Modified__46E78A0C");
        });

        modelBuilder.Entity<PayRollDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PayRollD__3214EC07CAABCDC2");

            entity.Property(e => e.GivenOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.Property(e => e.Year).HasMaxLength(245)
          .IsUnicode(false);

            entity.HasOne(d => d.ForMonth).WithMany(p => p.PayForMonth)
               .HasForeignKey(d => d.Monthid)
               .HasConstraintName("FK__PayRollDe__Month__5DCAEF64");

            entity.HasOne(d => d.Account).WithMany(p => p.PayRollDetails)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__PayRollDe__Accou__5DCAEF64");

            entity.HasOne(d => d.GivenByNavigation).WithMany(p => p.PayRollDetailGivenByNavigations)
                .HasForeignKey(d => d.GivenBy)
                .HasConstraintName("FK__PayRollDe__Given__5EBF139D");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PayRollDetailModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__PayRollDe__Modif__5FB337D6");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07930ADB9F");

            entity.Property(e => e.RolesName)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SectionName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SectionN__3214EC074DE41AE4");

            entity.ToTable("SectionName");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(545)
                .IsUnicode(false);


            entity.HasOne(d => d.SubjectsName).WithMany(p => p.Sections)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__SectionNa__SubjectN__4E88ABD4");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SectionNameCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__SectionNa__Creat__4E88ABD4");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.SectionNameModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__SectionNa__Modif__4F7CD00D");
            
            entity.HasOne(d => d.ClassNames).WithMany(p => p.SectionNames)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__SectionNa__ClassNa__4F7CD00D");
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentCourse__3214EC079CB040E7");

            entity.Property(e => e.AddedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.BatchYear).HasMaxLength(245)
                .IsUnicode(false);

            entity.HasOne(d => d.Section).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK__StudentCour__SectionId__70DDC3D8");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.StudentCoursesAddNavigation)
                .HasForeignKey(d => d.AddedBy)
                .HasConstraintName("FK__StudentCour__AddedB__70DDC3D8");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.StudentCoursesModifierNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__StudentCour__Modifi__71D1E811");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentCourse__StudentId__71D1E811");
        });

        //modelBuilder.Entity<Course>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__Course__3214EC079CB040E7");

        //    entity.Property(e => e.AddedOn).HasColumnType("datetime");
        //    entity.Property(e => e.ModifiedOn).HasColumnType("datetime");


        //    entity.HasOne(d => d.SubjectsName).WithMany(p => p.Courses)
        //        .HasForeignKey(d => d.SubjectId)
        //        .HasConstraintName("FK__Course__SubjectId__70DDC3D8");
            
        //    entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.SubjectAddedByNavigations)
        //        .HasForeignKey(d => d.AddedBy)
        //        .HasConstraintName("FK__Course__AddedB__70DDC3D8");

        //    entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.SubjectModifiedByNavigations)
        //        .HasForeignKey(d => d.ModifiedBy)
        //        .HasConstraintName("FK__Course__Modifi__71D1E811");   
            
        //    entity.HasOne(d => d.SectionNames).WithMany(p => p.Subjects)
        //        .HasForeignKey(d => d.SectionId)
        //        .HasConstraintName("FK__Course__SectionNa__71D1E811");
        //});

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0749976218");

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Cnic)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CNIC");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(555)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(245)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.SId)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(245)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Otp)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("OTP");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Religion)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.SecretKey)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Parent).WithMany(p => p.Users)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Users__ParentId__47DBAE45");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC07AF6AF69B");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserRoleCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__UserRoles__Creat__3C69FB99");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRoles__RoleI__3A81B327");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRoles__UserI__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
