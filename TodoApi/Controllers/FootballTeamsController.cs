using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")] //(api/FootbalTeams)
    [ApiController]
    public class FootballTeamsController : ControllerBase
    {
        private readonly TodoContext _context;

        public FootballTeamsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/FootballTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FootballTeamDTO>>> GetFootballTeams()
        {
            return await _context.FootballTeams
                            .Select(x => FootballTeamToDTO(x))
                            .ToListAsync();
        }

        // GET: api/FootballTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FootballTeamDTO>> GetFootballTeam(long id)
        {
            var footballTeam = await _context.FootballTeams.FindAsync(id);

            if (footballTeam == null)
            {
                return NotFound();
            }

            return FootballTeamToDTO(footballTeam);
        }

        // PUT: api/FootballTeams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootballTeam(long id, FootballTeamDTO footballTeamDTO)
        {
            if (id != footballTeamDTO.Id)
            {
                return BadRequest();
            }

            var footballTeam = await _context.FootballTeams.FindAsync(id);
            if (footballTeam == null)
            {
                return NotFound();
            }

            footballTeam.TeamName = footballTeamDTO.TeamName;
            footballTeam.Manager = footballTeamDTO.Manager;
            footballTeam.League = footballTeamDTO.League;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FootballTeamExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/FootballTeams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FootballTeam>> PostFootballTeam(FootballTeamDTO footballTeamDTO)
        {
            var footballTeam = new FootballTeam
            {
                Id = footballTeamDTO.Id,
                TeamName = footballTeamDTO.TeamName,
                Manager = footballTeamDTO.Manager,
                League = footballTeamDTO.League
            };

            _context.FootballTeams.Add(footballTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetFootballTeam),
                new { id = footballTeam.Id },
                FootballTeamToDTO(footballTeam));
        }

        // DELETE: api/FootballTeams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FootballTeam>> DeleteFootballTeam(long id)
        {
            var footballTeam = await _context.FootballTeams.FindAsync(id);

            if (footballTeam == null)
            {
                return NotFound();
            }

            _context.FootballTeams.Remove(footballTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FootballTeamExists(long id)
            => _context.FootballTeams.Any(e => e.Id == id);


        private static FootballTeamDTO FootballTeamToDTO(FootballTeam footballTeam) =>
            new FootballTeamDTO
            {
                Id = footballTeam.Id,
                TeamName = footballTeam.TeamName,
                Manager = footballTeam.Manager,
                League = footballTeam.League
            };
    }
}
