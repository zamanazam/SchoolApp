using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.DBServices.EducationSer
{
    public interface IEducationServices
    {
        List<PrimaryEducation> GetPrimary();
        List<MiddleEducation> GetMiddle();
        List<SecondaryEducation> GetSecondary();
        List<OurTeamDTO> GetOurTeam();
        List<VisionandMission> GetVisionandMission();
        int UpdatePrimaryEducation(UpdatePrimaryDTO updatePrimaryDTO);
        int UpdateMiddleEducation(UpdateMiddleDTO updateMiddle);
        int UpdateSecondaryEducation(UpdateSecondaryDTO updateSecondaryDTO);
        int UpdateOurTeambyId(UpdateOurTeamDTO updateOurTeam);
        List<User> GetNewTeachers();
        int AddNewTeamMember(AddOurTeamDTO team);
        int RemoveOurTeamMemberbyId(int id);
    }
}
