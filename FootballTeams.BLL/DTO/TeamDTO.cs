using System;
using FootballTeams.DAL.Entities;

namespace FootballTeams.BLL.DTO
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public DateTime? EstDate { get; set; }
    }
}
