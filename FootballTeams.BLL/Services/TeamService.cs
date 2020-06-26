using System;
using FootballTeams.BLL.DTO;
using FootballTeams.DAL.Entities;
using FootballTeams.DAL.Interfaces;
using FootballTeams.BLL.Infrastructure;
using FootballTeams.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace FootballTeams.BLL.Services
{
    public class TeamService : ITeamService
    {
        IUnitOfWork Database { get; set; }

        public TeamService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeTeam(TeamDTO teamDto)
        {
            Team team = Database.Teams.Get(teamDto.TeamId);

            // валидация
            if (team == null)
                throw new ValidationException("Team not found", "");
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

        public IEnumerable<PlayerDTO> GetPlayers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Player, PlayerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Player>, List<PlayerDTO>>(Database.Players.GetAll());
        }

        public PlayerDTO GetPlayer(int? id)
        {
            if (id == null)
                throw new ValidationException("Player ID not specified", "");
            var player = Database.Players.Get(id.Value);
            if (player == null)
                throw new ValidationException("Player not found", "");

            return new PlayerDTO { PlayerId=player.PlayerId, Name = player.Name, Age = player.Age, Skill = player.Skill, TeamId = player.TeamId };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}