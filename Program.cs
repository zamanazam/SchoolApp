using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DBServices.AttendanceSer;
using SchoolApp.DBServices.ClassSer;
using SchoolApp.DBServices.ClassService;
using SchoolApp.DBServices.EducationSer;
using SchoolApp.DBServices.FeesSer;
using SchoolApp.DBServices.ParentSer;
using SchoolApp.DBServices.ParentService;
using SchoolApp.DBServices.SectionSer;
using SchoolApp.DBServices.StudentCourseSer;
using SchoolApp.DBServices.StudentResultSer;
using SchoolApp.DBServices.UserSer;
using SchoolApp.DBServices.VisionMissionSer;
using SchoolApp.Entities;
using SchoolApp.Helpers;
using SchoolApp.Repositories.AttendanceRepository;
using SchoolApp.Repositories.ClassRepository;
using SchoolApp.Repositories.ExperienceRepository;
using SchoolApp.Repositories.FeesRepository;
using SchoolApp.Repositories.MiddleRepository;
using SchoolApp.Repositories.NewFolder;
using SchoolApp.Repositories.OurTeamRepository;
using SchoolApp.Repositories.ParentRepository;
using SchoolApp.Repositories.PrimaryRepository;
using SchoolApp.Repositories.QualificationRepository;
using SchoolApp.Repositories.SecondaryRepository;
using SchoolApp.Repositories.SectionRepository;
using SchoolApp.Repositories.StudentCourseRepository;
using SchoolApp.Repositories.StudentResRepository;
using SchoolApp.Repositories.UserRepository;
using SchoolApp.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;
builder.Services.AddAuthentication(
    x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(o =>
    {
        var Key = System.Text.Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"]);
        o.SaveToken = true;
        o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Key)

        };
    });
builder.Services.AddDbContext<SchoolDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=DESKTOP-GTT98CG\\SQLEXPRESS; Database=SchoolDb; Trusted_Connection=True;"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
services.AddControllersWithViews().AddRazorRuntimeCompilation();
// Add services to the container.
builder.Services.AddControllersWithViews();
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
//services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserServices, UserSerices>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IClassRepository, ClassRepository>();
services.AddScoped<ISectionRepository, SectionRepository>();
services.AddScoped<IParentRepository, ParentRepository>();
services.AddScoped<IQualificationRepository, QualificationRepository>();
services.AddScoped<IExperienceRepository, ExperienceRepository>();
services.AddScoped<IAccountRepository, AccountRepository>();
services.AddScoped<IPrimaryRepository, PrimaryRepository>();
services.AddScoped<IMiddleRepository, MiddleRepositroy>();
services.AddScoped<ISecondaryRepository, SecondaryRepository>();
services.AddScoped<IOurTeamRepository, OurTeamRepository>();
services.AddScoped<IFeeRepository, FeeRepository>();
services.AddScoped<IVisionandMissionRepository, VisionandMissionRepository>();
services.AddScoped<IFeeRepository, FeeRepository>();
services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
services.AddScoped<IStudentResultRepository, StudentResultRepository>();
services.AddScoped<IAttendanceRepository, AttendanceRepository>();

services.AddScoped<IFeesServices, FeesServices>();
services.AddScoped<IClassServices, ClassServices>();
services.AddScoped<IFeesServices, FeesServices>();
services.AddScoped<IEducationServices, EducationServices>();
services.AddScoped<IParentServices, ParentServices>();
services.AddScoped<ISectionServices, SectionServices>();
services.AddScoped<IUserServices, UserSerices>();
services.AddScoped<IStudentResultsServices, StudentResultsServices>();
services.AddScoped<IStudentCourseServices, StudentCourseServices>();
services.AddScoped<IVisionandMissionServices, VisionandMissionServices>();
services.AddScoped<IAttendanceServices, AttendanceServices>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
