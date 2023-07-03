using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DBServices.UserSer;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Repositories.MiddleRepository;
using SchoolApp.Repositories.NewFolder;
using SchoolApp.Repositories.OurTeamRepository;
using SchoolApp.Repositories.PrimaryRepository;
using SchoolApp.Repositories.SecondaryRepository;
using SchoolApp.Repositories.UserRepository;
using SchoolApp.Services;
using System.Reflection;

namespace SchoolApp.DBServices.EducationSer
{
    public class EducationServices : IEducationServices
    {
        private readonly IPrimaryRepository _primaryRepo;
        private readonly IMiddleRepository _middleRepo;
        private readonly ISecondaryRepository _secondaryRepo;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IOurTeamRepository _ourTeamRepo;
        private readonly IVisionandMissionRepository _visionandMissionRepo;
        private readonly IUserService _currentUserSer;
        private readonly IUserServices _userServices;
        private readonly IUserRepository _userRepo;
        public EducationServices(IPrimaryRepository primaryRepo, IMiddleRepository middleRepo, ISecondaryRepository secondaryRepo, IUserServices userServices, IUserRepository userRepo,
                                    IOurTeamRepository ourTeamRepo, IVisionandMissionRepository visionandMissionRepository, IUserService currentUserSer, IWebHostEnvironment hostingEnvironment)
        {
            _currentUserSer = currentUserSer;
            _primaryRepo = primaryRepo;
            _middleRepo = middleRepo;
            _secondaryRepo = secondaryRepo;
            _ourTeamRepo = ourTeamRepo;
            _visionandMissionRepo = visionandMissionRepository;
            _hostingEnvironment = hostingEnvironment;
            _userServices = userServices;
            _userRepo = userRepo;
        }
        public List<PrimaryEducation> GetPrimary()
        {
            List<PrimaryEducation> primary = _primaryRepo.GetAll();
            return primary;
        }
        public List<MiddleEducation> GetMiddle()
        {
            List<MiddleEducation> middles = _middleRepo.GetAll();
            return middles;
        }
        public List<SecondaryEducation> GetSecondary()
        {
            List<SecondaryEducation> secondary = _secondaryRepo.GetAll();
            return secondary;
        }
        public List<OurTeamDTO> GetOurTeam()
        {
            List<OurTeam> ourTeams = _ourTeamRepo.GetAll();

            return ourTeams.Select(x => new OurTeamDTO()
            {
                Designation = x.Designation,
                Text = x.Text,
                TeacherName = _userServices.GetUserbyId(Convert.ToInt32(x.Teacherid)).Name,
                TeacherImage = _userServices.GetUserbyId(Convert.ToInt32(x.Teacherid)).Image,
                TeacherDesignation = _userServices.GetUserbyId(Convert.ToInt32(x.Teacherid)).RoleName,
                Id = x.Id
            }).ToList();
        }
        public int AddNewTeamMember(AddOurTeamDTO team)
        {
            OurTeam ourTeam = new();
            ourTeam.Designation = team.Designation;
            ourTeam.Teacherid = team.Teacherid;
            ourTeam.Text = team.Text;
            ourTeam.UploadOn = DateTime.Now;
            ourTeam.UploadBy = _currentUserSer.GetUserId();
            return _ourTeamRepo.AddNewTeamMember(ourTeam);
        }

        public int UpdateOurTeambyId(UpdateOurTeamDTO updateOurTeam)
        {
            OurTeam ourTeam = _ourTeamRepo.GetOurTeambyId(updateOurTeam.Id);
            ourTeam.Text = updateOurTeam.Text;
            ourTeam.Designation = updateOurTeam.Designation;
            ourTeam.ModifiedOn = DateTime.Now;
            ourTeam.ModifiedBy = _currentUserSer.GetUserId();
            return _ourTeamRepo.UpdateOurTeam(ourTeam);
        }
        public List<VisionandMission> GetVisionandMission()
        {
            List<VisionandMission> visionandMissions = _visionandMissionRepo.GetAll();
            return visionandMissions;
        }

        public int UpdatePrimaryEducation(UpdatePrimaryDTO updatePrimaryDTO)
        {
            PrimaryEducation primary = _primaryRepo.GetPrimaryEducationbyId(updatePrimaryDTO.Id);
            primary.Id = updatePrimaryDTO.Id;
            primary.PrimaryTextHeading = updatePrimaryDTO.PrimaryTextHeading;
            primary.MainText = updatePrimaryDTO.MainText;
            primary.Text = updatePrimaryDTO.Text;
            primary.ModifiedOn = DateTime.Now;
            primary.ModifiedBy = _currentUserSer.GetUserId();
            if(updatePrimaryDTO.MainImage != null)
            {
                string MainImagePath = "";
                string filepath = Path.GetFileName(updatePrimaryDTO.MainImage.FileName);
                MainImagePath = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + MainImagePath, FileMode.Create);
                {
                    updatePrimaryDTO.MainImage.CopyTo(stream);
                    stream.Dispose();
                }
                primary.MainImage = MainImagePath;
            }

            if(updatePrimaryDTO.PrimaryImage != null)
            {
                string PrimaryImagePath = "";
                string filepath = Path.GetFileName(updatePrimaryDTO.PrimaryImage.FileName);
                PrimaryImagePath = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + PrimaryImagePath, FileMode.Create);
                {
                    updatePrimaryDTO.PrimaryImage.CopyTo(stream);
                    stream.Dispose();
                }
                primary.PrimaryImage = PrimaryImagePath;
            }
            return _primaryRepo.UpdatePrimaryEducation(primary);
        }

        public int UpdateMiddleEducation(UpdateMiddleDTO updateMiddle)
        {
            MiddleEducation middle = _middleRepo.GetMiddleEducationbyId(updateMiddle.Id);
            middle.Id = updateMiddle.Id;
            middle.MiddleTextHeading = updateMiddle.MiddleTextHeading;
            middle.MainText = updateMiddle.MainText;
            middle.Text = updateMiddle.Text;
            middle.ModifiedOn = DateTime.Now;
            middle.ModifiedBy = _currentUserSer.GetUserId();
            if (updateMiddle.MainImage != null)
            {
                string MainImagePath = "";
                string filepath = Path.GetFileName(updateMiddle.MainImage.FileName);
                MainImagePath = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + MainImagePath, FileMode.Create);
                {
                    updateMiddle.MainImage.CopyTo(stream);
                    stream.Dispose();
                }
                middle.MainImage = MainImagePath;
            }

            if (updateMiddle.MiddleImage != null)
            {
                string MiddleImagePath = "";
                string filepath = Path.GetFileName(updateMiddle.MiddleImage.FileName);
                MiddleImagePath = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + MiddleImagePath, FileMode.Create);
                {
                    updateMiddle.MiddleImage.CopyTo(stream);
                    stream.Dispose();
                }
                middle.MiddleImage = MiddleImagePath;
            }
            return _middleRepo.UpdateMiddleEducation(middle);
        }

        public int UpdateSecondaryEducation(UpdateSecondaryDTO updateSecondaryDTO)
        {
            SecondaryEducation secondary = _secondaryRepo.GetSecondaryEducationbyId(updateSecondaryDTO.Id);

                secondary.Id = updateSecondaryDTO.Id;
                secondary.SecondaryTextHeading = updateSecondaryDTO.SecondaryTextHeading;
                secondary.MainText = updateSecondaryDTO.MainText;
                secondary.Text = updateSecondaryDTO.Text;

                if(updateSecondaryDTO.MainImage != null)
                {
                    string MainImage = "";
                    string filepath = Path.GetFileName(updateSecondaryDTO.MainImage.FileName);
                    MainImage = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                    string currentDirectory = _hostingEnvironment.WebRootPath;
                    EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                    using FileStream stream = new FileStream(currentDirectory + MainImage, FileMode.Create);
                    {
                        updateSecondaryDTO.MainImage.CopyTo(stream);
                        stream.Dispose();
                    }
                    secondary.MainImage = MainImage;
                }

                if (updateSecondaryDTO.SecondaryImage != null)
                {
                    string SecondaryImage = "";
                    string filepath = Path.GetFileName(updateSecondaryDTO.SecondaryImage.FileName);
                    SecondaryImage = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                    string currentDirectory = _hostingEnvironment.WebRootPath;
                    EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                    using FileStream stream = new FileStream(currentDirectory + SecondaryImage, FileMode.Create);
                    {
                        updateSecondaryDTO.SecondaryImage.CopyTo(stream);
                        stream.Dispose();
                    }
                    secondary.SecondaryImage = SecondaryImage;
                }
                return _secondaryRepo.UpdateSecondaryEducation(secondary);
        }
        public int RemoveOurTeamMemberbyId (int id)
        {
            OurTeam team = _ourTeamRepo.GetOurTeambyId(id);
            return _ourTeamRepo.DeleteTeamMember(team);
        }
        private void EnsureFolder(string path)
        {
            var exists = Directory.Exists(path);
            if (!exists)
                Directory.CreateDirectory(path);
        }
        public List<User> GetNewTeachers()
        {
            return _userRepo.GetNewTeachers();
        }
    }
}
