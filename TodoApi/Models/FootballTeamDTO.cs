using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class FootballTeamDTO
    {
        public long Id { get; set; }
        public string TeamName { get; set; }
        public string Manager { get; set; }
        public string League { get; set; }
    }
}
