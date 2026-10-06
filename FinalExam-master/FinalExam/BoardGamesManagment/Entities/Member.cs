using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.BoardGamesManagment.Entities
{
    public class Member
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = null!;
        public DateTime JoinDate { get; set; }= DateTime.UtcNow;

        public List<Session> Sessions { get; set; } = new List<Session>();
        public override string ToString()
        {
            return $"{FullName} (Joined: {JoinDate.ToShortDateString()})";
        }
    }
}
