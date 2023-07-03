using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.NewFolder
{
    public class VisionandMissionRepository : IVisionandMissionRepository
    {
        private readonly SchoolDbContext _dbContext;
        public VisionandMissionRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<VisionandMission> GetAll() 
        {
            return _dbContext.VisionandMission.ToList();
        }
        public int UpdateVisionandMissionbyId(VisionandMission updateVisionandMission)
        {
            _dbContext.VisionandMission.Update(updateVisionandMission);
            return _dbContext.SaveChanges();
        }

        public VisionandMission GetVisionandMissionbyId(int Id)
        {
            return _dbContext.VisionandMission.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
