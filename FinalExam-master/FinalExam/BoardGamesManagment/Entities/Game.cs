using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.BoardGamesManagment.Entities
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }

        public List<Session> Sessions { get; set; } = new List<Session>();
    }
}
