using System.Collections.Generic;

namespace FootballTeams.DAL.Entities
{
    public class Coach
    {
        private int CoachId { get; set; }
        private string Name { get; set; }
        private int Age { get; set; }
        private string Skill { get; set; }
        private ICollection<Team> Teams { get; set; }
    }
}
