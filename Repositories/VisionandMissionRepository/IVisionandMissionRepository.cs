using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.NewFolder
{
    public interface IVisionandMissionRepository
    {
        List<VisionandMission> GetAll();
        VisionandMission GetVisionandMissionbyId(int Id);
        int UpdateVisionandMissionbyId(VisionandMission updateVisionandMission);
    }
}
