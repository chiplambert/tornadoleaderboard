using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TornadoLeaderboard.Models;

namespace TornadoLeaderboard.Controllers
{
    [Route("api/leaderboard")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardContext _context;

        public LeaderboardController(LeaderboardContext context)
        {
            _context = context;

            if (_context.LeaderboardScores.Count() == 0)
            {
                //Create new score if empty
                _context.LeaderboardScores.Add(new LeaderboardScore { UserGOID = 28, Username = "chiplambert", IAPFlag = true, Score = 25000 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<LeaderboardScore>> GetAll()
        {
            return _context.LeaderboardScores.ToList();
        }

        [HttpGet("{id}", Name ="GetScores")]
        public ActionResult<LeaderboardScore> GetById(long id)
        {
            var score = _context.LeaderboardScores.Find(id);
            if (score == null)
            {
                return NotFound();
            }
            return score;
        }

        [HttpPost]
        public IActionResult Create(LeaderboardScore score)
        {
            _context.LeaderboardScores.Add(score);
            _context.SaveChanges();

            return CreatedAtRoute("GetScores", new { id = score.UserGOID }, score);
        }


    }
}