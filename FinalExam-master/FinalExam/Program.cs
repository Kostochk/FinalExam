using FinalExam.BoardGamesManagment.Data;
using FinalExam.BoardGamesManagment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BoardGamesManagmentContext db = new BoardGamesManagmentContext();

            db.Database.EnsureCreated();

            SeedMembers(db);
            SeedGames(db);
            AddSessions(db);
        }

        private static void SeedMembers (BoardGamesManagmentContext db)
        {
            var members = new List<Member>
            {
                new() {FullName="Vlad", JoinDate=new DateTime(2008,11,11)},
                new() {FullName="Kolya", JoinDate=new DateTime(2002,11,11)},
                new() {FullName="Misha", JoinDate=new DateTime(2004,11,11)},
                new() {FullName="Lesha", JoinDate=new DateTime(2019,11,11)},
                new() {FullName="Lisa", JoinDate=new DateTime(2005,11,11)}
            };
            db.Membersss.AddRange(members);
            db.SaveChanges();
        }

        private static void SeedGames(BoardGamesManagmentContext db)
        {
            var games = new List<Game>
            {
                new() {Title = "PUBG", Genre = "Battle Royale" , MinPlayers = 20 , MaxPlayers = 100 ,},
                new() {Title = "HOI4" , Genre = "Strategy" , MinPlayers = 1 , MaxPlayers = 5},
                new() {Title = "Last Of Use" , Genre = "Survivor" , MinPlayers = 1 , MaxPlayers = 2},
                new() {Title= "Lier's Bar" , Genre = "Lie" , MinPlayers = 2 , MaxPlayers = 5},
                new() {Title = "Among Us" , Genre = "Lie" , MinPlayers = 4 , MaxPlayers = 15}
            };
            db.Gamesss.AddRange(games); 
            db.SaveChanges();
        }

        private static void AddSessions(BoardGamesManagmentContext db)
        {
            var sessions = new List<Session>
            {
            };
            Random r = new Random();
            for (int i = 0; i < 23; i++)
            {
                int rDate = r.Next(1, 28);
                int rMinutes = r.Next(1, 1000);
                Member member = new Member();
                Game game = new Game();
                Session rSession = new Session { MemberId = member.Id , GameId = game.Id, Date = new DateTime(2005, 11, rDate), DurationMinutes = rMinutes };
                sessions.Add(rSession);
            }
            db.Sessionsss.AddRange(sessions);
            db.SaveChanges();
        }

    }
}