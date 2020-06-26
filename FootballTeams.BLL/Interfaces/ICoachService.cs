using FootballTeams.BLL.DTO;
using System.Collections.Generic;

namespace FootballTeams.BLL.Interfaces
{
    public interface ICoachService
    {
        void MakeCoach(CoachDTO coachDTO);
        TeamDTO GetTeam(int? id);
        IEnumerable<TeamDTO> GetTeams();
        void Dispose();
    }
}
