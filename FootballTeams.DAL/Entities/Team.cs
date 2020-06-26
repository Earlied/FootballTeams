using FootballTeams.DAL.Entities;
using System;
using System.Collections.Generic;

namespace FootballTeams.DAL.Entities
{
    public class Team
    {
        private int TeamId { get; set; }
        private string Name { get; set; }
        private string Skill { get; set; }
        private DateTime EstDate { get; set; }
        private ICollection<Player> Players { get; set; }
    }
}