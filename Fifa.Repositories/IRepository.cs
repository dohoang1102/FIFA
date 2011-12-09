using System.Collections.Generic;

using Fifa.Models;

namespace Fifa.Repositories
{
    public interface IRepository
    {
        void DeleteComment(int id);
        void SaveComment(Comment comment);
        Comment GetComment(int id);
        IEnumerable<Comment> LoadComments();

        void DeleteGame(int id);
        void SaveGame(Game game);
        Game GetGame(int id);
        IEnumerable<Game> LoadGames();

        void DeleteTeam(int id);
        void SaveTeam(Team team);
        Comment GetTeam(int id);
        IEnumerable<Team> LoadTeams();

        void DeleteTournament(int id);
        void SaveTournament(Tournament tournament);
        Comment GetTournament(int id);
        IEnumerable<Tournament> LoadTournaments();

        void DeleteUser(int id);
        void SaveUser(User user);
        User GetUser(int id);
        IEnumerable<User> LoadUsers();
    }
}