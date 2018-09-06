using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TornadoLeaderboard.Models
{
    public class LeaderboardScore
    {
        public string Username { get; set; }
        public int Score { get; set; }
        public DateTime ScoreDate { get; set; }
        public bool IAPFlag { get; set; }
    }
}
