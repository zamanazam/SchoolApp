using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.OurTeamRepository
{
    public class OurTeamRepository : IOurTeamRepository
    {
        private readonly SchoolDbContext _dbContext;
        public OurTeamRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<OurTeam> GetAll()
        {
            return _dbContext.OurTeam.ToList();
        }
        public OurTeam GetOurTeambyId(int id)
        {
            return _dbContext.OurTeam.Where(x => x.Id == id).FirstOrDefault();
        }
        public int UpdateOurTeam(OurTeam ourTeam)
        {
            _dbContext.OurTeam.Update(ourTeam);
            return _dbContext.SaveChanges();
        }
        public int AddNewTeamMember(OurTeam team)
        {
            _dbContext.OurTeam.Add(team);
            return _dbContext.SaveChanges();
        }
        public OurTeam GetTeamMemberbyId (int id)
        {
            return _dbContext.OurTeam.Where(x => x.Id == id).FirstOrDefault();
        }
        public int DeleteTeamMember (OurTeam team)
        {
            _dbContext.OurTeam.Remove(team);
            return _dbContext.SaveChanges();
        }
    }
}
