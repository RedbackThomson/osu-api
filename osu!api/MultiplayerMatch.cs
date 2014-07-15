using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_api
{
    public class MultiplayerMatch
    {
        public Match match { get; set; }
        public Game[] games { get; set; }
    }

    public class Match
    {
        public int match_id { get; set; }
        public string name { get; set; }
        public DateTime start_time { get; set; }
        public DateTime? end_time { get; set; }
    }

    public class Game
    {
        public int game_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime? end_time { get; set; }
        public int beatmap_id { get; set; }
        public Mode play_mode { get; set; }
        public int match_type { get; set; }
        public ScoringType scoring_type { get; set; }
        public TeamType team_type { get; set; }
        public int mods { get; set; }
        public Score[] scores { get; set; }
    }

    public class MatchScore : Score
    {
        public int slot { get; set; }
        public int team { get; set; }
        public int pass { get; set; }
    }

    public enum ScoringType
    {
        Score = 0,
        Accuracy = 1,
        Combo = 2
    }

    public enum TeamType
    {
        HeadToHead = 0,
        TagCoOp = 1,
        TeamVs = 2,
        TagTeamVs = 3
    }
}
