using SchoolApp.DTO;
using SchoolApp.Entities_Force;
using SchoolApp.Repositories.NewFolder;
using SchoolApp.Services;

namespace SchoolApp.DBServices.VisionMissionSer
{
    public class VisionandMissionServices : IVisionandMissionServices
    {
        private readonly IVisionandMissionRepository _visionandMissionRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IUserService _currentUserSer;

        public VisionandMissionServices(IVisionandMissionRepository visionandMissionRepository, IWebHostEnvironment hostingEnvironment, IUserService currentUserSer)
        {
            _visionandMissionRepository = visionandMissionRepository;
            _hostingEnvironment = hostingEnvironment;
            _currentUserSer = currentUserSer;
        }
        public int UpdateVisionandMissionbyId(UpdateVisionandMissionDTO visionandMissionDTO)
        {
            VisionandMission visionandMission = _visionandMissionRepository.GetVisionandMissionbyId(visionandMissionDTO.Id);
            visionandMission.VisionText = visionandMissionDTO.VisionText;
            visionandMission.MissionText = visionandMissionDTO.MissionText;
            visionandMission.OurPlanText = visionandMissionDTO.OurPlanText;
            if (visionandMissionDTO.VisionImage != null)
            {
                string VisionImagePath = "";
                string filepath = Path.GetFileName(visionandMissionDTO.VisionImage.FileName);
                VisionImagePath = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + VisionImagePath, FileMode.Create);
                {
                    visionandMissionDTO.VisionImage.CopyTo(stream);
                    stream.Dispose();
                }
                visionandMission.VisionImage = VisionImagePath;
            }

            if (visionandMissionDTO.MissionImage != null)
            {
                string MissionImage = "";
                string filepath = Path.GetFileName(visionandMissionDTO.MissionImage.FileName);
                MissionImage = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + MissionImage, FileMode.Create);
                {
                    visionandMissionDTO.MissionImage.CopyTo(stream);
                    stream.Dispose();
                }
                visionandMission.MissionImage = MissionImage;
            }

            if (visionandMissionDTO.MainImage != null)
            {
                string MainImage = "";
                string filepath = Path.GetFileName(visionandMissionDTO.MainImage.FileName);
                MainImage = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + MainImage, FileMode.Create);
                {
                    visionandMissionDTO.MainImage.CopyTo(stream);
                    stream.Dispose();
                }
                visionandMission.MainImage = MainImage;
            }
            visionandMission.ModifiedBy = _currentUserSer.GetUserId();
            visionandMission.ModifiedOn = DateTime.Now;
            return _visionandMissionRepository.UpdateVisionandMissionbyId(visionandMission);
        }
        private void EnsureFolder(string path)
        {
            var exists = Directory.Exists(path);
            if (!exists)
                Directory.CreateDirectory(path);
        }
    }
}
