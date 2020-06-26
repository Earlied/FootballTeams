using System;
using FootballTeams.DAL.Entities;

namespace FootballTeams.BLL.DTO
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Skill { get; set; }
        public int TeamId { get; set; }
    }
}
