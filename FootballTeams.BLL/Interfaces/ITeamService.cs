using FootballTeams.BLL.DTO;
using System.Collections.Generic;

namespace FootballTeams.BLL.Interfaces
{
    public interface ITeamService
    {
        void MakeTeam(TeamDTO teamDto);
        PlayerDTO GetPlayer(int? id);
        IEnumerable<PlayerDTO> GetPlayers();
        void Dispose();
    }
}