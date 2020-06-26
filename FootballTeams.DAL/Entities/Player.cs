using System.Collections.Generic;

namespace FootballTeams.DAL.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Skill { get; set; }

        public int TeamId { get; set; }
    }
}