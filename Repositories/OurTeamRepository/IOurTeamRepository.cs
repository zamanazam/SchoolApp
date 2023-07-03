using SchoolApp.DTO;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.OurTeamRepository
{
    public interface IOurTeamRepository
    {
        List<OurTeam> GetAll();
        OurTeam GetOurTeambyId(int id);
        int UpdateOurTeam(OurTeam ourTeam);
        int AddNewTeamMember(OurTeam team);
        OurTeam GetTeamMemberbyId(int id);
        int DeleteTeamMember(OurTeam team);
    }
}
