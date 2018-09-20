using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TornadoLeaderboard.Models
{
    public class LeaderboardScore
    {
        [Key]
        public long UserGOID { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        //public DateTime ScoreDate { get; set; }
        public bool IAPFlag { get; set; }
    }
}
