using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.BoardGamesManagment.Entities
{
    public class Session
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid GameId { get; set; } 
        public Guid MemberId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int DurationMinutes { get; set; }

        public Game Game { get; set; } = null!;
        public Member Member { get; set; } = null!;
    }
}
