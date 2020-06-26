using AutoMapper;
using FootballTeams.BLL.DTO;
using FootballTeams.BLL.Infrastructure;
using FootballTeams.BLL.Interfaces;
using FootballTeams.DAL.Entities;
using FootballTeams.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeams.BLL.Services
{
    public class CoachService : ICoachService
    {
        IUnitOfWork Database { get; set; }

        public CoachService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeCoach(CoachDTO coachDto)
        {
            Coach coach = Database.Coaches.Get(coachDto.CoachId);

            // валидация
            if (coach == null)
                throw new ValidationException("Coach not found", "");
            // применяем скидку
            /*decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                PhoneId = phone.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();*/
        }

        public IEnumerable<TeamDTO> GetTeams()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Team, TeamDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Team>, List<TeamDTO>>(Database.Teams.GetAll());
        }

        public TeamDTO GetTeam(int? id)
        {
            if (id == null)
                throw new ValidationException("Team ID not specified", "");
            var team = Database.Teams.Get(id.Value);
            if (team == null)
                throw new ValidationException("Team not found", "");

            return new TeamDTO { Name = team.Name, EstDate = team.EstDate, Skill = team.Skill, TeamId = team.TeamId};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
